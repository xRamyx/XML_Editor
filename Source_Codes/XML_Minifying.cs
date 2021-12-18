using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace XML_Formatting
{
    class XML_Minifying
    {
        private static StreamWriter writer;
        // Function to set the location of the output file
        public static void SetLocation(string location)
        {
            writer = new StreamWriter(location);
            writer.AutoFlush = true;
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

            // Print closing tag without attribute
            string name = node.getTagName();
            writer.Write("</");
            foreach (char c in name)
            {
                if (c == ' ') { break; }
                writer.Write(c);
            }
            writer.Write(">");
        }
    }
}
