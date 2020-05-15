namespace EIE2264_miniproject_GUI
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Eng_t = new System.Windows.Forms.RadioButton();
            this.Eng_s = new System.Windows.Forms.RadioButton();
            this.Math_t = new System.Windows.Forms.RadioButton();
            this.Math_s = new System.Windows.Forms.RadioButton();
            this.Chi_t = new System.Windows.Forms.RadioButton();
            this.Chi_s = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Switch = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.HighScore = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Chi_p = new System.Windows.Forms.RadioButton();
            this.Math_p = new System.Windows.Forms.RadioButton();
            this.Eng_p = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.Coun_p = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.Coun_s = new System.Windows.Forms.RadioButton();
            this.Coun_t = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chinese game";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mathematics game";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "English game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(100, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Score Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(167, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Time Mode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Coun_t, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.Coun_s, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.Eng_t, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.Eng_s, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.Math_t, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Math_s, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Chi_t, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Chi_s, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Chi_p, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Math_p, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.Eng_p, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.Coun_p, 3, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 192);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // Eng_t
            // 
            this.Eng_t.AutoSize = true;
            this.Eng_t.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eng_t.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eng_t.Location = new System.Drawing.Point(167, 83);
            this.Eng_t.Name = "Eng_t";
            this.Eng_t.Size = new System.Drawing.Size(59, 13);
            this.Eng_t.TabIndex = 14;
            this.Eng_t.TabStop = true;
            this.Eng_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eng_t.UseVisualStyleBackColor = true;
            // 
            // Eng_s
            // 
            this.Eng_s.AutoSize = true;
            this.Eng_s.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eng_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Eng_s.Location = new System.Drawing.Point(100, 83);
            this.Eng_s.Name = "Eng_s";
            this.Eng_s.Size = new System.Drawing.Size(61, 13);
            this.Eng_s.TabIndex = 14;
            this.Eng_s.TabStop = true;
            this.Eng_s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Eng_s.UseVisualStyleBackColor = true;
            // 
            // Math_t
            // 
            this.Math_t.AutoSize = true;
            this.Math_t.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Math_t.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Math_t.Location = new System.Drawing.Point(167, 54);
            this.Math_t.Name = "Math_t";
            this.Math_t.Size = new System.Drawing.Size(59, 13);
            this.Math_t.TabIndex = 14;
            this.Math_t.TabStop = true;
            this.Math_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Math_t.UseVisualStyleBackColor = true;
            // 
            // Math_s
            // 
            this.Math_s.AutoSize = true;
            this.Math_s.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Math_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Math_s.Location = new System.Drawing.Point(100, 54);
            this.Math_s.Name = "Math_s";
            this.Math_s.Size = new System.Drawing.Size(61, 13);
            this.Math_s.TabIndex = 14;
            this.Math_s.TabStop = true;
            this.Math_s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Math_s.UseVisualStyleBackColor = true;
            // 
            // Chi_t
            // 
            this.Chi_t.AutoSize = true;
            this.Chi_t.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chi_t.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chi_t.Location = new System.Drawing.Point(167, 25);
            this.Chi_t.Name = "Chi_t";
            this.Chi_t.Size = new System.Drawing.Size(59, 13);
            this.Chi_t.TabIndex = 11;
            this.Chi_t.TabStop = true;
            this.Chi_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chi_t.UseVisualStyleBackColor = true;
            // 
            // Chi_s
            // 
            this.Chi_s.AutoSize = true;
            this.Chi_s.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chi_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chi_s.Location = new System.Drawing.Point(100, 25);
            this.Chi_s.Name = "Chi_s";
            this.Chi_s.Size = new System.Drawing.Size(61, 13);
            this.Chi_s.TabIndex = 9;
            this.Chi_s.TabStop = true;
            this.Chi_s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Chi_s.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.HighScore, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.Quit, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.Switch, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Play, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(31, 131);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(243, 58);
            this.tableLayoutPanel2.TabIndex = 15;
            // 
            // Switch
            // 
            this.Switch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.Switch, 3);
            this.Switch.Location = new System.Drawing.Point(23, 32);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(75, 23);
            this.Switch.TabIndex = 0;
            this.Switch.Text = "Switch User";
            this.Switch.UseVisualStyleBackColor = true;
            this.Switch.Click += new System.EventHandler(this.Switch_Click);
            // 
            // Quit
            // 
            this.Quit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.Quit, 3);
            this.Quit.Location = new System.Drawing.Point(144, 32);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 2;
            this.Quit.Text = "Quit";
            this.Quit.UseMnemonic = false;
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Play
            // 
            this.Play.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.Play, 2);
            this.Play.Location = new System.Drawing.Point(3, 3);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 23);
            this.Play.TabIndex = 1;
            this.Play.Text = "Play!";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // HighScore
            // 
            this.HighScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.HighScore, 2);
            this.HighScore.Location = new System.Drawing.Point(84, 3);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(75, 23);
            this.HighScore.TabIndex = 3;
            this.HighScore.Text = "High Score";
            this.HighScore.UseVisualStyleBackColor = true;
            this.HighScore.Click += new System.EventHandler(this.HighScore_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 12);
            this.label7.TabIndex = 16;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.CheatMode_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(232, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "Practice Mode";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chi_p
            // 
            this.Chi_p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Chi_p.AutoSize = true;
            this.Chi_p.Location = new System.Drawing.Point(260, 25);
            this.Chi_p.Name = "Chi_p";
            this.Chi_p.Size = new System.Drawing.Size(14, 13);
            this.Chi_p.TabIndex = 18;
            this.Chi_p.TabStop = true;
            this.Chi_p.UseVisualStyleBackColor = true;
            // 
            // Math_p
            // 
            this.Math_p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Math_p.AutoSize = true;
            this.Math_p.Location = new System.Drawing.Point(260, 54);
            this.Math_p.Name = "Math_p";
            this.Math_p.Size = new System.Drawing.Size(14, 13);
            this.Math_p.TabIndex = 19;
            this.Math_p.TabStop = true;
            this.Math_p.UseVisualStyleBackColor = true;
            // 
            // Eng_p
            // 
            this.Eng_p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Eng_p.AutoSize = true;
            this.Eng_p.Location = new System.Drawing.Point(260, 83);
            this.Eng_p.Name = "Eng_p";
            this.Eng_p.Size = new System.Drawing.Size(14, 13);
            this.Eng_p.TabIndex = 20;
            this.Eng_p.TabStop = true;
            this.Eng_p.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.button1, 2);
            this.button1.Location = new System.Drawing.Point(165, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Coun_p
            // 
            this.Coun_p.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Coun_p.AutoSize = true;
            this.Coun_p.Location = new System.Drawing.Point(260, 112);
            this.Coun_p.Name = "Coun_p";
            this.Coun_p.Size = new System.Drawing.Size(14, 13);
            this.Coun_p.TabIndex = 21;
            this.Coun_p.TabStop = true;
            this.Coun_p.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Country game";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Coun_s
            // 
            this.Coun_s.AutoSize = true;
            this.Coun_s.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coun_s.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Coun_s.Location = new System.Drawing.Point(100, 112);
            this.Coun_s.Name = "Coun_s";
            this.Coun_s.Size = new System.Drawing.Size(61, 13);
            this.Coun_s.TabIndex = 14;
            this.Coun_s.TabStop = true;
            this.Coun_s.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coun_s.UseVisualStyleBackColor = true;
            // 
            // Coun_t
            // 
            this.Coun_t.AutoSize = true;
            this.Coun_t.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coun_t.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Coun_t.Location = new System.Drawing.Point(167, 112);
            this.Coun_t.Name = "Coun_t";
            this.Coun_t.Size = new System.Drawing.Size(59, 13);
            this.Coun_t.TabIndex = 13;
            this.Coun_t.TabStop = true;
            this.Coun_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Coun_t.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AcceptButton = this.Play;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(791, 247);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Menu";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton Eng_t;
        private System.Windows.Forms.RadioButton Eng_s;
        private System.Windows.Forms.RadioButton Math_t;
        private System.Windows.Forms.RadioButton Math_s;
        private System.Windows.Forms.RadioButton Chi_t;
        private System.Windows.Forms.RadioButton Chi_s;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Switch;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button HighScore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton Chi_p;
        private System.Windows.Forms.RadioButton Math_p;
        private System.Windows.Forms.RadioButton Eng_p;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton Coun_t;
        private System.Windows.Forms.RadioButton Coun_s;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Coun_p;
    }
}