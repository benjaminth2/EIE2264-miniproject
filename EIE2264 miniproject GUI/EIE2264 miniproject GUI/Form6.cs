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
        int CurScore = 0;
        int CurRound = 0;
        int TotalScore = 0;
        int mode;
        bool press;
        bool cheat;
        private System.Drawing.Size halfsize;
        PictureBox[] SpaceToFill = new PictureBox[2];
        Point[] OrgLoc = new Point[4];
        PictureBox[] cheatpictureBoxes;

        void ResetAll()
        {
            timer1.Stop();
            CurScore = 0;
            SpaceToFill = new PictureBox[2];
            r2c1.Location = OrgLoc[0];
            r2c2.Location = OrgLoc[1];
            r2c3.Location = OrgLoc[2];
            r2c4.Location = OrgLoc[3];

            r1c1.Image = null;
            r1c1.BorderStyle = BorderStyle.None;
            r1c2.Image = null;
            r1c2.BorderStyle = BorderStyle.None;
            r1c3.Image = null;
            r1c3.BorderStyle = BorderStyle.None;
            r1c4.Image = null;
            r1c4.BorderStyle = BorderStyle.None;
            for (int i = 0; i < 4; i++)
            {
                cheatpictureBoxes[i].Visible = false;
            }
        }

        void setquestion()
        {
            ResetAll();
            int RandNum, RandNum2;
            char[] question = collection.ReadFromAnswer(1).ToCharArray();
            int[,] IntQuestion = new int[2, 4];
            bool Indicator = false;
            PictureBox[,] pictureBoxes = new PictureBox[2, 4]
            {
                {r1c1,r1c2,r1c3,r1c4 },
                {r2c1,r2c2,r2c3,r2c4 }
            };
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
                        pictureBoxes[i, j].Image = EngChar[IntQuestion[i, j]];
                        char CharToWrite = Convert.ToChar(IntQuestion[i, j] + 97);
                        pictureBoxes[i, j].Tag = CharToWrite;
                        pictureBoxes[i, j].BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        if (Indicator)
                        {
                            SpaceToFill[1] = pictureBoxes[i, j];
                        }
                        else
                        {
                            SpaceToFill[0] = pictureBoxes[i, j];
                            Indicator = true;
                        }
                        pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                        pictureBoxes[i, j].Tag = ' ';
                    }
                }
            }
            if(mode != 2)
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
            halfsize = new Size(r1c1.Size.Width / 2, r1c1.Size.Height / 2);
            timer1.Stop();
            OrgLoc[0] = r2c1.Location;
            OrgLoc[1] = r2c2.Location;
            OrgLoc[2] = r2c3.Location;
            OrgLoc[3] = r2c4.Location;
            cheatpictureBoxes = new PictureBox[4]
            {
                r1c1_cheat,r1c2_cheat,r1c3_cheat,r1c4_cheat
            };
            setquestion();
        }

        void CheckCorrect()
        {
            if (r1c1.Tag.ToString() != " " && r1c2.Tag.ToString() != " " && r1c3.Tag.ToString() != " " && r1c4.Tag.ToString() != " ")
            {
                if (collection.WriteToAnsText(r1c1.Tag.ToString(), r1c2.Tag.ToString(), r1c3.Tag.ToString(), r1c4.Tag.ToString(), 2) == 1)
                {
                    if (mode == 0)
                    {
                        TotalScore += 10;
                    }
                    if (mode == 1)
                    {
                        TotalScore += CurScore;
                    }
                    if (mode == 2)
                    {
                        setquestion();
                    }
                }
                else
                {
                    if (mode == 0)
                    {
                        timer1.Stop();
                        MessageBox.Show("Total Score: " + TotalScore.ToString());
                        collection.dllUpdateHighScore(TotalScore);
                        this.Close();
                    }
                }
                CurRound++;
                if (CurRound == 3 && mode == 1)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: " + TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
                if (mode != 2)
                {
                    setquestion();
                }
            }
        }

        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), halfsize);
        }

        bool MouseUphandler(PictureBox Picturebox)
        {
            for (int i = 0; i < 2; i++)
            {
                if ((Picturebox.Location.X + halfsize.Width) >= SpaceToFill[i].Location.X &&
    (Picturebox.Location.X + halfsize.Width) <= (SpaceToFill[i].Location.X + SpaceToFill[i].Size.Width) &&
    (Picturebox.Location.Y + halfsize.Height) >= SpaceToFill[i].Location.Y &&
     (Picturebox.Location.Y + halfsize.Height) <= (SpaceToFill[i].Location.Y + SpaceToFill[i].Size.Height))
                {
                    Picturebox.Location = SpaceToFill[i].Location;
                    SpaceToFill[i].Tag = Picturebox.Tag;
                    CheckCorrect();
                    return false;
                }
            }
            return true;
        }

        private void r2c4_MouseDown(object sender, MouseEventArgs e)
        {
            press = true;
        }
        private void r2c4_MouseMove(object sender, MouseEventArgs e)
        {
            if (press)
            {
                PictureBox Picturebox = (PictureBox)sender;
                MouseMovehandler(Picturebox);
            }
        }
        private void r2c4_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox Picturebox = (PictureBox)sender;
            press = false;
            if (MouseUphandler(Picturebox))
            {
                r2c4.Location = OrgLoc[3];
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
                PictureBox Picturebox = (PictureBox)sender;
                MouseMovehandler(Picturebox);
            }
        }
        private void r2c3_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox Picturebox = (PictureBox)sender;
            press = false;
            if (MouseUphandler(Picturebox))
            {
                r2c3.Location = OrgLoc[2];
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
                PictureBox Picturebox = (PictureBox)sender;
                MouseMovehandler(Picturebox);
            }
        }
        private void r2c2_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox Picturebox = (PictureBox)sender;
            press = false;
            if (MouseUphandler(Picturebox))
            {
                r2c2.Location = OrgLoc[1];
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
                PictureBox Picturebox = (PictureBox)sender;
                MouseMovehandler(Picturebox);
            }
        }
        private void r2c1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox Picturebox = (PictureBox)sender;
            press = false;
            if (MouseUphandler(Picturebox))
            {
                r2c1.Location = OrgLoc[0];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CurScore++;
            TimeDisplay.Text = "Time passed: " + CurScore.ToString();
            if (mode == 0)
            {
                if (CurRound > 15 && CurScore > 2)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: " + TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
                if (CurRound > 10 && CurScore > 3)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: " + TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
                if (CurRound > 5 && CurScore > 4)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: " + TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
                if (CurRound > 0 && CurScore > 5)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: " + TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
            }
        }
    }
}
