//CHEUNG Tin Ho Benjamin, 19073365D
//FONG Cheuk Yin, 19049803D
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using System.Runtime.InteropServices;

using System.IO;
using EIE2264_miniproject_GUI.Properties;

namespace EIE2264_miniproject_GUI
{
    class collection
    {
        public static void WriteToTempText(string text)
        {
            StreamWriter sw = new StreamWriter("temp.txt", false);
            sw.Write(text);
            sw.Close();
        }

        public static string ReadFromTempText()
        {
            string Text;
            StreamReader sr = new StreamReader("temp.txt");
            Text = sr.ReadLine();
            sr.Close();
            return Text;
        }

        public static string ReadFromAnsText()
        {
            string Text;
            StreamReader sr = new StreamReader("ans.txt");
            Text = sr.ReadLine();
            sr.Close();
            return Text;
        }

        public static int WriteToAnsText(string a, string b, string c, string d,int mode)
        {
            StreamWriter sw = new StreamWriter("ans.txt", false);
            sw.Write(a);
            sw.Write(b);
            sw.Write(c);
            sw.Write(d);
            sw.Close();
            switch (mode) {
                case 0:
                    return dllChkChi();
                case 1:
                    return dllChkEng();
                case 2:
                    return dllChkCountry();
                default:
                    return 0;
            }
        }

        public static string ReadFromAnswer(int mode)
        {
            switch (mode){
                case 0:
                    dllWriteEngToAns(settings[5, 1]);
                    break;

                case 1:
                    dllWriteCountryToAns();
                    break;
            }
            
            string Text;
            StreamReader sr = new StreamReader("ans.txt");
            Text = sr.ReadLine();
            sr.Close();
            WriteToAnsText("", "", "", "", 3);
            return Text;
        }

        public static int[,] settings = new int[6, 2];
        public static void UpdateSettings()
        {
            for(int i = 0;i < 6; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    settings[i, j] = dllgetconfig(i, j);
                }
            }
        }

        public static PictureBox[] SpaceToFill = new PictureBox[2];
        public static Point[] OrgLoc = new Point[4];
        public static Size halfsize;
        public static PictureBox[,] pictureBoxes;
        public static int TotalScore, CurTime, CurRound;

        public static PictureBox[] MathQuestion;
        public static PictureBox[] MathAnswer;


