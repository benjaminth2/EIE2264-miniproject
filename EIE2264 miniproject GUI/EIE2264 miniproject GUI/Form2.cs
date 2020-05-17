//CHEUNG Tin Ho Benjamin, 19073365D
//FONG Cheuk Yin, 19049803D
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
    public partial class Form2 : Form
    {

        public static int act;
        public Form2()
        {
            InitializeComponent();
            this.Size = this.GetPreferredSize(this.Size);
            act = 0;
        }


        private void Switch_Click(object sender, EventArgs e)
        {
            act = 1;
            this.Close();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            TopMost = false;
            Form3 f3;
            Form4 f4;
            Form5 f5;
            Form6 f6;
            if (Chi_s.Checked)
            {
                f3 = new Form3(1,cheatmode);
                f3.ShowDialog();
            }
            if (Chi_t.Checked)
            {
                f3 = new Form3(0, cheatmode);
                f3.ShowDialog();
            }
            if (Chi_p.Checked)
            {
                f3 = new Form3(2, cheatmode);
                f3.ShowDialog();
            }

            if (Math_s.Checked)
            {
                f4 = new Form4(1, cheatmode);
                f4.ShowDialog();
            }
            if (Math_t.Checked)
            {
                f4 = new Form4(0, cheatmode);
                f4.ShowDialog();
            }
            if (Math_p.Checked)
            {
                f4 = new Form4(2, cheatmode);
                f4.ShowDialog();
            }

            if (Eng_s.Checked)
            {
                f5 = new Form5(1, cheatmode);
                f5.ShowDialog();
            }
            if (Eng_t.Checked)
            {
                f5 = new Form5(0, cheatmode);
                f5.ShowDialog();
            }
            if (Eng_p.Checked)
            {
                f5 = new Form5(2, cheatmode);
                f5.ShowDialog();
            }

            if (Coun_s.Checked)
            {
                f6 = new Form6(1, cheatmode);
                f6.ShowDialog();
            }
            if (Coun_t.Checked)
            {
                f6 = new Form6(0, cheatmode);
                f6.ShowDialog();
            }
            if (Coun_p.Checked)
            {
                f6 = new Form6(2, cheatmode);
                f6.ShowDialog();
            }

        }

        private void Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int click = 0;
        bool cheatmode = false;
        private void CheatMode_Click(object sender, EventArgs e)
        {
            if(click == 0)
            {
                timer1.Start();
            }
            click++;
            if(click == 5)
            {
                if (cheatmode)
                {
                    label7.Text = "";
                    cheatmode = false;
                }
                else
                {
                    label7.Text = "Cheat Mode: ON";
                    cheatmode = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (click != 1)
            {
                click = 0;
                timer1.Stop();
            }
        }

        private void HighScore_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 f8 = new Form8(cheatmode);
            f8.ShowDialog();
            if (changesetting)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        collection.dlleditconfig(i, j, collection.settings[i, j]);
                    }
                }
                MessageBox.Show("Setting saved!");
            }
        }
        public static bool changesetting;
    }
}
