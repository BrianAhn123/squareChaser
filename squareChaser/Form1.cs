using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace squareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(100, 120, 10, 10);
        Rectangle player2 = new Rectangle(100, 240, 10, 10);
        Rectangle border = new Rectangle(0, 0, 570, 440);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 4;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        Pen bluePen = new Pen(Color.Blue, 3);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Left:
                    leftPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.DrawRectangle(bluePen, border);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aPressed == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dPressed == true && player1.X < this.Height - player1.Height)
            {
                player1.X += playerSpeed;
            }

            //move player 2 
            if (upPressed == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }
            if (leftPressed == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightPressed == true && player2.X < this.Height - player2.Height)
            {
                player2.X += playerSpeed;
            }

            Refresh();

        }
    }
}
