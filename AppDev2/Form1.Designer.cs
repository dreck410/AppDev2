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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ServiceDateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServiceTimeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.ThemeBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GO = new System.Windows.Forms.Button();
            this.SongLeaderBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TemplateList = new System.Windows.Forms.ListBox();
            this.LastUsedSongsBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ServiceSongEventBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.importSongButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service Date";
            // 
            // ServiceDateBox
            // 
            this.ServiceDateBox.Location = new System.Drawing.Point(194, 71);
            this.ServiceDateBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServiceDateBox.Name = "ServiceDateBox";
            this.ServiceDateBox.Size = new System.Drawing.Size(148, 26);
            this.ServiceDateBox.TabIndex = 0;
            this.ServiceDateBox.Text = "10/10/2000";
            this.ServiceDateBox.TextChanged += new System.EventHandler(this.ServiceDateBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Service Time";
            // 
            // ServiceTimeBox
            // 
            this.ServiceTimeBox.Location = new System.Drawing.Point(194, 123);
            this.ServiceTimeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ServiceTimeBox.Name = "ServiceTimeBox";
            this.ServiceTimeBox.Size = new System.Drawing.Size(148, 26);
            this.ServiceTimeBox.TabIndex = 1;
            this.ServiceTimeBox.Text = "01:10:10 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Title";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(194, 188);
            this.TitleBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(148, 26);
            this.TitleBox.TabIndex = 2;
            // 
            // ThemeBox
            // 
            this.ThemeBox.Location = new System.Drawing.Point(194, 255);
            this.ThemeBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ThemeBox.Name = "ThemeBox";
            this.ThemeBox.Size = new System.Drawing.Size(148, 26);
            this.ThemeBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Theme";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 327);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Songleader";
            // 
            // GO
            // 
            this.GO.Location = new System.Drawing.Point(194, 380);
            this.GO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GO.Name = "GO";
            this.GO.Size = new System.Drawing.Size(148, 35);
            this.GO.TabIndex = 6;
            this.GO.Text = "Enter Data";
            this.GO.UseVisualStyleBackColor = true;
            this.GO.Click += new System.EventHandler(this.GO_Click);
            // 
            // SongLeaderBox
            // 
            this.SongLeaderBox.FormattingEnabled = true;
            this.SongLeaderBox.Location = new System.Drawing.Point(194, 327);
            this.SongLeaderBox.Name = "SongLeaderBox";
            this.SongLeaderBox.Size = new System.Drawing.Size(148, 28);
            this.SongLeaderBox.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Select A Template Date";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // TemplateList
            // 
            this.TemplateList.FormattingEnabled = true;
            this.TemplateList.ItemHeight = 20;
            this.TemplateList.Location = new System.Drawing.Point(407, 71);
            this.TemplateList.Name = "TemplateList";
            this.TemplateList.Size = new System.Drawing.Size(271, 344);
            this.TemplateList.TabIndex = 5;
            this.TemplateList.SelectedIndexChanged += new System.EventHandler(this.TemplateList_SelectedIndexChanged);
            // 
            // LastUsedSongsBox
            // 
            this.LastUsedSongsBox.FormattingEnabled = true;
            this.LastUsedSongsBox.ItemHeight = 20;
            this.LastUsedSongsBox.Location = new System.Drawing.Point(31, 491);
            this.LastUsedSongsBox.Name = "LastUsedSongsBox";
            this.LastUsedSongsBox.Size = new System.Drawing.Size(380, 304);
            this.LastUsedSongsBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 468);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Songs";
            // 
            // ServiceSongEventBox
            // 
            this.ServiceSongEventBox.FormattingEnabled = true;
            this.ServiceSongEventBox.ItemHeight = 20;
            this.ServiceSongEventBox.Location = new System.Drawing.Point(541, 491);
            this.ServiceSongEventBox.Name = "ServiceSongEventBox";
            this.ServiceSongEventBox.Size = new System.Drawing.Size(630, 304);
            this.ServiceSongEventBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(537, 468);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Congregational Events";
            // 
            // importSongButton
            // 
            this.importSongButton.Location = new System.Drawing.Point(417, 611);
            this.importSongButton.Name = "importSongButton";
            this.importSongButton.Size = new System.Drawing.Size(118, 49);
            this.importSongButton.TabIndex = 9;
            this.importSongButton.Text = ">>";
            this.importSongButton.UseVisualStyleBackColor = true;
            this.importSongButton.Click += new System.EventHandler(this.importSongButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(429, 588);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Import Song";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(704, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 344);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 846);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.importSongButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ServiceSongEventBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LastUsedSongsBox);
            this.Controls.Add(this.TemplateList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SongLeaderBox);
            this.Controls.Add(this.GO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ThemeBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ServiceTimeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServiceDateBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "AppDev2";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServiceDateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServiceTimeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox ThemeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GO;
        private System.Windows.Forms.ComboBox SongLeaderBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox TemplateList;
        private System.Windows.Forms.ListBox LastUsedSongsBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox ServiceSongEventBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button importSongButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

