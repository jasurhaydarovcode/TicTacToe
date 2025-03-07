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
        Random random = new Random(); // Random generator for bot moves

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
            MakeBotMove();
            navbat++;

            // Check if bot won or if it's a draw
            CheckForWinner();
        }

        private void MakeBotMove()
        {
            // Get list of all available (enabled) buttons
            List<Button> availableButtons = buttons.Where(btn => btn.Enabled).ToList();

            if (availableButtons.Count > 0)
            {
                // Select random button from available ones
                int randomIndex = random.Next(0, availableButtons.Count);
                Button randomButton = availableButtons[randomIndex];

                // Make bot's move
                randomButton.Text = "O";
                randomButton.BackColor = Color.LightPink;
                randomButton.Enabled = false;
            }
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