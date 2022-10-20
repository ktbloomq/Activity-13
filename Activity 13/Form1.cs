using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_13
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Label[,] customGrid;
        public int[,] board;
        Random rand;
        public Form1()
        {
            InitializeComponent();

            // map labels to 2d custom grid
            customGrid = new System.Windows.Forms.Label[3, 3];
            customGrid[0, 0] = label1;
            customGrid[0, 1] = label2;
            customGrid[0, 2] = label3;
            customGrid[1, 0] = label4;
            customGrid[1, 1] = label5;
            customGrid[1, 2] = label6;
            customGrid[2, 0] = label7;
            customGrid[2, 1] = label8;
            customGrid[2, 2] = label9;
            board = new int[3, 3];
            rand = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // loop through 2d board
            result.Text = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // assign random int less than 2
                    board[i, j] = rand.Next(2);
                    // assign board value to corresponding player
                    if(board[i, j] == 0)
                    {
                        customGrid[i, j].Text = "O";
                    }
                    else
                    {
                        customGrid[i, j].Text = "X";
                    }
                }
            }

            getResult();
        }

        // check for winner
        private void getResult()
        {
            // check horizontal lines
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                {
                    result.Text = customGrid[i, 0].Text + " Wins!";
                    return;
                }
            }

            // check vertical lines
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i])
                {
                    result.Text = customGrid[0, i].Text + " Wins!";
                    return;
                }
            }

            // check diagonals
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                result.Text = customGrid[1, 1].Text + " Wins!";
                return;
            }
            if (board[0, 2] == board[1, 1] && board[0, 0] == board[2, 0])
            {
                result.Text = customGrid[1, 1].Text + " Wins!";
                return;
            }
            result.Text = "Cats Game!";
        }
    }
}
