using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace XML_Formatting
{
    class XMLReader
    {
        // Function to return an XML file as a tree used for xml formatting and minifying
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
                        // Take the tag name in a string until a closing bracket or a space
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
                            // Start taking the tag value in a string until there is an opening tag
                            while (contents[i] != '<')
                            {
                                // skip new line characters
                                if (contents[i] == '\r' || contents[i] == '\n')
                                {
                                    i++;
                                }
                                else if (contents[i] == ' ')
                                {
                                    tagValue += contents[i];
                                    i++;
                                    // If there is a new line after a space then skip all the spaces (indentation) after it 
                                    if (contents[i] == '\r' || contents[i] == '\n')
                                    {
                                        i++;
                                        if (contents[i] == '\n') { i++; }
                                        while (contents[i] == ' ')
                                        {
                                            i++;
                                        }
                                    }
                                    // If there is a space after a space then ignore the upcoming spaces
                                    else if (contents[i] == ' ')
                                    {
                                        while (contents[i] == ' ') { i++; }
                                    }
                                }
                                else
                                {
                                    // Take all the characters otherwise
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
        // Function to return an XML file as a tree used for json to ignore attributes after tag name
        public static Tree XMLtoTreeForJSON(string location)
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
                        // Take the tag name in a string until a closing bracket or a space
                        string openingTag = "";
                        while (contents[i] != '>' && contents[i] != ' ')
                        {
                            openingTag += contents[i];
                            i++;
                        }
                        // If there was a space ignore characters until closing bracket
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
                            // Start taking the tag value in a string until there is an opening tag
                            while (contents[i] != '<')
                            {
                                // skip new line characters
                                if (contents[i] == '\r' || contents[i] == '\n')
                                {
                                    i++;
                                }
                                else if (contents[i] == ' ')
                                {
                                    tagValue += contents[i];
                                    i++;
                                    // If there is a new line after a space then skip all the spaces (indentation) after it 
                                    if (contents[i] == '\r' || contents[i] == '\n')
                                    {
                                        i++;
                                        if (contents[i] == '\n') { i++; }
                                        while (contents[i] == ' ')
                                        {
                                            i++;
                                        }
                                    }
                                    // If there is a space after a space then ignore the upcoming spaces
                                    else if (contents[i] == ' ')
                                    {
                                        while (contents[i] == ' ') { i++; }
                                    }
                                }
                                else
                                {
                                    // Take all the characters otherwise
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
}
