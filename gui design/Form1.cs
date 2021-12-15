namespace gui_design
{
    public partial class Form1 : Form
    {
        string file, inputPath, input_file_name;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NotChange(e);
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NotChange(e);
        }

        private void ConsistencyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string input_path = file;
                string output_path = Path.Combine(inputPath, input_file_name + "_Consistency.xml");
                StreamReader streamReader = new StreamReader(input_path);
                XML_Consistency xml = new XML_Consistency(output_path, 0);
                int errors = xml.checkConsistency(streamReader);
                string word = " <<< ERROR DETECTED & CORRECTED HERE!";
                richTextBox1.Text = File.ReadAllText(output_path);
                int index = 0;
                while (index < richTextBox1.TextLength)
                {
                    int erorr_found = richTextBox1.Find(word, index, RichTextBoxFinds.None);
                    if (erorr_found != -1)
                    {
                        richTextBox1.SelectionStart = erorr_found;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        break;
                    }
                    index += word.Length;
                }
                if (errors > 0)
                {
                    MessageBox.Show("Number of erorrs is " + errors + " and they are detected, corected and highlighted", "INFO!");
                }
                else
                {
                    MessageBox.Show("There are no erorrs in the XML file", "INFO!");

                }
                label1.Text = "The output file has been created in the same path of the input file";
            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please put an input file!", "Alert");

                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }

        private void FormatBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Tree XMLTree = XMLReader.XMLtoTree(file);
                Formatting.SetLocation(Path.Combine(inputPath, input_file_name + "_Format.xml"));
                Formatting.Prettify(XMLTree.getRoot(), 0);
                Formatting.writer.Close();
                richTextBox1.Text = File.ReadAllText(Path.Combine(inputPath, input_file_name + "_Format.xml"));
                MessageBox.Show("The XML file has been formatted", "INFO!");
                label1.Text = "The output file has been created in the same path of the input file";

            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please put an input file!", "Alert");

                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }

        private void MinifyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Tree XMLTree = XMLReader.XMLtoTree(file);
                Formatting.SetLocation(Path.Combine(inputPath, input_file_name + "_Minify.xml"));
                Formatting.Minify(XMLTree.getRoot());
                Formatting.writer.Close();
                richTextBox1.Text = File.ReadAllText(Path.Combine(inputPath, input_file_name + "_Minify.xml"));
                MessageBox.Show("The XML file has been minified", "INFO!");
                label1.Text = "The output file has been created in the same path of the input file";

            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please put an input file!", "Alert");

                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }

        private void CompressBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string input_path = file;
                string output_path = Path.Combine(inputPath, input_file_name + "_Compress.xml");
                StreamReader streamReader = new StreamReader(input_path);
                CompressClass.Compress(input_path, output_path);
                richTextBox1.Text = File.ReadAllText(output_path);
                label1.Text = "The output file has been created in the same path of the input file";

            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please put an input file!", "Alert");

                }
                else MessageBox.Show(x.Message, "Alert");
            }

        }

        private void DecompressBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string input_path = file;
                string output_path = Path.Combine(inputPath, input_file_name + "_Decompress.xml");
                StreamReader streamReader = new StreamReader(input_path);
                CompressClass.decompress(input_path, output_path);
                richTextBox1.Text = File.ReadAllText(output_path);
                label1.Text = "The output file has been created in the same path of the input file";
            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please put an input file!", "Alert");

                }
                else MessageBox.Show("Please input a compressed file!", "Alert");
            }

        }
       
        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "XML files (*.xml)|*.xml"; /* chose type of files*/
                ofd.ShowDialog();
                textBox1.Text = File.ReadAllText(ofd.FileName);
                file = ofd.FileName;
                input_file_name = System.IO.Path.GetFileNameWithoutExtension(file);
                inputPath = System.IO.Path.GetDirectoryName(file);
            }
            catch (Exception x)
            {
                
            } 

        }
        private void NotChange(KeyPressEventArgs e) /* function to prevent writing in textbox */
        {
            e.Handled = true;
        }

    }
}