using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        string gameDev = "Jasur Haydarov";
        int navbat = 0;
        Random random = new Random();

        // Store all buttons for easy access
        private List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("favicon.ico");

            // Initialize buttons list - add this after InitializeComponent
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
        }

        private void file__newGame(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void file__exitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void haqida(object sender, EventArgs e)
        {
            MessageBox.Show($"Ushbu o'yin {gameDev} tomonidan ishlab chiqarildi! \n\nhttps://github.com/jasurhaydarovcode/TicTacToe", "O'yin Haqida");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            // Player's move (X)
            b.Text = "X";
            b.BackColor = Color.LightBlue;
            b.Enabled = false;
            navbat++;

            // Check if player won or if it's a draw
            if (CheckForWinner() || navbat == 9)
                return;

            // Bot's move (O)
            MakeSmartBotMove();
            navbat++;

            // Check if bot won or if it's a draw
            CheckForWinner();
        }

        private void MakeSmartBotMove()
        {
            // Try to win first
            if (TryToWinOrBlock("O"))
                return;

            // If can't win, try to block player from winning
            if (TryToWinOrBlock("X"))
                return;

            // If center is available, take it
            if (button5.Enabled)
            {
                MakeMove(button5);
                return;
            }

            // Try to take corners
            List<Button> corners = new List<Button> { button1, button3, button7, button9 };
            foreach (Button corner in corners)
            {
                if (corner.Enabled)
                {
                    MakeMove(corner);
                    return;
                }
            }

            // If none of the above, make a random move
            List<Button> availableButtons = buttons.Where(btn => btn.Enabled).ToList();
            if (availableButtons.Count > 0)
            {
                int randomIndex = random.Next(0, availableButtons.Count);
                MakeMove(availableButtons[randomIndex]);
            }
        }

        private bool TryToWinOrBlock(string symbol)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (CheckLineForTwoSymbols(buttons[i * 3], buttons[i * 3 + 1], buttons[i * 3 + 2], symbol))
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (CheckLineForTwoSymbols(buttons[i], buttons[i + 3], buttons[i + 6], symbol))
                    return true;
            }

            // Check diagonals
            if (CheckLineForTwoSymbols(buttons[0], buttons[4], buttons[8], symbol))
                return true;

            if (CheckLineForTwoSymbols(buttons[2], buttons[4], buttons[6], symbol))
                return true;

            return false;
        }

        private bool CheckLineForTwoSymbols(Button b1, Button b2, Button b3, string symbol)
        {
            // If two buttons have the symbol and the third is empty, make a move there
            if (b1.Text == symbol && b2.Text == symbol && b3.Enabled)
            {
                MakeMove(b3);
                return true;
            }
            if (b1.Text == symbol && b3.Text == symbol && b2.Enabled)
            {
                MakeMove(b2);
                return true;
            }
            if (b2.Text == symbol && b3.Text == symbol && b1.Enabled)
            {
                MakeMove(b1);
                return true;
            }

            return false;
        }

        private void MakeMove(Button button)
        {
            button.Text = "O";
            button.BackColor = Color.LightPink;
            button.Enabled = false;
        }

        private bool CheckForWinner()
        {
            // Check for winner using the same conditions
            if ((button1.Text == button2.Text && button2.Text == button3.Text && button1.Enabled == false) ||
                (button4.Text == button5.Text && button5.Text == button6.Text && button4.Enabled == false) ||
                (button7.Text == button8.Text && button8.Text == button9.Text && button7.Enabled == false) ||
                (button1.Text == button4.Text && button4.Text == button7.Text && button1.Enabled == false) ||
                (button2.Text == button5.Text && button5.Text == button8.Text && button2.Enabled == false) ||
                (button3.Text == button6.Text && button6.Text == button9.Text && button3.Enabled == false) ||
                (button1.Text == button5.Text && button5.Text == button9.Text && button1.Enabled == false) ||
                (button3.Text == button5.Text && button5.Text == button7.Text && button3.Enabled == false))
            {
                string winner = (navbat % 2 != 0) ? "\"X\"" : "\"O\"";
                MessageBox.Show(winner + " G'alaba qozondi", "G'alaba");
                Application.Restart();
                return true;
            }

            // Check for draw
            if (navbat == 9)
            {
                MessageBox.Show("Durang! Game Over.");
                Application.Restart();
                return true;
            }

            return false;
        }
    }
}