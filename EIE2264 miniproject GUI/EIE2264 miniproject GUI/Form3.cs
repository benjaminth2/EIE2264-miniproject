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
    public partial class Form3 : Form
    {
        Bitmap[,] ChiChar = new Bitmap[10, 4]
        {
            {Properties.Resources.安,Properties.Resources.富,Properties.Resources.尊,Properties.Resources.榮,},
            {Properties.Resources.愛,Properties.Resources.人,Properties.Resources.利,Properties.Resources.物,},
            {Properties.Resources.拔,Properties.Resources.苗,Properties.Resources.助,Properties.Resources.長,},
            {Properties.Resources.飽,Properties.Resources.食,Properties.Resources.暖,Properties.Resources.衣,},
            {Properties.Resources.抱,Properties.Resources.關,Properties.Resources.擊,Properties.Resources.柝,},
            {Properties.Resources.杯,Properties.Resources.水,Properties.Resources.車,Properties.Resources.薪,},
            {Properties.Resources.必,Properties.Resources.由,Properties.Resources.之,Properties.Resources.路,},
            {Properties.Resources.勃,Properties.Resources.然,Properties.Resources.變,Properties.Resources.色,},
            {Properties.Resources.白,Properties.Resources.駒,Properties.Resources.過,Properties.Resources.隙,},
            {Properties.Resources.鬼,Properties.Resources.斧,Properties.Resources.神,Properties.Resources.工,}
        };

        char[,] CharToWrite = new char[10, 4]
        {
            {'a','b' ,'c' ,'d' },
            {'f','g' ,'h' ,'i' },
            {'k','l' ,'m' ,'n' },
            {'p','q' ,'r' ,'s' },
            {'u','v' ,'w' ,'x' },
            {'A','B' ,'C' ,'D' },
            {'E','F' ,'G' ,'H' },
            {'I','J' ,'K' ,'L' },
            {'M','N' ,'O' ,'P' },
            {'R','S' ,'T' ,'U' }
        };

        Point[] CorrImgboxLocation = new Point[2];
        Size[] CorrImgSize = new Size[2];
        Bitmap[] CorrImg = new Bitmap[2];
        PictureBox[] SpaceToFill = new PictureBox[2];
        Point[,] OrgLoc = new Point[2, 4];

        PictureBox[] cheatpictureBoxes;

        int[] MaskForUsedQuestion = new int[10]
        {
            0,0,0,0,0,0,0,0,0,0
        };

        int[,,] MaskForCurGame = new int[2, 4, 2]
        {
            {{-1,-1 },{-1, -1},{-1,-1 },{-1,-1 } },
            {{-1,-1 },{-1, -1},{-1,-1 },{-1,-1 } }
        };//row col RowInCharArrColInCharArr

        int TotalScore = 0;
        int CurScore = 0;
        int CurRound = 0;

        void ResetAll()
        {
            timer1.Stop();
            CurScore = 0;
            CorrImgboxLocation = new Point[2];
            CorrImgSize = new Size[2];
            CorrImg = new Bitmap[2];
            SpaceToFill = new PictureBox[2];
            MaskForCurGame = new int[2, 4, 2]
            {
            {{-1,-1 },{-1, -1},{-1,-1 },{-1,-1 } },
            {{-1,-1 },{-1, -1},{-1,-1 },{-1,-1 } }
            };

            r2c1.Enabled = true;
            r2c1.Visible = true;
            r2c1.Location = OrgLoc[1, 0];
            r2c2.Enabled = true;
            r2c2.Visible = true;
            r2c2.Location = OrgLoc[1, 1];
            r2c3.Enabled = true;
            r2c3.Visible = true;
            r2c3.Location = OrgLoc[1, 2];
            r2c4.Enabled = true;
            r2c4.Visible = true;
            r2c4.Location = OrgLoc[1, 3];

            r1c1.Image = null;
            r1c2.Image = null;
            r1c3.Image = null;
            r1c4.Image = null;
            for(int i = 0;i < 4; i++)
            {
                cheatpictureBoxes[i].Visible = false;
            }
        }

        void setquestion()
        {
            ResetAll();

            int RandNum;
            int RandNum2;
            bool found = true;
            do
            {
                RandNum = collection.dllGetRandomNumber() % 10;
                if (MaskForUsedQuestion[RandNum] == 0)
                {
                    MaskForUsedQuestion[RandNum] = 5;
                    found = false;
                }
            } while (found);
            for (int i = 0; i < 10; i++)
            {
                if (MaskForUsedQuestion[i] > 0)
                {
                    MaskForUsedQuestion[i]--;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                MaskForCurGame[0, i, 0] = RandNum;
                MaskForCurGame[0, i, 1] = i;
            }
            RandNum = collection.dllGetRandomNumber() % 4;
            RandNum2 = collection.dllGetRandomNumber() % 4;
            if(RandNum2 == RandNum)
            {
                RandNum2 = (RandNum2 + 1) % 4;
            }
            if (cheat)
            {
                cheatpictureBoxes[RandNum].Visible = true;
                cheatpictureBoxes[RandNum].Image = ChiChar[MaskForCurGame[0, RandNum, 0], MaskForCurGame[0, RandNum, 1]];
                cheatpictureBoxes[RandNum2].Visible = true;
                cheatpictureBoxes[RandNum2].Image = ChiChar[MaskForCurGame[0, RandNum2, 0], MaskForCurGame[0, RandNum2, 1]];
            }
            CorrImg[0] = ChiChar[MaskForCurGame[0, RandNum, 0], MaskForCurGame[0, RandNum, 1]];
            CorrImg[1] = ChiChar[MaskForCurGame[0, RandNum2, 0], MaskForCurGame[0, RandNum2, 1]];
            MaskForCurGame[1, 0, 0] = MaskForCurGame[0, RandNum, 0];
            MaskForCurGame[1, 0, 1] = MaskForCurGame[0, RandNum, 1];
            MaskForCurGame[1, 1, 0] = MaskForCurGame[0, RandNum2, 0];
            MaskForCurGame[1, 1, 1] = MaskForCurGame[0, RandNum2, 1];
            MaskForCurGame[0, RandNum, 0] = -1;
            MaskForCurGame[0, RandNum, 1] = -1;
            MaskForCurGame[0, RandNum2, 0] = -1;
            MaskForCurGame[0, RandNum2, 1] = -1;
            do
            {
                RandNum = collection.dllGetRandomNumber() % 10;
                RandNum2 = collection.dllGetRandomNumber() % 10;
            } while (MaskForCurGame[1, 0, 0] == RandNum || MaskForCurGame[1, 0, 0] == RandNum2);
            MaskForCurGame[1, 2, 0] = RandNum;
            MaskForCurGame[1, 3, 0] = RandNum2;
            do
            {
                RandNum = collection.dllGetRandomNumber() % 4;
                RandNum2 = collection.dllGetRandomNumber() % 4;
            } while (MaskForCurGame[1, 2, 0] == MaskForCurGame[1, 3, 0] && RandNum == RandNum2);
            MaskForCurGame[1, 2, 1] = RandNum;
            MaskForCurGame[1, 3, 1] = RandNum2;
            
            for(int i = 3; i > 0; i--)
            {
                RandNum = collection.dllGetRandomNumber() % (i+1);
                if(RandNum != i)
                {
                    int tmp0 = MaskForCurGame[1, i, 0];
                    int tmp1 = MaskForCurGame[1, i, 1];
                    MaskForCurGame[1, i, 0] = MaskForCurGame[1, RandNum, 0];
                    MaskForCurGame[1, i, 1] = MaskForCurGame[1, RandNum, 1];
                    MaskForCurGame[1, RandNum, 0] = tmp0;
                    MaskForCurGame[1, RandNum, 1] = tmp1;
                }
            }
            bool setFirst = false;
            if(MaskForCurGame[0, 0, 0] != -1)
            {
                r1c1.Image = ChiChar[MaskForCurGame[0, 0, 0], MaskForCurGame[0, 0, 1]];
                r1c1.Tag = CharToWrite[MaskForCurGame[0, 0, 0], MaskForCurGame[0, 0, 1]];
                r1c1.BorderStyle = BorderStyle.None;
            }
            else
            {
                if (setFirst)
                {
                    CorrImgboxLocation[1] = r1c1.Location;
                    CorrImgSize[1] = r1c1.Size;
                    SpaceToFill[1] = r1c1;
                }
                else
                {
                    CorrImgboxLocation[0] = r1c1.Location;
                    CorrImgSize[0] = r1c1.Size;
                    SpaceToFill[0] = r1c1;
                    setFirst = true;
                }
                r1c1.BorderStyle = BorderStyle.FixedSingle;
                r1c1.Tag = ' ';
            }
            if (MaskForCurGame[0, 1, 0] != -1)
            {
                r1c2.Image = ChiChar[MaskForCurGame[0, 1, 0], MaskForCurGame[0, 1, 1]];
                r1c2.Tag = CharToWrite[MaskForCurGame[0, 1, 0], MaskForCurGame[0, 1, 1]];
                r1c2.BorderStyle = BorderStyle.None;
            }
            else
            {
                if (setFirst)
                {
                    CorrImgboxLocation[1] = r1c2.Location;
                    CorrImgSize[1] = r1c2.Size;
                    SpaceToFill[1] = r1c2;
                }
                else
                {
                    CorrImgboxLocation[0] = r1c2.Location;
                    CorrImgSize[0] = r1c2.Size;
                    SpaceToFill[0] = r1c2;
                    setFirst = true;
                }
                r1c2.BorderStyle = BorderStyle.FixedSingle;
                r1c2.Tag = ' ';
            }
            if (MaskForCurGame[0, 2, 0] != -1)
            {
                r1c3.Image = ChiChar[MaskForCurGame[0, 2, 0], MaskForCurGame[0, 2, 1]];
                r1c3.Tag = CharToWrite[MaskForCurGame[0, 2, 0], MaskForCurGame[0, 2, 1]];
                r1c3.BorderStyle = BorderStyle.None;
            }
            else
            {
                if (setFirst)
                {
                    CorrImgboxLocation[1] = r1c3.Location;
                    CorrImgSize[1] = r1c3.Size;
                    SpaceToFill[1] = r1c3;
                }
                else
                {
                    CorrImgboxLocation[0] = r1c3.Location;
                    CorrImgSize[0] = r1c3.Size;
                    SpaceToFill[0] = r1c3;
                    setFirst = true;
                }
                r1c3.BorderStyle = BorderStyle.FixedSingle;
                r1c3.Tag = ' ';
            }
            if (MaskForCurGame[0, 3, 0] != -1)
            {
                r1c4.Image = ChiChar[MaskForCurGame[0, 3, 0], MaskForCurGame[0, 3, 1]];
                r1c4.Tag = CharToWrite[MaskForCurGame[0, 3, 0], MaskForCurGame[0, 3, 1]];
                r1c4.BorderStyle = BorderStyle.None;
            }
            else
            {
                if (setFirst)
                {
                    CorrImgboxLocation[1] = r1c4.Location;
                    CorrImgSize[1] = r1c4.Size;
                    SpaceToFill[1] = r1c4;
                }
                else
                {
                    CorrImgboxLocation[0] = r1c4.Location;
                    CorrImgSize[0] = r1c4.Size;
                    SpaceToFill[0] = r1c4;
                    setFirst = true;
                }
                r1c4.BorderStyle = BorderStyle.FixedSingle;
                r1c4.Tag = ' ';
            }
            r2c1.Image = ChiChar[MaskForCurGame[1, 0, 0], MaskForCurGame[1, 0, 1]];
            r2c1.Tag = CharToWrite[MaskForCurGame[1, 0, 0], MaskForCurGame[1, 0, 1]];
            r2c2.Image = ChiChar[MaskForCurGame[1, 1, 0], MaskForCurGame[1, 1, 1]];
            r2c2.Tag = CharToWrite[MaskForCurGame[1, 1, 0], MaskForCurGame[1, 1, 1]];
            r2c3.Image = ChiChar[MaskForCurGame[1, 2, 0], MaskForCurGame[1, 2, 1]];
            r2c3.Tag = CharToWrite[MaskForCurGame[1, 2, 0], MaskForCurGame[1, 2, 1]];
            r2c4.Image = ChiChar[MaskForCurGame[1, 3, 0], MaskForCurGame[1, 3, 1]];
            r2c4.Tag = CharToWrite[MaskForCurGame[1, 3, 0], MaskForCurGame[1, 3, 1]];

            if (mode != 2)
            {
                timer1.Start();
            }
        }

        void CheckCorrect()
        {
            if(r1c1.Tag.ToString() != " "&& r1c2.Tag.ToString() != " "&& r1c3.Tag.ToString() != " " && r1c4.Tag.ToString() != " ")
            {
                if (collection.WriteToAnsText(r1c1.Tag.ToString(), r1c2.Tag.ToString(), r1c3.Tag.ToString(), r1c4.Tag.ToString(),0) == 1)
                {
                    if(mode == 0)
                    {
                        TotalScore += 10;
                    }
                    if(mode == 1)
                    {
                        TotalScore += CurScore;
                    }
                    if(mode == 2)
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
                if(CurRound == 3 && mode == 1)
                {
                    timer1.Stop();
                    MessageBox.Show("Total Score: "+TotalScore.ToString());
                    collection.dllUpdateHighScore(TotalScore);
                    this.Close();
                }
                if (mode != 2)
                {
                    setquestion();
                }
            }
        }

        private bool press;
        private System.Drawing.Size halfsize;
        int mode;//0=time 1=score
        bool cheat;
        public Form3(int Mode,bool cheatmode)
        {
            InitializeComponent();
            mode = Mode;
            cheat = cheatmode;
            Size = GetPreferredSize(Size);
            halfsize = new Size(r1c1.Size.Width / 2, r1c1.Size.Height / 2);
            timer1.Stop();
            OrgLoc[0, 0] = r1c1.Location;
            OrgLoc[0, 1] = r1c2.Location;
            OrgLoc[0, 2] = r1c3.Location;
            OrgLoc[0, 3] = r1c4.Location;
            OrgLoc[1, 0] = r2c1.Location;
            OrgLoc[1, 1] = r2c2.Location;
            OrgLoc[1, 2] = r2c3.Location;
            OrgLoc[1, 3] = r2c4.Location;
            cheatpictureBoxes = new PictureBox[4]
            {
                r1c1_cheat,r1c2_cheat,r1c3_cheat,r1c4_cheat
            };
            setquestion();
        }


        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), halfsize);
        }

        bool MouseUphandler(PictureBox Picturebox)
        {
            for (int i = 0; i < 2; i++)
            {
                if ((Picturebox.Location.X + halfsize.Width) >= CorrImgboxLocation[i].X &&
    (Picturebox.Location.X + halfsize.Width) <= (CorrImgboxLocation[i].X + CorrImgSize[i].Width) &&
    (Picturebox.Location.Y + halfsize.Height) >= CorrImgboxLocation[i].Y &&
     (Picturebox.Location.Y + halfsize.Height) <= (CorrImgboxLocation[i].Y + CorrImgSize[i].Height))
                {
                    Picturebox.Location = CorrImgboxLocation[i];
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
                r2c4.Location = OrgLoc[1, 3];
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
                r2c3.Location = OrgLoc[1, 2];
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
                r2c2.Location = OrgLoc[1, 1];
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
                r2c1.Location = OrgLoc[1, 0];
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
                if(CurRound > 5&& CurScore > 4)
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
