using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Editor
{
    class XML_Visualize
    {
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

        public List<string> tag_data = new List<string>();

        public XML_Visualize(){}

        //this metod is used to skip characters until '<' is found >>> opening tag
        private void skipChars(StreamReader input)
        {
            char letter = (char)input.Read();

            while (letter != '<' && input.Peek() > -1)
            {
                letter = (char)input.Read();
            }
        }

        //this method is used to read tag name and tag attributes of the tag
        private void readTag(StreamReader input)
        {
            char letter = (char)input.Read();
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
        }


		public Microsoft.Msagl.Drawing.Graph visualize(StreamReader input)
        {
			char characters;
            string tag_name = null;
			string source = "";
			string destination = "";

            //read from the file char by char(-1 means no data to be read)
            while (input.Peek() > -1)
            {
				while(input.Peek() > -1)
				{
					//read charachters until you reach '<'
                	skipChars(input);
					//check if it is an opening tag
					if (Char.IsLetter((char)input.Peek()))
					{
						//get the tagname
						readTag(input);
						tag_name = tag_data[0];

						//check that it is NOT a selfclosing tag
						if (tag_data[1] != "/")
						{
							if(tag_name == "user")
							{
								break;
							}
						}
					}
				}

				while(input.Peek() > -1)
				{
					//read charachters until you reach '<'
					skipChars(input);

					//check if it is an opening tag
					if (Char.IsLetter((char)input.Peek()))
					{
						//get the tagname
						readTag(input);
						tag_name = tag_data[0];

						//check that it is NOT a selfclosing tag
						if (tag_data[1] != "/")
						{
							if(tag_name == "id")
							{
								characters = (char)input.Read();
								while(characters != '<')
								{
									destination += characters.ToString();
									characters = (char)input.Read();
								}
								graph.AddNode(destination);
								break;
							}
						}
					}
				}

				while(input.Peek() > -1)
				{
					//read charachters until you reach '<'
					skipChars(input);

					//check if it is an opening tag
					if (Char.IsLetter((char)input.Peek()))
					{
						//get the tagname
						readTag(input);
						tag_name = tag_data[0];

						//check that it is NOT a selfclosing tag
						if (tag_data[1] != "/")
						{
							if(tag_name == "id")
							{
								characters = (char)input.Read();
								while(characters != '<')
								{
									source += characters.ToString();
									characters = (char)input.Read();
								}
								graph.AddEdge(source, destination);
								source = "";
							}
						}
					}
					//if it is a closing tag
                	if (input.Peek() == (int)'/')
                	{
                    	characters = (char)input.Read();

                 		//get the tag name of the closing tag
                    	readTag(input);
                    	tag_name = tag_data[0];

						if(tag_name == "user")
						{
							destination = "";
							break;
						}
                	}
				}
            }
			return graph;
        }
	}
}