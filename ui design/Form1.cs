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
        string file;
        public Form1()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"; /* chose type of files*/ 
            ofd.ShowDialog();
            textBox1.Text = File.ReadAllText(ofd.FileName);
            file = ofd.FileName;

        }
        private void NotChange(KeyPressEventArgs e) /* function to prevent writing in text box */ 
        {
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            NotChange(e);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            NotChange(e);
        }

        private void ConsistencyBtn_Click(object sender, EventArgs e)
        {
            string input_path = file;
            string output_path = @"C:\Users\moamn\OneDrive\Desktop\New folder (3)\test.txt";
            StreamReader streamReader = new StreamReader(input_path);
            XML_Consistency xml = new XML_Consistency(output_path, 0);
            int errors = xml.checkConsistency(streamReader);           
            richTextBox1.Text = File.ReadAllText(output_path);
            string word = " <<< ERROR DETECTED & CORRECTED HERE!";
            int index = 0;
            while(index < richTextBox1.TextLength)
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
                index +=  word.Length ;
            }         
        }
    }
}
