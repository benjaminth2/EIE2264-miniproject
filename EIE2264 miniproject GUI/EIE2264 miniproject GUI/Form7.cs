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
    public partial class Form7 : Form
    {
        int totalRecord;
        int a = 1;
        int b;
        Label[,] scoreboard;
        public Form7()
        {
            InitializeComponent();
            totalRecord = collection.dllGetTotalNumberOfPlayer();
            collection.dllSort();
            scoreboard = new Label[2, 10]
            {
                {Name_1,Name_2,Name_3,Name_4,Name_5,Name_6,Name_7,Name_8,Name_9,Name_10},
                {HighScore_1,HighScore_2,HighScore_3,HighScore_4,HighScore_5,HighScore_6,HighScore_7,HighScore_8,HighScore_9,HighScore_10}
            };
            refreshscreen();
        }

        void refreshscreen()
        {
            collection.dllSort();
            if (a + 10 > totalRecord)
            {
                b = totalRecord;
            }
            else
            {
                b = a + 9;
            }
            if(a == b)
            {
                label1.Text = "Showing Result " + a.ToString() + " of " + totalRecord.ToString();
            }
            else
            {
                label1.Text = "Showing Result " + a.ToString() + " to " + b.ToString() + " of " + totalRecord.ToString();
            }
            for(int i = 0;i < 10; i++)
            {
                if(i+a <= totalRecord)
                {
                    scoreboard[1,i].Text = collection.dllScoreBoard(i+a).ToString();
                    scoreboard[0, i].Text = collection.ReadFromAnsText();
                }
                else
                {
                    scoreboard[1, i].Text = "";
                    scoreboard[0, i].Text = "";
                }
            }
            Previous.Enabled = true;
            Next.Enabled = false;
            if(a == 1)
            {
                Previous.Enabled = false;
            }
            if (totalRecord > b)
            {
                Next.Enabled = true;
            }
            Size = GetPreferredSize(Size);
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            a = a - 10;
            refreshscreen();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            a = b + 1;
            refreshscreen();
        }
    }
}
