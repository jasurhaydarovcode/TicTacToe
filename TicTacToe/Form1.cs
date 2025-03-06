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

        public Form1()
        {
            InitializeComponent();
            this.Icon = new Icon("favicon.ico");
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
            navbat++;
            Button b = (Button)sender;
            if(navbat % 2 != 0)
                b.Text = "X";

            else
                b.Text = "O";

            b.BackColor = b.Text == "X" ? Color.LightBlue : Color.LightPink;
            b.Enabled = false;

            if((button1.Text == button2.Text && button2.Text == button3.Text && button1.Enabled == false) ||
                (button4.Text == button5.Text && button5.Text == button6.Text && button4.Enabled == false) ||
                (button7.Text == button8.Text && button8.Text == button9.Text && button7.Enabled == false) ||
                (button1.Text == button4.Text && button4.Text == button7.Text && button1.Enabled == false) ||
                (button2.Text == button5.Text && button5.Text == button8.Text && button2.Enabled == false) ||
                (button3.Text == button6.Text && button6.Text == button9.Text && button3.Enabled == false) ||
                (button1.Text == button5.Text && button5.Text == button9.Text && button1.Enabled == false) ||
                (button3.Text == button5.Text && button5.Text == button7.Text && button3.Enabled == false))
            {
                if (navbat % 2 != 0)
                    MessageBox.Show("\"X\" G'alaba qozondi", "G'alaba");
                else
                    MessageBox.Show("\"0\" G'alaba qozondi", "G'alaba");

                Application.Restart();
                //this.Close();
                return;
            }

            // Durang
            if (navbat == 9)
            {
                MessageBox.Show("Durang! Game Over.");
                Application.Restart();
            }
        }
    }
}
