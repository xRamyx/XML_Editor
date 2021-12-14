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
        // Function to add a child to this node
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

        // Function to insert a node into the tree
        public void insert(string TagName, string TagValue)
        {
            // First time entering the tree to add a node
            if (root == null)
            {
                // Add this node and set it as the Root and the Current Parent
                root = new TreeNode(TagName, TagValue);
                current_parent = root;
            }
            // Normal case for adding a node
            else
            {
                // Add the node under the Current Parent and set the Current Parent to this new node
                TreeNode temp = current_parent.addChild(TagName, TagValue);
                temp.setParent(current_parent);
                current_parent = temp;
            }
        }

        // Function to move up the heriarchy in a tree in case tag is closed
        public void move_parent_up()
        {
            current_parent = current_parent.getParent();
        }
    }

    class Formatting
    {
        public static StreamWriter writer;
        // Function to set the location of the output file
        public static void SetLocation(string location)
        {
            writer = new StreamWriter(location);
            writer.AutoFlush = true;
        }

        // Function to pretiffy the xml file
        public static void Prettify(TreeNode node, int level)
        {
            // Print 4 spaces as indentation
            for (int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            // Print Tag Name
            writer.WriteLine("<" + node.getTagName() + ">");
            string value = node.getTagValue();
            // Print Tag value with 4 more indentation spaces
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
            // Recursion call to all children of this node
            foreach (TreeNode subtree in node.getChildren())
            {
                Prettify(subtree, level + 4);
            }
            for (int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            // Print closing tag
            writer.WriteLine("</" + node.getTagName() + ">");
        }

        // Function to print the XML file without spaces or new lines
        public static void Minify(TreeNode node)
        {
            writer.Write("<" + node.getTagName() + ">");
            string value = node.getTagValue();
            writer.Write(value);

            foreach (TreeNode subtree in node.getChildren())
            {
                Minify(subtree);
            }

            writer.Write("</" + node.getTagName() + ">");
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
                        while (contents[i] != '>')
                        {
                            openingTag += contents[i];
                            i++;
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
                            while (contents[i] != '<' && contents[i] != '\r' && contents[i] != '\n')
                            {
                                tagValue += contents[i];
                                i++;
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