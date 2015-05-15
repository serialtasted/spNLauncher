namespace spNLauncherArma3.Controls
{
    partial class PackBlock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chb_useThis = new System.Windows.Forms.CheckBox();
            this.pic_packThumb = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_packThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(263, 17);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(63, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "%Title%";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txt_title);
            this.panel1.Controls.Add(this.chb_useThis);
            this.panel1.Controls.Add(this.pic_packThumb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 174);
            this.panel1.TabIndex = 6;
            // 
            // chb_useThis
            // 
            this.chb_useThis.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_useThis.AutoSize = true;
            this.chb_useThis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chb_useThis.Location = new System.Drawing.Point(759, 15);
            this.chb_useThis.MinimumSize = new System.Drawing.Size(90, 30);
            this.chb_useThis.Name = "chb_useThis";
            this.chb_useThis.Size = new System.Drawing.Size(90, 30);
            this.chb_useThis.TabIndex = 8;
            this.chb_useThis.Text = "Use this pack";
            this.chb_useThis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_useThis.UseVisualStyleBackColor = true;
            // 
            // pic_packThumb
            // 
            this.pic_packThumb.Location = new System.Drawing.Point(12, 15);
            this.pic_packThumb.Name = "pic_packThumb";
            this.pic_packThumb.Size = new System.Drawing.Size(245, 144);
            this.pic_packThumb.TabIndex = 7;
            this.pic_packThumb.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(263, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(586, 108);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(263, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "%Version%";
            // 
            // PackBlock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(860, 109);
            this.Name = "PackBlock";
            this.Size = new System.Drawing.Size(860, 174);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_packThumb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_packThumb;
        private System.Windows.Forms.CheckBox chb_useThis;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}
