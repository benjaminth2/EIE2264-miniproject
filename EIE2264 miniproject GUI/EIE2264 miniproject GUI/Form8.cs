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
    public partial class Form8 : Form
    {
        public Form8(bool cheatmode)
        {
            InitializeComponent();
            label1.Visible = cheatmode;
            textBox10.Visible = cheatmode;
            button3.Visible = cheatmode;
            UpdateToggleButton();
            FetchSettings();
            Form2.changesetting = false;
        }

        void FetchSettings()
        {
            textBox1.Text = collection.settings[3, 0].ToString();
            textBox2.Text = collection.settings[3, 1].ToString();
            textBox3.Text = collection.settings[2, 0].ToString();
            textBox4.Text = collection.settings[2, 1].ToString();
            textBox5.Text = collection.settings[1, 0].ToString();
            textBox6.Text = collection.settings[1, 1].ToString();
            textBox7.Text = collection.settings[0, 0].ToString();
            textBox8.Text = collection.settings[0, 1].ToString();
            textBox9.Text = collection.settings[4, 0].ToString();
            textBox10.Text = collection.dllHighScoreOfPlayer().ToString();
            textBox11.Text = collection.settings[5, 0].ToString();
        }

        void UpdateToggleButton()
        {
            Form2.changesetting = true;
            allow.Enabled = false;
            deny.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            if (collection.settings[4, 1] == 0)
            {
                allow.Enabled = true;
            }
            else
            {
                deny.Enabled = true;
            }
            switch(collection.settings[5, 1])
            {
                case 0:
                    button1.Enabled = false;
                    break;
                case 1:
                    button2.Enabled = false;
                    break;
                case 2:
                    button3.Enabled = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collection.settings[4, 1] = 1;
            UpdateToggleButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            collection.settings[4, 1] = 0;
            UpdateToggleButton();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2.changesetting = true;
            TextBox[] textBox = new TextBox[10] 
            {
                textBox1, textBox3, textBox5, textBox7,
                textBox2, textBox4, textBox6, textBox8,
                textBox9, textBox11
            };
            int[] setting = new int[10];
            for(int i = 0;i < 10; i++)
            {
                if (!(Int32.TryParse(textBox[i].Text,out setting[i])))
                {
                    MessageBox.Show("All input should be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            for(int i = 0;i < 2; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    if(setting[i] < 0)
                    {
                        MessageBox.Show("All input should be a positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    switch (i)
                    {
                        case 0:
                            if(setting[i] >= setting[i + 1])
                            {
                                MessageBox.Show("Trigger in round should increasesd in each tier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;
                        case 1:
                            if (setting[i+4] < setting[i + 5])
                            {
                                MessageBox.Show("Time allow in round should decrease in each tier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            break;
                    }
                }
            }

            if (setting[8] < 1)
            {
                MessageBox.Show("Score add should be a non zero positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (setting[9] < 1)
            {
                MessageBox.Show("Number of round should be a non zero positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            collection.settings[3, 0] = setting[0];
            collection.settings[2, 0] = setting[1];
            collection.settings[1, 0] = setting[2];
            collection.settings[0, 0] = setting[3];
            collection.settings[3, 1] = setting[4];
            collection.settings[2, 1] = setting[5];
            collection.settings[1, 1] = setting[6];
            collection.settings[0, 1] = setting[7];
            collection.settings[4, 0] = setting[8];
            collection.settings[5, 0] = setting[9];
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int score;
            if (!(Int32.TryParse(textBox10.Text, out score)))
            {
                MessageBox.Show("Highscore should be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (score < 0)
            {
                MessageBox.Show("Highscore should be a positive integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            collection.dllEditHighScore(score);
            MessageBox.Show("Highscore of " + collection.ReadFromTempText() + " is changed to " + score.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            collection.settings[5, 1] = 2;
            UpdateToggleButton();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            collection.settings[5, 1] = 0;
            UpdateToggleButton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            collection.settings[5, 1] = 1;
            UpdateToggleButton();
        }
    }
}
