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
    public partial class Form6 : Form
    {
        Bitmap[] EngChar = new Bitmap[26]
        {
            Properties.Resources.A,
            Properties.Resources.B,
            Properties.Resources.C,
            Properties.Resources.D,
            Properties.Resources.E,
            Properties.Resources.F,
            Properties.Resources.G,
            Properties.Resources.H,
            Properties.Resources.I,
            Properties.Resources.J,
            Properties.Resources.K,
            Properties.Resources.L,
            Properties.Resources.M,
            Properties.Resources.N,
            Properties.Resources.O,
            Properties.Resources.P,
            Properties.Resources.Q,
            Properties.Resources.R,
            Properties.Resources.S,
            Properties.Resources.T,
            Properties.Resources.U,
            Properties.Resources.V,
            Properties.Resources.W,
            Properties.Resources.X,
            Properties.Resources.Y,
            Properties.Resources.Z,
        };
        int mode;
        bool press;
        bool cheat;
        PictureBox[] cheatpictureBoxes;
        void ResetAll()
        {
            timer1.Stop();
            collection.CurTime = 0;
            for (int i = 0; i < 4; i++)
            {
                collection.pictureBoxes[1, i].Location = collection.OrgLoc[i];
            }

            for (int i = 0; i < 4; i++)
            {
                cheatpictureBoxes[i].Visible = false;
            }
        }

        void setquestion()
        {
            ResetAll();
            collection.CurRound++;
            int RandNum, RandNum2;
            char[] question = collection.ReadFromAnswer(1).ToCharArray();
            int[,] IntQuestion = new int[2, 4];
            bool Indicator = false;
            for (int i = 0; i < 4; i++)
            {
                IntQuestion[0, i] = question[i] - 'a';
            }

            RandNum = collection.dllGetRandomNumber() % 4;
            RandNum2 = (collection.dllGetRandomNumber() % 11) % 4;
            if (RandNum2 == RandNum)
            {
                RandNum2 = (RandNum2 + 1) % 4;
            }

            if (cheat)
            {
                cheatpictureBoxes[RandNum].Image = EngChar[IntQuestion[0, RandNum]];
                cheatpictureBoxes[RandNum].Visible = true;
                cheatpictureBoxes[RandNum2].Image = EngChar[IntQuestion[0, RandNum2]];
                cheatpictureBoxes[RandNum2].Visible = true;
            }

            IntQuestion[1, 0] = IntQuestion[0, RandNum];
            IntQuestion[1, 1] = IntQuestion[0, RandNum2];
            IntQuestion[0, RandNum] = -1;
            IntQuestion[0, RandNum2] = -1;

            do
            {
                RandNum = collection.dllGetRandomNumber() % 26;
                RandNum2 = (collection.dllGetRandomNumber() % 51) / 2;
            } while (RandNum == RandNum2 || RandNum == IntQuestion[1, 0] || RandNum2 == IntQuestion[1, 0] || RandNum == IntQuestion[1, 1] || RandNum2 == IntQuestion[1, 1]);

            IntQuestion[1, 2] = RandNum;
            IntQuestion[1, 3] = RandNum2;

            for (int i = 3; i > 0; i--)
            {
                RandNum = collection.dllGetRandomNumber() % i;
                if (RandNum != i)
                {
                    int temp = IntQuestion[1, i];
                    IntQuestion[1, i] = IntQuestion[1, RandNum];
                    IntQuestion[1, RandNum] = temp;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (IntQuestion[i, j] != -1)
                    {
                        collection.pictureBoxes[i, j].Image = EngChar[IntQuestion[i, j]];
                        char CharToWrite = Convert.ToChar(IntQuestion[i, j] + 97);
                        collection.pictureBoxes[i, j].Tag = CharToWrite;
                        collection.pictureBoxes[i, j].BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        if (Indicator)
                        {
                            collection.SpaceToFill[1] = collection.pictureBoxes[i, j];
                        }
                        else
                        {
                            collection.SpaceToFill[0] = collection.pictureBoxes[i, j];
                            Indicator = true;
                        }
                        collection.pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                        collection.pictureBoxes[i, j].Image = null;
                        collection.pictureBoxes[i, j].Tag = ' ';
                    }
                }
            }
            if (mode != 2)
            {
                timer1.Start();
            }
        }

        public Form6(int Mode, bool cheatmode)
        {
            InitializeComponent();
            mode = Mode;
            cheat = cheatmode;
            Size = GetPreferredSize(Size);
            collection.halfsize = new Size(r1c1.Size.Width / 2, r1c1.Size.Height / 2);
            timer1.Stop();
            cheatpictureBoxes = new PictureBox[4]
            {
                r1c1_cheat,r1c2_cheat,r1c3_cheat,r1c4_cheat
            };
            collection.pictureBoxes = new PictureBox[2, 4]
            {
                {r1c1,r1c2,r1c3,r1c4 },
                {r2c1,r2c2,r2c3,r2c4 }
            };
            for (int i = 0; i < 4; i++)
            {
                collection.OrgLoc[i] = collection.pictureBoxes[1, i].Location;
            }
            collection.TotalScore = 0;
            collection.CurTime = 0;
            collection.CurRound = -1;
            setquestion();
        }
        
        void endgame()
        {
            timer1.Stop();
            string promptstr = "";
            switch (mode)
            {
                case 1:
                    promptstr = "Total Score: " + collection.TotalScore.ToString();
                    break;
                case 0:
                    promptstr = "Total Round: " + ((collection.TotalScore / collection.settings[4, 0]) + 1).ToString();
                    break;
            }
            MessageBox.Show(promptstr);
            collection.dllUpdateHighScore(collection.TotalScore);
            this.Close();
        }

        void CheckCorrect()
        {
            switch (collection.CheckCorrect(2, mode))
            {
                case 1:
                    setquestion();
                    break;
                case 2:
                    endgame();
                    break;
            }
        }

        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), collection.halfsize);
        }


        bool MouseUphandler(PictureBox Picturebox)
        {
            if (collection.MouseUphandler(Picturebox,2))
            {
                return true;
            }
            else
            {
                CheckCorrect();
                return false;
            }
        }

        private void r2c4_MouseDown(object sender, MouseEventArgs e)
        {
            press = true;
        }
        private void r2c4_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                MouseMovehandler((PictureBox)sender);
            }
        }
        private void r2c4_MouseUp(object sender, MouseEventArgs e)
        {
            press = false;
            if (MouseUphandler((PictureBox)sender))
            {
                r2c4.Location = collection.OrgLoc[3];
            }
        }


        private void r2c3_MouseDown(object sender, MouseEventArgs e)
        {
            press = true;
        }
        private void r2c3_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                MouseMovehandler((PictureBox)sender);
            }
        }
        private void r2c3_MouseUp(object sender, MouseEventArgs e)
        {
            press = false;
            if (MouseUphandler((PictureBox)sender))
            {
                r2c3.Location = collection.OrgLoc[2];
            }
        }


        private void r2c2_MouseDown(object sender, MouseEventArgs e)
        {
            press = true;
        }
        private void r2c2_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                MouseMovehandler((PictureBox)sender);
            }
        }
        private void r2c2_MouseUp(object sender, MouseEventArgs e)
        {
            press = false;
            if (MouseUphandler((PictureBox)sender))
            {
                r2c2.Location = collection.OrgLoc[1];
            }
        }



        private void r2c1_MouseDown(object sender, MouseEventArgs e)
        {
            press = true;
        }
        private void r2c1_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                MouseMovehandler((PictureBox)sender);
            }
        }
        private void r2c1_MouseUp(object sender, MouseEventArgs e)
        {
            press = false;
            if (MouseUphandler((PictureBox)sender))
            {
                r2c1.Location = collection.OrgLoc[0];
            }
        }
        
        private void FormClosing_event(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            collection.CurTime++;
            TimeDisplay.Text = "Time passed: " + collection.CurTime.ToString();
            if (mode == 0)
            {
                if (collection.DetEndForMode0())
                {
                    endgame();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collection.CurRound--;
            collection.CurTime = 0;
            setquestion();
        }
    }
}
