using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XML_Formatting
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

    class Formatting
    {
        public static StreamWriter writer;
        public static void SetLocation(string location)
        {
            writer = new StreamWriter(location);
            writer.AutoFlush = true;
        }
        public static void printXMLToFile(TreeNode node, int level)
        {
            for (int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            writer.WriteLine("<" + node.getTagName() + ">");
            string value = node.getTagValue();
            if (value != "")
            {
                int TagLevel = level + 4;
                for (int i = 0; i < TagLevel; i++)
                {
                    writer.Write(" ");
                }
                writer.WriteLine(value);
            }
            else { }

            foreach (TreeNode subtree in node.getChildren())
            {
                printXMLToFile(subtree, level + 4);
            }
            for (int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            writer.WriteLine("</" + node.getTagName() + ">");
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
}
