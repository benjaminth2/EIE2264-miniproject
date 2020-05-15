using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (mode)
            {
                case 0:
                    dllWriteEngToAns();
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
        public static extern void dllWriteEngToAns();
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
