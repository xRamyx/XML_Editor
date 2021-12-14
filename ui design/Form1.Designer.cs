namespace ui_design
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.browse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.JsonBtn = new System.Windows.Forms.Button();
            this.CompressBtn = new System.Windows.Forms.Button();
            this.MinifyBtn = new System.Windows.Forms.Button();
            this.ConsistencyBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.FormatBtn = new System.Windows.Forms.Button();
            this.DecompressBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.BackColor = System.Drawing.Color.Pink;
            this.browse.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse.Location = new System.Drawing.Point(382, 276);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(132, 37);
            this.browse.TabIndex = 0;
            this.browse.Text = "Put XML file";
            this.browse.UseVisualStyleBackColor = false;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(28, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(350, 571);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // JsonBtn
            // 
            this.JsonBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.JsonBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JsonBtn.Location = new System.Drawing.Point(886, 242);
            this.JsonBtn.Name = "JsonBtn";
            this.JsonBtn.Size = new System.Drawing.Size(132, 37);
            this.JsonBtn.TabIndex = 3;
            this.JsonBtn.Text = "To Json";
            this.JsonBtn.UseVisualStyleBackColor = false;
            // 
            // CompressBtn
            // 
            this.CompressBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.CompressBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompressBtn.Location = new System.Drawing.Point(886, 433);
            this.CompressBtn.Name = "CompressBtn";
            this.CompressBtn.Size = new System.Drawing.Size(132, 37);
            this.CompressBtn.TabIndex = 6;
            this.CompressBtn.Text = "Compress";
            this.CompressBtn.UseVisualStyleBackColor = false;
            // 
            // MinifyBtn
            // 
            this.MinifyBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.MinifyBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinifyBtn.Location = new System.Drawing.Point(886, 335);
            this.MinifyBtn.Name = "MinifyBtn";
            this.MinifyBtn.Size = new System.Drawing.Size(132, 37);
            this.MinifyBtn.TabIndex = 8;
            this.MinifyBtn.Text = "Minify";
            this.MinifyBtn.UseVisualStyleBackColor = false;
            this.MinifyBtn.Click += new System.EventHandler(this.MinifyBtn_Click);
            // 
            // ConsistencyBtn
            // 
            this.ConsistencyBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ConsistencyBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsistencyBtn.Location = new System.Drawing.Point(886, 33);
            this.ConsistencyBtn.Name = "ConsistencyBtn";
            this.ConsistencyBtn.Size = new System.Drawing.Size(132, 59);
            this.ConsistencyBtn.TabIndex = 10;
            this.ConsistencyBtn.Text = "Check Consistency";
            this.ConsistencyBtn.UseVisualStyleBackColor = false;
            this.ConsistencyBtn.Click += new System.EventHandler(this.ConsistencyBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(520, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(328, 571);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            // 
            // FormatBtn
            // 
            this.FormatBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.FormatBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatBtn.Location = new System.Drawing.Point(886, 152);
            this.FormatBtn.Name = "FormatBtn";
            this.FormatBtn.Size = new System.Drawing.Size(132, 37);
            this.FormatBtn.TabIndex = 12;
            this.FormatBtn.Text = "Format";
            this.FormatBtn.UseVisualStyleBackColor = false;
            this.FormatBtn.Click += new System.EventHandler(this.FormatBtn_Click);
            // 
            // DecompressBtn
            // 
            this.DecompressBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.DecompressBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecompressBtn.Location = new System.Drawing.Point(886, 546);
            this.DecompressBtn.Name = "DecompressBtn";
            this.DecompressBtn.Size = new System.Drawing.Size(132, 37);
            this.DecompressBtn.TabIndex = 13;
            this.DecompressBtn.Text = "Decompress";
            this.DecompressBtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ui_design.Properties.Resources.photo_1542903660_eedba2cda473;
            this.ClientSize = new System.Drawing.Size(1052, 622);
            this.Controls.Add(this.DecompressBtn);
            this.Controls.Add(this.FormatBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ConsistencyBtn);
            this.Controls.Add(this.MinifyBtn);
            this.Controls.Add(this.CompressBtn);
            this.Controls.Add(this.JsonBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "XML project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button JsonBtn;
        private System.Windows.Forms.Button CompressBtn;
        private System.Windows.Forms.Button MinifyBtn;
        private System.Windows.Forms.Button ConsistencyBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button FormatBtn;
        private System.Windows.Forms.Button DecompressBtn;
    }
}

