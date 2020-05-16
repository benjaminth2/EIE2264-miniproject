using System;
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
            Form2.act = 0;
            Size = GetPreferredSize(Size);
        }
        public bool Form1Execute = false;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox1.Text.ToCharArray()[0] != ' ')
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
            MessageBox.Show("Invalid username!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
