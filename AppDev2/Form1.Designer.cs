namespace AppDev2
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
            this.label1 = new System.Windows.Forms.Label();
            this.ServiceDateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServiceTimeBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TemplateDateBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.ThemeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TemplateTimeBox = new System.Windows.Forms.TextBox();
            this.GO = new System.Windows.Forms.Button();
            this.SongLeaderBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TemplateList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Date";
            // 
            // ServiceDateBox
            // 
            this.ServiceDateBox.Location = new System.Drawing.Point(194, 43);
            this.ServiceDateBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServiceDateBox.Name = "ServiceDateBox";
            this.ServiceDateBox.Size = new System.Drawing.Size(148, 26);
            this.ServiceDateBox.TabIndex = 1;
            this.ServiceDateBox.Text = "10/10/2000";
            this.ServiceDateBox.TextChanged += new System.EventHandler(this.ServiceDateBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Time";
            // 
            // ServiceTimeBox
            // 
            this.ServiceTimeBox.Location = new System.Drawing.Point(194, 102);
            this.ServiceTimeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServiceTimeBox.Name = "ServiceTimeBox";
            this.ServiceTimeBox.Size = new System.Drawing.Size(148, 26);
            this.ServiceTimeBox.TabIndex = 3;
            this.ServiceTimeBox.Text = "01:10:10 ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Template Date";
            // 
            // TemplateDateBox
            // 
            this.TemplateDateBox.Location = new System.Drawing.Point(194, 152);
            this.TemplateDateBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TemplateDateBox.Name = "TemplateDateBox";
            this.TemplateDateBox.Size = new System.Drawing.Size(148, 26);
            this.TemplateDateBox.TabIndex = 5;
            this.TemplateDateBox.Text = "10/03/2010";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 275);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Title";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(194, 275);
            this.TitleBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(148, 26);
            this.TitleBox.TabIndex = 7;
            // 
            // ThemeBox
            // 
            this.ThemeBox.Location = new System.Drawing.Point(194, 352);
            this.ThemeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ThemeBox.Name = "ThemeBox";
            this.ThemeBox.Size = new System.Drawing.Size(148, 26);
            this.ThemeBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 352);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Theme";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 425);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Songleader";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 218);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Template Time";
            // 
            // TemplateTimeBox
            // 
            this.TemplateTimeBox.Location = new System.Drawing.Point(194, 208);
            this.TemplateTimeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TemplateTimeBox.Name = "TemplateTimeBox";
            this.TemplateTimeBox.Size = new System.Drawing.Size(148, 26);
            this.TemplateTimeBox.TabIndex = 13;
            this.TemplateTimeBox.Text = "10:30:00 ";
            // 
            // GO
            // 
            this.GO.Location = new System.Drawing.Point(194, 489);
            this.GO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(112, 35);
            this.GO.TabIndex = 14;
            this.GO.Text = "Enter Data";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // SongLeaderBox
            // 
            this.SongLeaderBox.FormattingEnabled = true;
            this.SongLeaderBox.Location = new System.Drawing.Point(194, 425);
            this.SongLeaderBox.Name = "SongLeaderBox";
            this.SongLeaderBox.Size = new System.Drawing.Size(121, 28);
            this.SongLeaderBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(410, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Valid Dates";
            // 
            // TemplateList
            // 
            this.TemplateList.FormattingEnabled = true;
            this.TemplateList.ItemHeight = 20;
            this.TemplateList.Location = new System.Drawing.Point(414, 137);
            this.TemplateList.Name = "TemplateList";
            this.TemplateList.Size = new System.Drawing.Size(322, 324);
            this.TemplateList.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 543);
            this.Controls.Add(this.TemplateList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SongLeaderBox);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.TemplateTimeBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ThemeBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TemplateDateBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ServiceTimeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServiceDateBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "AppDev2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServiceDateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServiceTimeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TemplateDateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox ThemeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TemplateTimeBox;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.ComboBox SongLeaderBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox TemplateList;
    }
}