        public static bool MouseUphandler(PictureBox Picturebox,int game)
        {
            if (game != 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    if ((Picturebox.Location.X + halfsize.Width) >= SpaceToFill[i].Location.X &&
                        (Picturebox.Location.X + halfsize.Width) <= (SpaceToFill[i].Location.X + SpaceToFill[i].Width) &&
                        (Picturebox.Location.Y + halfsize.Height) >= SpaceToFill[i].Location.Y &&
                        (Picturebox.Location.Y + halfsize.Height) <= (SpaceToFill[i].Location.Y + SpaceToFill[i].Height))
                    {
                        Picturebox.Location = SpaceToFill[i].Location;
                        for(int j = 0;j < 4; j++)
                        {
                            if(Picturebox != pictureBoxes[1, j])
                            {
                                if (Picturebox.Location == pictureBoxes[1, j].Location)
                                {
                                    for (int k = 0; k < 4; k++)
                                    {
                                        if (Picturebox == pictureBoxes[1, k])
                                        {
                                            Picturebox.Location = OrgLoc[k];
                                        }
                                    }
                                }
                            }
                        }
                        return true;
                    }
                }
            }
            else
            {
                if ((Picturebox.Location.X + halfsize.Width) >= MathQuestion[2].Location.X &&
                    (Picturebox.Location.X + halfsize.Width) <= (MathQuestion[2].Location.X + MathQuestion[2].Width) &&
                    (Picturebox.Location.Y + halfsize.Height) >= MathQuestion[2].Location.Y &&
                    (Picturebox.Location.Y + halfsize.Height) <= (MathQuestion[2].Location.Y + MathQuestion[2].Height))
                {
                    Picturebox.Location = MathQuestion[2].Location;
                    for (int j = 0; j < 4; j++)
                    {
                        if (Picturebox != MathAnswer[j])
                        {
                            if (Picturebox.Location == MathAnswer[j].Location)
                            {
                                for(int k = 0;k < 4; k++)
                                {
                                    if(Picturebox == MathAnswer[k])
                                    {
                                        Picturebox.Location = OrgLoc[k];
                                    }
                                }
                            }
                        }
                    }
                    return true;
                }
            }
            if (game != 3)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (Picturebox == pictureBoxes[1, k])
                    {
                        Picturebox.Location = OrgLoc[k];
                    }
                }
            }
            else
            {
                for (int k = 0; k < 4; k++)
                {
                    if (Picturebox == MathAnswer[k])
                    {
                        Picturebox.Location = OrgLoc[k];
                    }
                }
            }
            return false;
        }

        public static bool DetEndForMode0()
        {
            if ((CurRound >= settings[3, 0] && CurTime > settings[3, 1]) ||
                (CurRound >= settings[2, 0] && CurTime > settings[2, 1]) ||
                (CurRound >= settings[1, 0] && CurTime > settings[1, 1]) ||
                (CurRound >= settings[0, 0] && CurTime > settings[0, 1]))
            {
                return true;
            }
            return false;
        }

        public static void End(int mode)
        {
            string promptstr = "";
            switch (mode)
            {
                case 1:
                    promptstr = "Total Score: " + TotalScore.ToString();
                    break;
                case 0:
                    promptstr = "Total Round: " + ((TotalScore / settings[4, 0]) + 1).ToString();
                    break;
            }
            MessageBox.Show(promptstr);
            dllUpdateHighScore(TotalScore);
        }
        
        private static bool verifyans(int game)
        {
            switch (game)
            {
                case 0:
                    if (WriteToAnsText(
                        pictureBoxes[0, 0].Tag.ToString(),
                        pictureBoxes[0, 1].Tag.ToString(),
                        pictureBoxes[0, 2].Tag.ToString(),
                        pictureBoxes[0, 3].Tag.ToString(), 0) == 1)
                    {
                        return true;
                    }
                    break;
                case 1:
                    if(WriteToAnsText(
                        pictureBoxes[0, 0].Tag.ToString(), 
                        pictureBoxes[0, 1].Tag.ToString(), 
                        pictureBoxes[0, 2].Tag.ToString(), 
                        pictureBoxes[0, 3].Tag.ToString(),1) == 1)
                    {
                        return true;
                    }
                    break;
                case 2:
                    if (WriteToAnsText(
                        pictureBoxes[0, 0].Tag.ToString(),
                        pictureBoxes[0, 1].Tag.ToString(),
                        pictureBoxes[0, 2].Tag.ToString(),
                        pictureBoxes[0, 3].Tag.ToString(), 2) == 1)
                    {
                        return true;
                    }
                    break;
                case 3:
                    int a = int.Parse(MathQuestion[0].Tag.ToString() + MathQuestion[1].Tag.ToString());
                    int b = int.Parse(MathQuestion[3].Tag.ToString());
                    int c = int.Parse(MathQuestion[4].Tag.ToString() + MathQuestion[5].Tag.ToString());
                    if (MathQuestion[2].Tag.ToString() == "ADD")
                    {
                        if (a + b == c)
                        {
                            return true;
                        }
                    }
                    if (MathQuestion[2].Tag.ToString() == "DIV")
                    {
                        if (b == 0)
                        {
                            return false;
                        }
                        if (a / b == c && a % b == 0)
                        {
                            return true;
                        }
                    }
                    if (MathQuestion[2].Tag.ToString() == "MUL")
                    {
                        if (a * b == c)
                        {
                            return true;
                        }
                    }
                    if (MathQuestion[2].Tag.ToString() == "SUB")
                    {
                        if (a - b == c)
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
        
        public static int CheckCorrect(int game,int mode)
        {
            bool indicator = true;
            if (game != 3)
            {
                for (int i = 0; i < 2; i++)
                {
                    SpaceToFill[i].Tag = " ";
                }

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (SpaceToFill[i].Location == pictureBoxes[1, j].Location)
                        {
                            SpaceToFill[i].Tag = pictureBoxes[1, j].Tag;
                        }
                    }
                }
                for(int i = 0; i < 4; i++)
                {
                    if(pictureBoxes[0,i].Tag.ToString() == " ")
                    {
                        indicator = false;
                    }
                }
            }
            else
            {
                MathQuestion[2].Tag = " ";
                for(int i = 0;i < 4; i++)
                {
                    if(MathAnswer[i].Location == MathQuestion[2].Location)
                    {
                        MathQuestion[2].Tag = MathAnswer[i].Tag;
                    }
                }
                if(MathQuestion[2].Tag.ToString() == " ")
                {
                    indicator = false;
                }
            }
            if (indicator)
            {
                if (verifyans(game))
                {
                    switch (mode)
                    {
                        case 0:
                            TotalScore += settings[4, 0];
                            break;
                        case 1:
                            TotalScore += CurTime;
                            if (CurRound + 1 == settings[5, 0])
                            {
                                return 2;
                            }
                            break;
                    }
                    return 1;
                }
                else
                {
                    if (settings[4, 1] == 0 && mode != 2)
                    {
                        switch (mode)
                        {
                            case 0:
                                return 2;
                            case 1:
                                if (CurRound + 1 == settings[5, 0])
                                {
                                    return 2;
                                }
                                return 1;
                        }
                    }
                }
            }
            return 0;
        }

        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllFindPlayerInList();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllHighScoreOfPlayer();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dllUpdateHighScore(int score);
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dllEditHighScore(int score);
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllGetRandomNumber();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllChkChi();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllChkEng();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dllWriteEngToAns(int diff);
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllChkCountry();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dllWriteCountryToAns();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllGetTotalNumberOfPlayer();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllScoreBoard(int loc);
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dllSort();
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern void dlleditconfig(int a, int b, int c);
        [DllImport("EIE2264 miniproject Dll.dll")]
        public static extern int dllgetconfig(int a, int b);
    }
}
