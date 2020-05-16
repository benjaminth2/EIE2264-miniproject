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

        
        PictureBox[] cheatpictureBoxes;
        int[] MaskForUsedQuestion = new int[10]
        {
            0,0,0,0,0,0,0,0,0,0
        };
        
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
            bool Indicator;
            int[,,] MaskForCurGame = new int[2, 4, 2];
            do
            {
                RandNum = collection.dllGetRandomNumber() % 10;
                if (MaskForUsedQuestion[RandNum] == 0)
                {
                    MaskForUsedQuestion[RandNum] = 5;
                    Indicator = false;
                }
                else
                {
                    Indicator = true;
                }
            } while (Indicator);
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
            RandNum2 = (collection.dllGetRandomNumber() % 11) % 4;
            if (RandNum2 == RandNum)
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

            for (int i = 3; i > 0; i--)
            {
                RandNum = collection.dllGetRandomNumber() % (i + 1);
                if (RandNum != i)
                {
                    int tmp0 = MaskForCurGame[1, i, 0];
                    int tmp1 = MaskForCurGame[1, i, 1];
                    MaskForCurGame[1, i, 0] = MaskForCurGame[1, RandNum, 0];
                    MaskForCurGame[1, i, 1] = MaskForCurGame[1, RandNum, 1];
                    MaskForCurGame[1, RandNum, 0] = tmp0;
                    MaskForCurGame[1, RandNum, 1] = tmp1;
                }
            }

            Indicator = false;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (MaskForCurGame[i, j, 0] != -1)
                    {
                        collection.pictureBoxes[i, j].Image = ChiChar[MaskForCurGame[i, j, 0], MaskForCurGame[i, j, 1]];
                        collection.pictureBoxes[i, j].Tag = CharToWrite[MaskForCurGame[i, j, 0], MaskForCurGame[i, j, 1]];
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

        void endgame()
        {
            timer1.Stop();
            collection.End(mode);
            Close();
        }

        void CheckCorrect()
        {
            switch (collection.CheckCorrect(0, mode))
            {
                case 1:
                    setquestion();
                    break;
                case 2:
                    endgame();
                    break;
            }
        }

        private bool press;
        int mode;
        bool cheat;
        public Form3(int Mode, bool cheatmode)
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


        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), collection.halfsize);
        }

        bool MouseUphandler(PictureBox Picturebox)
        {
            if (collection.MouseUphandler(Picturebox,0))
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

        private void FormClosing_event(object sender, CancelEventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collection.CurRound--;
            collection.CurTime = 0;
            setquestion();
        }
    }
}
