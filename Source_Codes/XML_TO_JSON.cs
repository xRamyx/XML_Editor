using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XML_TO_JSON
{
    class TreeNode
    {
        private string TagName;
        private string TagValue;
        private List<TreeNode> children = new List<TreeNode>();
        private TreeNode parent;
        public TreeNode(string TagName, string TagValue)
        {
            this.TagName = TagName;
            this.TagValue = TagValue;
        }
        public string getTagName() { return TagName; }
        public string getTagValue() { return TagValue; }
        public TreeNode getParent() { return parent; }
        public List<TreeNode> getChildren() { return children; }
        public void setParent(TreeNode parent) { this.parent = parent; }
        public TreeNode addChild(string TagName, string TagValue)
        {
            TreeNode temp = new TreeNode(TagName, TagValue);
            children.Add(temp);
            return temp;
        }
        public TreeNode addChild(TreeNode node)
        {
            children.Add(node);
            return node;
        }
    }

    class Tree
    {
        private TreeNode root = null;
        private TreeNode current_parent = null;
        public Tree(TreeNode root = null)
        {
            this.root = root;
        }
        public TreeNode getRoot()
        {
            return root;
        }
        public void insert(string TagName, string TagValue)
        {
            if (root == null)
            {
                root = new TreeNode(TagName, TagValue);
                current_parent = root;
            }
            else
            {
                TreeNode temp = current_parent.addChild(TagName, TagValue);
                temp.setParent(current_parent);
                current_parent = temp;
            }
        }
        public void move_parent_up()

        {
            current_parent = current_parent.getParent();
        }
    }

    class XMLReader
    {
        public static Tree XMLtoTree(string location)
        {
            string contents;
            Tree XMLTree = new Tree();
            using (StreamReader streamReader = new StreamReader(location))
            {
                contents = streamReader.ReadToEnd();
            }
            int i;
            for (i = 0; i < contents.Length; i++)
            {
                if (contents[i] == '<')
                {
                    i++;
                    if (contents[i] == '/')
                    {
                        XMLTree.move_parent_up();
                    }
                    else
                    {
                        string openingTag = "";
                        while (contents[i] != '>')
                        {
                            openingTag += contents[i];
                            i++;
                        }
                        i++;
                        while (contents[i] == ' ' || contents[i] == '\n' || contents[i] == '\r') i++;
                        string tagValue = "";
                        if (contents[i] == '<')
                        {
                            i--;
                        }
                        else
                        {
                            while (contents[i] != '<' && contents[i] != '\n')
                            {
                                tagValue += contents[i];
                                i++;
                            }
                            i--;
                        }
                        XMLTree.insert(openingTag, tagValue);
                    }
                }
            }
            return XMLTree;
        }
    }

    class ConvertingToJason
    {
        public static StreamWriter writer1;
        public static void SetLocation(string location)
        {
            writer1 = new StreamWriter(location);
            writer1.AutoFlush = true;
        }
        public static Boolean ChildrenAreSame(TreeNode node, int level)
        {
            List<TreeNode> check = node.getChildren();
            if(check.Count()>1 && check[0].getTagName() == check[1].getTagName())
                return true;
            else
                return false;
        }
        public static int noOfChildren(TreeNode node, int level)
        {
            List<TreeNode> number = node.getChildren();
            return number.Count;
        }

        public static string taps(int level)
        {
            string result = "";
            for (int i = 0; i < level; i++) result += "    ";
            return result;
        }

        
        public static string printJasonToFile(TreeNode node, int level)
        {
            string result ="";
            TreeNode p = node.getParent();
            if(!string.IsNullOrEmpty(node.getTagValue()))
            {
                char[] trimmed = {'\n',' ',(char)13};
                if(!ChildrenAreSame(p,level))
                {
                    //Case 1
                    
                    result += taps(level) + "\"" + node.getTagName() + "\": ";
                    Boolean f= int.TryParse(node.getTagValue(),out int n);
                    string data = f?node.getTagValue():'"'+node.getTagValue().Trim(trimmed)+'"';
                    result += data;
                }
                else
                {
                    //Case 2
                    string value;
                    result += taps(level) + "\"" + node.getTagName() + "\": [\n";
                    for (int i = 0; i < p.getChildren().Count(); i++)
                    {
                        value = node.getTagValue().Trim(trimmed);
                        string comma = i<p.getChildren().Count()-1?",":"";
                        Boolean f= int.TryParse(value,out int n);
                        string data = f?value:string.Format("\"{0}\"",value);
                        data +=comma;
                        //writer1.WriteLine(data);
                        result += taps(level+1) + data + "\n";
                    }
                    result += taps(level) + "]";
                }
            }
            else
            {
                if(!ChildrenAreSame(p,level))
                {
                    //Case 3
                    result += taps(level) + "\"" + node.getTagName() + "\": {\n";
                    result += printJasonToFile(node.getChildren()[0],level+1);
                    result += "\n" + taps(level) + "}";
                }
                else
                {
                    string comma;
                    //Case 4
                    result += taps(level) + " \"" + node.getTagName() + "\": [\n";
                    for (int i = 0; i < p.getChildren().Count(); i++)
                    {
                        List<TreeNode> children = p.getChildren()[i].getChildren();
                        result += taps(level+1) + "{\n";
                        for (int j = 0; j < children.Count(); j++)
                        {
                            result += printJasonToFile(children[j],level+2);
                            comma = j<children.Count()-1?",\n":"\n";
                            result += comma;
                        }
                        comma = taps(level+1);
                        comma += i<p.getChildren().Count()-1?"},\n":"}\n";
                        result += comma;
                    }
                    result += taps(level) + "]";
                }
            }
            return result;
        }
    }
}