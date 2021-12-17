using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

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
        // Function to return an XML file as a tree
        public static Tree XMLtoTree(string location)
        {
            // read XML file as a string in contents
            string contents;
            Tree XMLTree = new Tree();
            using (StreamReader streamReader = new StreamReader(location))
            {
                contents = streamReader.ReadToEnd();
            }
            // Loop on every character in the file
            int i;
            for (i = 0; i < contents.Length; i++)
            {
                // Search for opening or closing tag
                if (contents[i] == '<')
                {
                    i++;
                    // If closing tag then decrement heriarchy in tree
                    if (contents[i] == '/')
                    {
                        XMLTree.move_parent_up();
                    }
                    // Ignore XML version line
                    else if (contents[i] == '?') { }
                    // Ignore XML comments
                    else if (contents[i] == '!') { }
                    // Then this is opening tag
                    else
                    {
                        // Take the tag name in a string until closing bracket
                        string openingTag = "";
                        while (contents[i] != '>' && contents[i] != ' ')
                        {
                            openingTag += contents[i];
                            i++;
                        }
                        if (contents[i] == ' ')
                        {
                            while (contents[i] != '>') i++;
                        }
                        i++;
                        // Ignore spaces and new lines
                        while (contents[i] == ' ' || contents[i] == '\n' || contents[i] == '\r') i++;
                        string tagValue = "";
                        // If there is no tag value then skip
                        if (contents[i] == '<')
                        {
                            i--;
                        }
                        // In case there is tag value
                        else
                        {
                            // Take the tag value in a string until there is a new line or an opening tag
                            while (contents[i] == ' ' || contents[i] == '\n' || contents[i] == '\r') i++;
                            while (true)
                            {
                                if(contents[i] == '\n' || contents[i] == '\r' || contents[i] == (char)13)
                                {
                                    i++;
                                }
                                else if (contents[i] == '<')
                                {
                                    break;
                                }
                                else
                                {
                                    tagValue += contents[i];
                                    i++;
                                }
                            }
                            i--;
                        }
                        // Insert the node in the tree
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
                    Boolean f= double.TryParse(node.getTagValue(),out double n);
                    string data = f?((double)n).ToString():'"'+node.getTagValue().Trim(trimmed)+'"';
                    result += data;
                }
                else
                {
                    //Case 2
                    string value;
                    result += taps(level) + "\"" + node.getTagName() + "\": [\n";
                    for (int i = 0; i < p.getChildren().Count(); i++)
                    {
                        value = p.getChildren()[i].getTagValue().Trim(trimmed);
                        string comma = i<p.getChildren().Count()-1?",":"";
                        Boolean f= double.TryParse(value,out double n);
                        string data = f?((double)n).ToString():string.Format("\"{0}\"",value);
                        data +=comma;
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
                    string comma;
                    result += taps(level) + "\"" + node.getTagName() + "\": {\n";
                    List<TreeNode> children = node.getChildren();
                    if(ChildrenAreSame(node,level))
                    {
                        result += printJasonToFile(children[0],level+1) + "\n";
                    }
                    else
                    {
                        for (int i = 0; i < children.Count(); i++)
                        {
                             result += printJasonToFile(children[i],level+1);
                             comma = i<children.Count()-1?",\n":"\n";
                             result += comma;
                        }
                    }
                    result += taps(level) + "}";
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