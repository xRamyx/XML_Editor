using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Editor
{
    class XML_Consistency
    {
        public int first_time;
        public string file_name;

        public XML_Consistency(string file_name, int first_time)
        {
            this.file_name = file_name;
            this.first_time = first_time;
        }

        //this method writes the output in a file
        public void output(string s, bool new_line)
        {
            //overwrite the file for the first time
            if (first_time == 0)
            {
                StreamWriter file = new StreamWriter(file_name, false);
                if (new_line == true)
                {
                    file.WriteLine(s);
                    file.Close();
                }
                else
                {
                    file.Write(s);
                    file.Close();
                }
                first_time = 1;
            }
            //append the existing file after the first time
            else
            {
                StreamWriter file = new StreamWriter(file_name, true);
                if (new_line == true)
                {
                    file.WriteLine(s);
                    file.Close();
                }
                else
                {
                    file.Write(s);
                    file.Close();
                }
            }
        }

        //this metod is used to skip characters until '<' is found >>> opening tag
        private void skipChars(StreamReader input)
        {
            char letter = (char)input.Read();

            while (letter != '<')
            {
                output(letter.ToString(), false);
                letter = (char)input.Read();
            }
        }

        //this method is used to skip spaces and returns the first letter after the spaces
        private char skipSpaces(StreamReader input)
        {
            char letter;
            while (input.Peek() == (int)'\n' || input.Peek() == (int)'\t' || input.Peek() == (int)' ')
            {
                letter = (char)input.Read();
            }
            return (char)input.Peek();
        }

        //this method is used to read tag name and tag attributes of the tag
        private List<string> readTag(StreamReader input)
        {
            char letter = (char)input.Read();
            List<string> tag_data = new List<string>();
            tag_data.Add(null);
            tag_data.Add(null);
            tag_data.Add(null);

            string tag_name = "";

            
            while (letter != '>')
            {
                tag_name += letter.ToString();
                letter = (char)input.Read();

                //if there are attributes for the tag
                if (letter == ' ')
                {
                    string attributes = "";
                    while (letter != '>')
                    {
                        attributes += letter.ToString();
                        letter = (char)input.Read();
                        //Self-closing tag
                        if (letter == '/' && input.Peek() == (int)'>')
                        {
                            break;
                        }

                    }
                    tag_data[2] = attributes;
                }
                //Self-closing tag
                if (letter == '/' && input.Peek() == (int)'>')
                {
                    break;
                }
            }
            tag_data[0] = tag_name;
            tag_data[1] = letter.ToString(); //Self-closing '/' or '>'
            return tag_data;
        }

        //this method checks if the tag has data or not (returns a boolean)
        private bool hasData(StreamReader input)
        {
            char first_letter = skipSpaces(input);//read '<' if it has no data or read a letter if it has data

            if (first_letter != '<' && first_letter != '\r') // \r is the carriage return
            {
                return true;
            }
            return false;
        }

        //this method is used to check the consistency of the xml file and output the corrected file
        public int checkConsistency(StreamReader input)
        {
            Stack<string> tags = new Stack<string>();
            List<string> tag_data = new List<string>();
            int errors = 0;
            char characteres;
            string tag_name = null;
            string tag_attributes = null;
            bool current_has_data = false;//to know if the saved tag name has data or not
            bool previous_has_data = false;
            bool previous_closed = false;

            //read from the file char by char(-1 means no data to be read)
            while (input.Peek() > -1)
            {
                //read charachters until you reach '<'
                skipChars(input);

                //check if it is an opening tag
                if (Char.IsLetter((char)input.Peek()))
                {
                    //get the tagname
                    tag_data = readTag(input);
                    tag_name = tag_data[0];

                    //get tag attributes
                    tag_attributes = tag_data[2];

                    //check that it is NOT a selfclosing tag (dont push on stack)
                    if (tag_data[1] != "/")
                    {
                        //read tag data
                        current_has_data = hasData(input);

                        //if it is the first opening tag then push it in stack
                        if (tags.Count == 0)
                        {
                            tags.Push(tag_name);
                            output("<" + tag_name + tag_attributes + ">", false);
                        }

                        //if we have an open tag and the previous one has the same tag name>>> error
                        else if (tag_name == tags.Peek())
                        {
                            output("</" + tags.Peek() + ">" + " <<< ERROR DETECTED & CORRECTED HERE!", true);
                            tags.Pop();
                            tags.Push(tag_name);
                            output("<" + tag_name + tag_attributes + ">", false);
                            errors++;
                        }

                        //if the opened tag has data and is not closed
                        else if (previous_has_data && !previous_closed)
                        {
                            output("</" + tags.Peek() + ">" + " <<< ERROR DETECTED & CORRECTED HERE!", true);
                            previous_closed = true;
                            tags.Pop();
                            tags.Push(tag_name);
                            output("<" + tag_name + tag_attributes + ">", false);
                            errors++;
                        }

                        else
                        {
                            //no errors
                            tags.Push(tag_name);
                            output("<" + tag_name + tag_attributes + ">", false);
                        }
                    }
                    else if (tag_data[1] == "/")
                    {
                        if (previous_has_data && !previous_closed)
                        {
                            //check if current tag has data or not
                            output("</" + tags.Peek() + ">", true);
                            previous_closed = true;
                            tags.Pop();
                            errors++;
                        }

                        //selfclosing tag
                        output("<" + tag_name + tag_attributes + "/>", false);
                        characteres = (char)input.Read();
                    }
                    else
                    {
                        output("<" + tag_data[1], false);
                    }

                    //if it is a selfcosing tag then it does not have data and it closes itself
                    previous_has_data = (tag_data[1] == "/") ? false : current_has_data;
                    previous_closed = (tag_data[1] == "/") ? true : false;
                }

                //if it is a closing tag
                else if (input.Peek() == (int)'/')
                {
                    characteres = (char)input.Read();

                    //get the tag name of the closing tag
                    tag_name = readTag(input)[0];

                    //compare it with the top of stack
                    if (tags.Count > 0 && tags.Peek() == tag_name)
                    {
                        output("</" + tag_name + ">", false);
                        tags.Pop();
                        previous_closed = true;
                    }

                    //if the tag name does not match the tag name on the top of the stack >>> error
                    else if (tags.Count > 0)
                    {
                        errors ++;
                        output("</" + tags.Peek() + ">" + " <<< ERROR DETECTED & CORRECTED HERE!", false);
                        tags.Pop();
                        previous_closed = true;

                        if (tags.Count > 0 && tag_name == tags.Peek())
                        {
                            output("</" + tag_name + ">", false);
                            tags.Pop();
                        }
                    }
                }

                //if it is a comment or preprocessor tag >>> skip
                else
                {
                    characteres = (char)input.Read();
                    while (characteres != '>')
                    {
                        characteres = (char)input.Read();
                    }
                }
            }

            //if the stack is not empty >>> error
            while (tags.Count != 0)
            {
                errors++;
                output("</" + tags.Peek() + ">" + " <<< ERROR DETECTED & CORRECTED HERE!", false);
                tags.Pop();
            }

            return errors;
        }
    }
}