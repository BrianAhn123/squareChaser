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
        Rectangle border = new Rectangle(10, 10, 550, 423);
        Rectangle point = new Rectangle(100, 100, 10, 10);
        Rectangle powerUp = new Rectangle(100, 100, 10, 10);
        Rectangle negativepoint = new Rectangle(100, 100, 30, 30);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 4;
        int player2Speed = 4;

        int maxSpeed = 7;

        int negativePointXSpeed = -5;
        int negativePointYSpeed = -5;

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

        Random numGen = new Random();

        int pause = 175;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        Pen bluePen = new Pen(Color.Blue, 3);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        public Form1()
        {
            InitializeComponent();

            SpeedRandomizer();
            PointRandomizer();
            DangerRandomizer();
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
            e.Graphics.FillRectangle(whiteBrush, point);
            e.Graphics.FillRectangle(redBrush, negativepoint);
            e.Graphics.FillRectangle(yellowBrush, powerUp);


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ObjectMovement();
            Border();
            movement();
            Collision();
            pause--;


            Refresh();
        }


        public void SpeedRandomizer()
        {
            //Generate random position for yellow circle/the boost
            powerUp.X = numGen.Next(0, 560);
            powerUp.Y = numGen.Next(0, 430);
        }

        public void PointRandomizer()
        {
            //Generate random position for whitesquare/the point
            point.X = numGen.Next(0, 560);
            point.Y = numGen.Next(0, 430);
        }

        public void DangerRandomizer()
        {
            //Generate random position for the dangerObject
            negativepoint.X = numGen.Next(0, 560);
            negativepoint.Y = numGen.Next(0, 430);
        }

        public void ObjectMovement()
        {
            // Move the dangerObject
            negativepoint.X += negativePointXSpeed;
            negativepoint.Y += negativePointYSpeed;

            //checks for player 1 & 2's speed reaching maximum limit
            if (player1Speed > maxSpeed)
            {
                player1Speed = maxSpeed;
            }
            if (player2Speed > maxSpeed)
            {
                player2Speed = maxSpeed;
            }
        }

        public void Border()
        {
            // Check if dangerObject hits the boundaries
            if (negativepoint.Left < border.Left || negativepoint.Right > border.Right)
            {
                negativePointXSpeed = -negativePointXSpeed;
            }
            if (negativepoint.Top < border.Top || negativepoint.Bottom > border.Bottom)
            {
                negativePointYSpeed = -negativePointYSpeed;
            }
        }
        public void movement()
        {
            //move player 1 
            if (wPressed == true && player1.Y > 2)
            {
                player1.Y -= player1Speed;
            }

            if (sPressed == true && player1.Y < 428)
            {
                player1.Y += player1Speed;
            }

            if (aPressed == true && player1.X > 2)
            {
                player1.X -= player1Speed;
            }

            if (dPressed == true && player1.X < 558)
            {
                player1.X += player1Speed;
            }

            //move player 2 
            if (upPressed == true && player2.Y > 2)
            {
                player2.Y -= player2Speed;
            }

            if (downPressed == true && player2.Y < 428)
            {
                player2.Y += player2Speed;
            }
            if (leftPressed == true && player2.X > 2)
            {
                player2.X -= player2Speed;
            }

            if (rightPressed == true && player2.X < 558)
            {
                player2.X += player2Speed;
            }

            Refresh();
        }

        public void Collision()
        {
            //Check if Player interacts with any objects 
            if (point.IntersectsWith(player1))
            {
                player1Score++;
                p1pointsLabel.Text = $"{player1Score}";

                
                point.X = numGen.Next(0, 560);
                point.Y = numGen.Next(0, 430);
            }
            else if (powerUp.IntersectsWith(player1))
            {
                player1Speed++;

               
                powerUp.X = numGen.Next(0, 560);
                powerUp.Y = numGen.Next(0, 430);
            }
            else if (negativepoint.IntersectsWith(player1) && pause < 0)
            {
                pause = 175;
                player1Score--;
                p1pointsLabel.Text = $"{player1Score}";
                
            }
            pause--;
            //Check if player2 hits any objects
            if (point.IntersectsWith(player2))
            {
                player2Score++;
                p2pointsLabel.Text = $"{player2Score}";


                point.X = numGen.Next(0, 560);
                point.Y = numGen.Next(0, 430);
            }
            else if (powerUp.IntersectsWith(player2))
            {
                player2Speed++;


                powerUp.X = numGen.Next(0, 560);
                powerUp.Y = numGen.Next(0, 430);
            }
            else if (negativepoint.IntersectsWith(player2) && pause < 0)
            {
                pause = 175;
                player2Score--;
                p2pointsLabel.Text = $"{player2Score}";

            }

        }
    }
}
