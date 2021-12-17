using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace XML_Formatting
{
    class XML_Formatting
    {
        private static StreamWriter writer;
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
            for(int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            // Print Tag Name
            writer.WriteLine("<" + node.getTagName() + ">");
            string value = node.getTagValue();
            // Print Tag value with 4 more indentation spaces
            if(value != "")
            {
                int TagLevel = level + 4;
                for (int i = 0; i < TagLevel; i++)
                {
                    writer.Write(" ");
                }
                writer.WriteLine(value);
            }
            // Recursion call to all children of this node
            foreach(TreeNode subtree in node.getChildren())
            {
                Prettify(subtree,level+4);
            }
            for (int i = 0; i < level; i++)
            {
                writer.Write(" ");
            }
            // Print closing tag without attribute
            string name = node.getTagName();
            writer.Write("</");
            foreach(char c in name)
            {
                if(c == ' ') { break; }
                writer.Write(c);
            }
            writer.WriteLine(">");
        }
    }

    class Program
    { 
        static void Main(string[] args)
        {
            Tree XMLTree = XMLReader.XMLtoTree("C:\\Users\\Rany\\Desktop\\data-sample.xml");
            XML_Formatting.SetLocation("C:\\Users\\Rany\\Desktop\\Formatting.xml");
            XML_Formatting.Prettify(XMLTree.getRoot(), 0);
            XML_Minifying.SetLocation("C:\\Users\\Rany\\Desktop\\Minifying.xml");
            XML_Minifying.Minify(XMLTree.getRoot());
        }
    }
}
