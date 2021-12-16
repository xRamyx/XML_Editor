namespace gui_design
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.browse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ConsistencyBtn = new System.Windows.Forms.Button();
            this.FormatBtn = new System.Windows.Forms.Button();
            this.JsonBtn = new System.Windows.Forms.Button();
            this.MinifyBtn = new System.Windows.Forms.Button();
            this.CompressBtn = new System.Windows.Forms.Button();
            this.DecompressBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.browse.Location = new System.Drawing.Point(425, 275);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(132, 49);
            this.browse.TabIndex = 0;
            this.browse.Text = "Put XML file";
            this.browse.UseVisualStyleBackColor = false;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(367, 581);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(577, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(369, 581);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // ConsistencyBtn
            // 
            this.ConsistencyBtn.BackColor = System.Drawing.SystemColors.Info;
            this.ConsistencyBtn.Location = new System.Drawing.Point(983, 21);
            this.ConsistencyBtn.Name = "ConsistencyBtn";
            this.ConsistencyBtn.Size = new System.Drawing.Size(132, 49);
            this.ConsistencyBtn.TabIndex = 3;
            this.ConsistencyBtn.Text = "Check Consistency";
            this.ConsistencyBtn.UseVisualStyleBackColor = false;
            this.ConsistencyBtn.Click += new System.EventHandler(this.ConsistencyBtn_Click);
            // 
            // FormatBtn
            // 
            this.FormatBtn.BackColor = System.Drawing.SystemColors.Info;
            this.FormatBtn.Location = new System.Drawing.Point(983, 109);
            this.FormatBtn.Name = "FormatBtn";
            this.FormatBtn.Size = new System.Drawing.Size(132, 49);
            this.FormatBtn.TabIndex = 4;
            this.FormatBtn.Text = "Format";
            this.FormatBtn.UseVisualStyleBackColor = false;
            this.FormatBtn.Click += new System.EventHandler(this.FormatBtn_Click);
            // 
            // JsonBtn
            // 
            this.JsonBtn.BackColor = System.Drawing.SystemColors.Info;
            this.JsonBtn.Location = new System.Drawing.Point(983, 211);
            this.JsonBtn.Name = "JsonBtn";
            this.JsonBtn.Size = new System.Drawing.Size(132, 49);
            this.JsonBtn.TabIndex = 5;
            this.JsonBtn.Text = "To Json";
            this.JsonBtn.UseVisualStyleBackColor = false;
            this.JsonBtn.Click += new System.EventHandler(this.JsonBtn_Click);
            // 
            // MinifyBtn
            // 
            this.MinifyBtn.BackColor = System.Drawing.SystemColors.Info;
            this.MinifyBtn.Location = new System.Drawing.Point(983, 313);
            this.MinifyBtn.Name = "MinifyBtn";
            this.MinifyBtn.Size = new System.Drawing.Size(132, 49);
            this.MinifyBtn.TabIndex = 6;
            this.MinifyBtn.Text = "Minify";
            this.MinifyBtn.UseVisualStyleBackColor = false;
            this.MinifyBtn.Click += new System.EventHandler(this.MinifyBtn_Click);
            // 
            // CompressBtn
            // 
            this.CompressBtn.BackColor = System.Drawing.SystemColors.Info;
            this.CompressBtn.Location = new System.Drawing.Point(983, 428);
            this.CompressBtn.Name = "CompressBtn";
            this.CompressBtn.Size = new System.Drawing.Size(132, 49);
            this.CompressBtn.TabIndex = 7;
            this.CompressBtn.Text = "Compress";
            this.CompressBtn.UseVisualStyleBackColor = false;
            this.CompressBtn.Click += new System.EventHandler(this.CompressBtn_Click);
            // 
            // DecompressBtn
            // 
            this.DecompressBtn.BackColor = System.Drawing.SystemColors.Info;
            this.DecompressBtn.Location = new System.Drawing.Point(983, 553);
            this.DecompressBtn.Name = "DecompressBtn";
            this.DecompressBtn.Size = new System.Drawing.Size(132, 49);
            this.DecompressBtn.TabIndex = 8;
            this.DecompressBtn.Text = "Decompress";
            this.DecompressBtn.UseVisualStyleBackColor = false;
            this.DecompressBtn.Click += new System.EventHandler(this.DecompressBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(200, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 28);
            this.label1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1164, 680);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecompressBtn);
            this.Controls.Add(this.CompressBtn);
            this.Controls.Add(this.MinifyBtn);
            this.Controls.Add(this.JsonBtn);
            this.Controls.Add(this.FormatBtn);
            this.Controls.Add(this.ConsistencyBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "XML Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button browse;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button ConsistencyBtn;
        private Button FormatBtn;
        private Button JsonBtn;
        private Button MinifyBtn;
        private Button CompressBtn;
        private Button DecompressBtn;
        private Label label1;
    }
}