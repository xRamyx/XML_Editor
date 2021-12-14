using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui_design
{
    public partial class Form1 : Form
    {
        string file, output;

        public Form1()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"; /* chose type of files*/
                ofd.ShowDialog();
                textBox1.Text = File.ReadAllText(ofd.FileName);
                file = ofd.FileName;
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Alert");
            }
            }
        private void Outputbtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"; /* chose type of files*/
                ofd.ShowDialog();
                //textBox1.Text = File.ReadAllText(ofd.FileName);
                output = ofd.FileName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Alert");
            }
        }
        private void NotChange(KeyPressEventArgs e) /* function to prevent writing in textbox */
        {
            e.Handled = true;
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
                string output_path = output;
                StreamReader streamReader = new StreamReader(input_path);
                XML_Consistency xml = new XML_Consistency(output_path, 0);
                int errors = xml.checkConsistency(streamReader);
                richTextBox1.Text = File.ReadAllText(output_path);
                string word = " <<< ERROR DETECTED & CORRECTED HERE!";
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
                    MessageBox.Show("Number of erorrs is " + errors + " and they are detected and corected and highlighted", "INFO!");
                }
                else
                {
                    MessageBox.Show("There are no erorrs in the XML file", "INFO!");

                }
            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please! Put input file!", "Alert");

                }
                else if (output == null)
                {
                    MessageBox.Show("Please! Put output file!", "Alert");
                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }

        private void FormatBtn_Click(object sender, EventArgs e)
        {        
            try
            {
                Tree XMLTree = XMLReader.XMLtoTree(file);
                Formatting.SetLocation(output);
                Formatting.Prettify(XMLTree.getRoot(), 0);
                Formatting.writer.Close();
                richTextBox1.Text = File.ReadAllText(output);
                MessageBox.Show("The XML file has been formatted", "INFO!");
            }
            catch ( Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please! Put input file!", "Alert");

                }
                else if (output == null)
                {
                    MessageBox.Show("Please! Put output file!", "Alert");
                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }
        private void MinifyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Tree XMLTree = XMLReader.XMLtoTree(file);
                Formatting.SetLocation(output);
                Formatting.Minify(XMLTree.getRoot());
                Formatting.writer.Close();
                richTextBox1.Text = File.ReadAllText(output);
                MessageBox.Show("The XML file has been minified", "INFO!");
            }
            catch (Exception x)
            {
                if (file == null)
                {
                    MessageBox.Show("Please! Put input file!", "Alert");

                }
                else if (output == null)
                {
                    MessageBox.Show("Please! Put output file!", "Alert");
                }
                else MessageBox.Show(x.Message, "Alert");
            }
        }
    }
}
