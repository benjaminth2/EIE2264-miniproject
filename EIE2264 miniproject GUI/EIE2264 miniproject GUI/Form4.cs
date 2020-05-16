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

        void ResetAll()
        {
            timer1.Stop();
            collection.CurScore = 0;

            for (int i = 0; i < 4; i++)
            {
                collection.MathAnswer[i].Location = collection.OrgLoc[i];
            }
            a_10.Tag = "";
            a_10.Image = null;

            c_10.Tag = "";
            c_10.Image = null;
            Ans.Tag = null;
        }

        void setquestion()
        {
            ResetAll();

            collection.CurRound++;
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

            if (method == 2 || method == 3)
            {
                int temp = c;
                c = a;
                a = temp;
            }

            if (a > 9)
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

        void endgame()
        {
            timer1.Stop();
            MessageBox.Show("Total Score: " + collection.TotalScore.ToString());
            collection.dllUpdateHighScore(collection.TotalScore);
            this.Close();
        }

        void CheckCorrect()
        {
            switch (collection.CheckCorrect(3, mode))
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
        int mode;//0=time 1=score
        bool cheat;
        public Form4(int Mode, bool cheatmode)
        {
            InitializeComponent();
            mode = Mode;
            cheat = cheatmode;
            Size = GetPreferredSize(Size);
            collection.halfsize = new Size(Ans.Size.Width / 2, Ans.Size.Height / 2);
            timer1.Stop();
            collection.MathAnswer = new PictureBox[4]
            {
                r2c1,r2c2,r2c3,r2c4
            };
            collection.MathQuestion = new PictureBox[6]
            {
                a_10,a_1,Ans,IntB,c_10,c_1
            };
            for (int i = 0; i < 4; i++)
            {
                collection.OrgLoc[i] = collection.MathAnswer[i].Location;
            }
            collection.TotalScore = 0;
            collection.CurScore = 0;
            collection.CurRound = -1;
            setquestion();
        }

        void MouseMovehandler(PictureBox Picturebox)
        {
            Picturebox.Location = Point.Subtract(PointToClient(MousePosition), collection.halfsize);
        }

        bool MouseUphandler(PictureBox Picturebox)
        {
            if (collection.MouseUphandler(Picturebox,3))
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
            PictureBox Picturebox = (PictureBox)sender;
            press = false;
            if (MouseUphandler(Picturebox))
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
            collection.CurScore++;
            TimeDisplay.Text = "Time passed: " + collection.CurScore.ToString();
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
            setquestion();
        }
    }
}
