namespace EIE2264_miniproject_GUI
{
    partial class Form4
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
            this.TimeDisplay = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.r1c1_cheat = new System.Windows.Forms.PictureBox();
            this.r2c4 = new System.Windows.Forms.PictureBox();
            this.r2c1 = new System.Windows.Forms.PictureBox();
            this.r2c3 = new System.Windows.Forms.PictureBox();
            this.r2c2 = new System.Windows.Forms.PictureBox();
            this.a_10 = new System.Windows.Forms.PictureBox();
            this.a_1 = new System.Windows.Forms.PictureBox();
            this.c_1 = new System.Windows.Forms.PictureBox();
            this.Ans = new System.Windows.Forms.PictureBox();
            this.IntB = new System.Windows.Forms.PictureBox();
            this.c_10 = new System.Windows.Forms.PictureBox();
            this.equal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.r1c1_cheat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equal)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeDisplay.Enabled = false;
            this.TimeDisplay.Location = new System.Drawing.Point(96, 71);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.ReadOnly = true;
            this.TimeDisplay.Size = new System.Drawing.Size(218, 15);
            this.TimeDisplay.TabIndex = 21;
            this.TimeDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // r1c1_cheat
            // 
            this.r1c1_cheat.Location = new System.Drawing.Point(140, 28);
            this.r1c1_cheat.Margin = new System.Windows.Forms.Padding(15);
            this.r1c1_cheat.Name = "r1c1_cheat";
            this.r1c1_cheat.Size = new System.Drawing.Size(25, 25);
            this.r1c1_cheat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r1c1_cheat.TabIndex = 29;
            this.r1c1_cheat.TabStop = false;
            // 
            // r2c4
            // 
            this.r2c4.Image = global::EIE2264_miniproject_GUI.Properties.Resources.DIV;
            this.r2c4.Location = new System.Drawing.Point(264, 92);
            this.r2c4.Name = "r2c4";
            this.r2c4.Size = new System.Drawing.Size(50, 50);
            this.r2c4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r2c4.TabIndex = 20;
            this.r2c4.TabStop = false;
            this.r2c4.Tag = "DIV";
            this.r2c4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.r2c4_MouseDown);
            this.r2c4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.r2c4_MouseMove);
            this.r2c4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.r2c4_MouseUp);
            // 
            // r2c1
            // 
            this.r2c1.Image = global::EIE2264_miniproject_GUI.Properties.Resources.ADD;
            this.r2c1.Location = new System.Drawing.Point(96, 92);
            this.r2c1.Name = "r2c1";
            this.r2c1.Size = new System.Drawing.Size(50, 50);
            this.r2c1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r2c1.TabIndex = 17;
            this.r2c1.TabStop = false;
            this.r2c1.Tag = "ADD";
            this.r2c1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.r2c1_MouseDown);
            this.r2c1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.r2c1_MouseMove);
            this.r2c1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.r2c1_MouseUp);
            // 
            // r2c3
            // 
            this.r2c3.Image = global::EIE2264_miniproject_GUI.Properties.Resources.MUL;
            this.r2c3.Location = new System.Drawing.Point(208, 92);
            this.r2c3.Name = "r2c3";
            this.r2c3.Size = new System.Drawing.Size(50, 50);
            this.r2c3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r2c3.TabIndex = 19;
            this.r2c3.TabStop = false;
            this.r2c3.Tag = "MUL";
            this.r2c3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.r2c3_MouseDown);
            this.r2c3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.r2c3_MouseMove);
            this.r2c3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.r2c3_MouseUp);
            // 
            // r2c2
            // 
            this.r2c2.Image = global::EIE2264_miniproject_GUI.Properties.Resources.SUB;
            this.r2c2.Location = new System.Drawing.Point(152, 92);
            this.r2c2.Name = "r2c2";
            this.r2c2.Size = new System.Drawing.Size(50, 50);
            this.r2c2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.r2c2.TabIndex = 18;
            this.r2c2.TabStop = false;
            this.r2c2.Tag = "SUB";
            this.r2c2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.r2c2_MouseDown);
            this.r2c2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.r2c2_MouseMove);
            this.r2c2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.r2c2_MouseUp);
            // 
            // a_10
            // 
            this.a_10.Location = new System.Drawing.Point(15, 15);
            this.a_10.Name = "a_10";
            this.a_10.Size = new System.Drawing.Size(50, 50);
            this.a_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a_10.TabIndex = 22;
            this.a_10.TabStop = false;
            // 
            // a_1
            // 
            this.a_1.Location = new System.Drawing.Point(71, 15);
            this.a_1.Name = "a_1";
            this.a_1.Size = new System.Drawing.Size(50, 50);
            this.a_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.a_1.TabIndex = 23;
            this.a_1.TabStop = false;
            // 
            // c_1
            // 
            this.c_1.Location = new System.Drawing.Point(351, 15);
            this.c_1.Name = "c_1";
            this.c_1.Size = new System.Drawing.Size(50, 50);
            this.c_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.c_1.TabIndex = 27;
            this.c_1.TabStop = false;
            // 
            // Ans
            // 
            this.Ans.Location = new System.Drawing.Point(127, 15);
            this.Ans.Name = "Ans";
            this.Ans.Size = new System.Drawing.Size(50, 50);
            this.Ans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ans.TabIndex = 13;
            this.Ans.TabStop = false;
            // 
            // IntB
            // 
            this.IntB.Location = new System.Drawing.Point(183, 15);
            this.IntB.Name = "IntB";
            this.IntB.Size = new System.Drawing.Size(50, 50);
            this.IntB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IntB.TabIndex = 28;
            this.IntB.TabStop = false;
            // 
            // c_10
            // 
            this.c_10.Location = new System.Drawing.Point(295, 15);
            this.c_10.Name = "c_10";
            this.c_10.Size = new System.Drawing.Size(50, 50);
            this.c_10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.c_10.TabIndex = 26;
            this.c_10.TabStop = false;
            // 
            // equal
            // 
            this.equal.Image = global::EIE2264_miniproject_GUI.Properties.Resources.eq;
            this.equal.Location = new System.Drawing.Point(239, 15);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(50, 50);
            this.equal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.equal.TabIndex = 25;
            this.equal.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 450);
            this.Controls.Add(this.r2c4);
            this.Controls.Add(this.r2c1);
            this.Controls.Add(this.r2c3);
            this.Controls.Add(this.r2c2);
            this.Controls.Add(this.r1c1_cheat);
            this.Controls.Add(this.a_10);
            this.Controls.Add(this.a_1);
            this.Controls.Add(this.c_1);
            this.Controls.Add(this.Ans);
            this.Controls.Add(this.IntB);
            this.Controls.Add(this.c_10);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.TimeDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mathematics Game";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.r1c1_cheat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2c2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox r2c4;
        private System.Windows.Forms.PictureBox r2c3;
        private System.Windows.Forms.PictureBox r2c2;
        private System.Windows.Forms.PictureBox r2c1;
        private System.Windows.Forms.TextBox TimeDisplay;
        private System.Windows.Forms.PictureBox Ans;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox a_10;
        private System.Windows.Forms.PictureBox a_1;
        private System.Windows.Forms.PictureBox equal;
        private System.Windows.Forms.PictureBox c_10;
        private System.Windows.Forms.PictureBox c_1;
        private System.Windows.Forms.PictureBox IntB;
        private System.Windows.Forms.PictureBox r1c1_cheat;
    }
}