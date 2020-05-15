﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EIE2264_miniproject_GUI
{
    public partial class Form1 : Form
    {
        int status;
        public Form1()
        {
            InitializeComponent();
            this.Size = this.GetPreferredSize(this.Size);
        }
        public bool Form1Execute = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                collection.WriteToTempText(textBox1.Text);
                status = collection.dllFindPlayerInList();
                string MessageContent = "Welcome, " + textBox1.Text + ".";
                if (status != -1)
                {
                    MessageContent = MessageContent + "Your best score is " + collection.dllHighScoreOfPlayer().ToString() + " points.";
                }
                MessageBox.Show(MessageContent, "Welcome!");
                Form1Execute = true;
                this.Close();
            }
            MessageBox.Show("Username cannot empty!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
