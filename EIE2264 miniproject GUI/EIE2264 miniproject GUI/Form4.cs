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
    public partial class Form4 : Form
    {
        Bitmap[] MathChar = new Bitmap[10]
           {
               Properties.Resources._0,
               Properties.Resources._1,
               Properties.Resources._2,
               Properties.Resources._3,
               Properties.Resources._4,
               Properties.Resources._5,
               Properties.Resources._6,
               Properties.Resources._7,
               Properties.Resources._8,
               Properties.Resources._9,
           };
        
        Point[] OrgLoc = new Point[4];
        
        int TotalScore = 0;
        int CurScore = 0;
        int CurRound = 0;

        void ResetAll()
        {
            timer1.Stop();
            CurScore = 0;

            r2c1.Enabled = true;
            r2c1.Visible = true;
            r2c1.Location = OrgLoc[0];
            r2c2.Enabled = true;
            r2c2.Visible = true;
            r2c2.Location = OrgLoc[1];
            r2c3.Enabled = true;
            r2c3.Visible = true;
            r2c3.Location = OrgLoc[2];
            r2c4.Enabled = true;
            r2c4.Visible = true;
            r2c4.Location = OrgLoc[3];
            a_10.Tag = null;
            a_10.Image = null;

            c_10.Tag = null;
            c_10.Image = null;
            Ans.Image = null;
            Ans.Tag = "";
        }

        void setquestion()
        {
            ResetAll();
            int a = (collection.dllGetRandomNumber() % 9) + 1;
            int b;
            do
            {
                b = collection.dllGetRandomNumber() % 10;
            } while (a == b);
            int c = 0;
            int method = collection.dllGetRandomNumber() % 4;//0=add, 1=mul, 2=sub(reverse of 0), 3=div(reverse of 1)

            switch (method)
            {
                case 0:
                case 2:
                    c = a + b;
                    break;
                case 1:
                case 3:
                    c = a * b;
                    break;
            }

            if (cheat)
            {
                r1c1_cheat.Visible = true;
                switch (method)
                {
                    case 0:
                        r1c1_cheat.Image = Properties.Resources.ADD;
                        break;
                    case 1:
                        r1c1_cheat.Image = Properties.Resources.MUL;
                        break;
                    case 2:
                        r1c1_cheat.Image = Properties.Resources.SUB;
                        break;
                    case 3:
                        r1c1_cheat.Image = Properties.Resources.DIV;
                        break;
                }
            }
            else
            {
                r1c1_cheat.Visible = false;
            }

            if(method == 2||method == 3)
            {
                int temp = c;
                c = a;
                a = temp;
            }

            if(a > 9)
            {
                a_10.Image = MathChar[a / 10];
                a_10.Tag = a / 10;
            }
            if (c > 9)
            {
                c_10.Image = MathChar[c / 10];
                c_10.Tag = c / 10;
            }

            a_1.Image = MathChar[a % 10];
            a_1.Tag = a % 10;
            IntB.Image = MathChar[b];
            IntB.Tag = b;
            c_1.Image = MathChar[c % 10];
            c_1.Tag = c % 10;

            Ans.BorderStyle = BorderStyle.FixedSingle;
            if (mode != 2)
            {
                timer1.Start();
            }
        }

        bool verifyans()
        {
            int a;
            if (a_10.Tag == null)
            {
                a = Int32.Parse(a_1.Tag.ToString());
            }
            else
            {
                a = Int32.Parse(a_10.Tag.ToString() + a_1.Tag.ToString());
            }
            int b = Int32.Parse(IntB.Tag.ToString());
            int c;
            if (c_10.Tag == null)
            {
               c = Int32.Parse(c_1.Tag.ToString());
            }
            else
            {
                c = Int32.Parse(c_10.Tag.ToString() + c_1.Tag.ToString());
            }
            if (Ans.Tag.ToString() == "ADD")
            {
                if(a+b == c)
                {
                    return true;
                }
            }
            if (Ans.Tag.ToString() == "DIV")
            {
                if(a/b == c && a%b == 0)
                {
                    return true;
                }
            }
            if (Ans.Tag.ToString() == "MUL")
            {
                if(a*b == c)
                {
                    return true;
                }
            }
            if (Ans.Tag.ToString() == "SUB")
            {
                if(a-b == c)
                {
                    return true;
                }
            }
            return false;
        }

        void CheckCorrect()
        {
            if (Ans.Tag.ToString() != "")
            {
                if (verifyans())
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

        private bool press;
        private Size halfsize;
        int mode;//0=time 1=score
        bool cheat;
        public Form4(int Mode, bool cheatmode)
        {
            InitializeComponent();
            mode = Mode;
            cheat = cheatmode;
            Size = GetPreferredSize(Size);
            halfsize = new Size(Ans.Size.Width / 2, Ans.Size.Height / 2);
            timer1.Stop();
            OrgLoc[0] = r2c1.Location;
            OrgLoc[1] = r2c2.Location;
            OrgLoc[2] = r2c3.Location;
            OrgLoc[3] = r2c4.Location;
            setquestion();
        }

        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), halfsize);
        }

        bool MouseUphandler(PictureBox Picturebox)
        {
            if ((Picturebox.Location.X + halfsize.Width) >= Ans.Location.X &&
       (Picturebox.Location.X + halfsize.Width) <= (Ans.Location.X + Ans.Size.Width) &&
       (Picturebox.Location.Y + halfsize.Height) >= Ans.Location.Y &&
        (Picturebox.Location.Y + halfsize.Height) <= (Ans.Location.Y + Ans.Size.Height))
            {
                Picturebox.Location = Ans.Location;
                Ans.Tag = Picturebox.Tag;
                CheckCorrect();
                return false;
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
