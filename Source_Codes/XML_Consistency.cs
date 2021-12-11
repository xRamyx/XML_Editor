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
            tag_data[0] = (tag_name == "") ? null : tag_name;
            tag_data[1] = letter.ToString(); //Self-closing / or >
            return tag_data;
        }

        //this method checks if the tag has data or not (returns a boolean)
        private bool hasData(StreamReader input)
        {
            char first_letter = skipSpaces(input);//read '<'

            if (first_letter != '<')
            {
                return true;
            }
            return false;
        }
    }
}