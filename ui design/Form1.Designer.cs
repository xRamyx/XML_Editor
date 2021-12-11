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
            this.browse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.JsonBtn = new System.Windows.Forms.Button();
            this.ValidateBtn = new System.Windows.Forms.Button();
            this.CorrectBtn = new System.Windows.Forms.Button();
            this.CompressBtn = new System.Windows.Forms.Button();
            this.MinifyBtn = new System.Windows.Forms.Button();
            this.BeautyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.BackColor = System.Drawing.Color.Pink;
            this.browse.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse.Location = new System.Drawing.Point(431, 242);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(148, 37);
            this.browse.TabIndex = 0;
            this.browse.Text = "Put XML file";
            this.browse.UseVisualStyleBackColor = false;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(57, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(343, 488);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(608, 33);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(342, 488);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // JsonBtn
            // 
            this.JsonBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.JsonBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JsonBtn.Location = new System.Drawing.Point(997, 199);
            this.JsonBtn.Name = "JsonBtn";
            this.JsonBtn.Size = new System.Drawing.Size(148, 37);
            this.JsonBtn.TabIndex = 3;
            this.JsonBtn.Text = "To Json";
            this.JsonBtn.UseVisualStyleBackColor = false;
            // 
            // ValidateBtn
            // 
            this.ValidateBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ValidateBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValidateBtn.Location = new System.Drawing.Point(997, 108);
            this.ValidateBtn.Name = "ValidateBtn";
            this.ValidateBtn.Size = new System.Drawing.Size(148, 37);
            this.ValidateBtn.TabIndex = 4;
            this.ValidateBtn.Text = "Validate";
            this.ValidateBtn.UseVisualStyleBackColor = false;
            // 
            // CorrectBtn
            // 
            this.CorrectBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.CorrectBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorrectBtn.Location = new System.Drawing.Point(997, 33);
            this.CorrectBtn.Name = "CorrectBtn";
            this.CorrectBtn.Size = new System.Drawing.Size(148, 37);
            this.CorrectBtn.TabIndex = 5;
            this.CorrectBtn.Text = "Correct";
            this.CorrectBtn.UseVisualStyleBackColor = false;
            // 
            // CompressBtn
            // 
            this.CompressBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.CompressBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompressBtn.Location = new System.Drawing.Point(997, 484);
            this.CompressBtn.Name = "CompressBtn";
            this.CompressBtn.Size = new System.Drawing.Size(148, 37);
            this.CompressBtn.TabIndex = 6;
            this.CompressBtn.Text = "Compress";
            this.CompressBtn.UseVisualStyleBackColor = false;
            // 
            // MinifyBtn
            // 
            this.MinifyBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.MinifyBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinifyBtn.Location = new System.Drawing.Point(997, 293);
            this.MinifyBtn.Name = "MinifyBtn";
            this.MinifyBtn.Size = new System.Drawing.Size(148, 37);
            this.MinifyBtn.TabIndex = 8;
            this.MinifyBtn.Text = "Minify";
            this.MinifyBtn.UseVisualStyleBackColor = false;
            // 
            // BeautyBtn
            // 
            this.BeautyBtn.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BeautyBtn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeautyBtn.Location = new System.Drawing.Point(997, 383);
            this.BeautyBtn.Name = "BeautyBtn";
            this.BeautyBtn.Size = new System.Drawing.Size(148, 37);
            this.BeautyBtn.TabIndex = 9;
            this.BeautyBtn.Text = "Beauty";
            this.BeautyBtn.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ui_design.Properties.Resources.photo_1542903660_eedba2cda473;
            this.ClientSize = new System.Drawing.Size(1185, 613);
            this.Controls.Add(this.BeautyBtn);
            this.Controls.Add(this.MinifyBtn);
            this.Controls.Add(this.CompressBtn);
            this.Controls.Add(this.CorrectBtn);
            this.Controls.Add(this.ValidateBtn);
            this.Controls.Add(this.JsonBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.browse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "XML project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button JsonBtn;
        private System.Windows.Forms.Button ValidateBtn;
        private System.Windows.Forms.Button CorrectBtn;
        private System.Windows.Forms.Button CompressBtn;
        private System.Windows.Forms.Button MinifyBtn;
        private System.Windows.Forms.Button BeautyBtn;
    }
}

