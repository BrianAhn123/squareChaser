using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

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
        Rectangle freezersquare = new Rectangle(100, 100, 30, 30);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 4;
        int player2Speed = 4;

        int maxSpeed = 7;

        int negativePointXSpeed = -5;
        int negativePointYSpeed = -5;


        int freezeSquareXSpeed = -5;
        int freezeSquareYSpeed = -5;


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
        SolidBrush lightblueBrush = new SolidBrush(Color.LightCyan);

        public Form1()
        {
            InitializeComponent();

            SpeedRand();
            PointRand();
            NegativeRand();
            FreezeSquareRand();


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
            e.Graphics.FillRectangle(lightblueBrush, freezersquare);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ObjectMovement();
            Border();
            movement();
            Collision();
            Winner();
            pause--;

            Refresh();
        }


        public void SpeedRand()
        {
            //Generate random position for yellow circle/the boost
            powerUp.X = numGen.Next(10, 550);
            powerUp.Y = numGen.Next(10, 423);
        }

        public void PointRand()
        {
            //Generate random position for whitesquare/the point
            point.X = numGen.Next(10, 550);
            point.Y = numGen.Next(10, 423);
        }

        public void NegativeRand()
        {
            //Generate random position for the dangerObject
            negativepoint.X = numGen.Next(20, 540);
            negativepoint.Y = numGen.Next(20, 413);
        }

        public void FreezeSquareRand()
        {
            //Generate random position for the dangerObject
            freezersquare.X = numGen.Next(20, 540);
            freezersquare.Y = numGen.Next(20, 413);
        }

        public void ObjectMovement()
        {
            // Move the dangerObject
            negativepoint.X += negativePointXSpeed;
            negativepoint.Y += negativePointYSpeed;

            // Move Freeze Square 
            freezersquare.X += freezeSquareXSpeed;
            freezersquare.Y += freezeSquareYSpeed;

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
            // Check if negativepointsquare hits the border
            if (negativepoint.Left < border.Left || negativepoint.Right > border.Right)
            {
                negativePointXSpeed = -negativePointXSpeed;
            }
            if (negativepoint.Top < border.Top || negativepoint.Bottom > border.Bottom)
            {
                negativePointYSpeed = -negativePointYSpeed;
            }
            //check if freeze square hits border
            if (freezersquare.Left < border.Left || freezersquare.Right > border.Right)
            {
                freezeSquareXSpeed = -freezeSquareXSpeed;
            }
            if (freezersquare.Top < border.Top || freezersquare.Bottom > border.Bottom)
            {
                freezeSquareYSpeed = -freezeSquareYSpeed;
            }
        }
        public void movement()
        {
            //move player 1 
            if (wPressed == true && player1.Y > 10)
            {
                player1.Y -= player1Speed;
            }

            if (sPressed == true && player1.Y < 423)
            {
                player1.Y += player1Speed;
            }

            if (aPressed == true && player1.X > 10)
            {
                player1.X -= player1Speed;
            }

            if (dPressed == true && player1.X < 550)
            {
                player1.X += player1Speed;
            }

            //move player 2 
            if (upPressed == true && player2.Y > 10)
            {
                player2.Y -= player2Speed;
            }

            if (downPressed == true && player2.Y < 423)
            {
                player2.Y += player2Speed;
            }
            if (leftPressed == true && player2.X > 10)
            {
                player2.X -= player2Speed;
            }

            if (rightPressed == true && player2.X < 550)
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


                point.X = numGen.Next(10, 550);
                point.Y = numGen.Next(10, 423);
            }
            else if (powerUp.IntersectsWith(player1) && player1Speed < 7)
            {
                player1Speed++;


                powerUp.X = numGen.Next(10, 550);
                powerUp.Y = numGen.Next(10, 423);
            }
            else if (negativepoint.IntersectsWith(player1) && pause < 0)
            {
                pause = 175;
                player1Score--;
                p1pointsLabel.Text = $"{player1Score}";
                player1Speed = 4; 

            }

            else if (freezersquare.IntersectsWith(player1))
            {
               // pause = 1000;
                player1Speed = 0;

                player1Speed = 4;
            }
            pause--;
            //Check if player2 hits any objects
            if (point.IntersectsWith(player2))
            {
                player2Score++;
                p2pointsLabel.Text = $"{player2Score}";


                point.X = numGen.Next(10, 550);
                point.Y = numGen.Next(10, 423);
            }
            else if (powerUp.IntersectsWith(player2) && player2Speed < 7)
            {
                player2Speed++;


                powerUp.X = numGen.Next(10, 550);
                powerUp.Y = numGen.Next(10, 423);
            }
            else if (negativepoint.IntersectsWith(player2) && pause < 0)
            {
                pause = 175;
                player2Score--;
                p2pointsLabel.Text = $"{player2Score}";
                player2Speed = 4;
            }
            else if (freezersquare.IntersectsWith(player2))
            {
                //pause = 1000;
                player2Speed = 0;
                
                player2Speed = 4; 
            }

        }

        public void powerupTimer()
        {
            if (player1Speed == 5)
            {
                
                player1Speed = 4;
            }

            else if (player1Speed == 6)
            {
                
                player1Speed = 4;
            }
            else if (player1Speed == 7)
            {
                
                player1Speed = 4;
            }

            if(player2Speed == 5)
            {
                
                player2Speed = 4;
            }

            else if (player2Speed == 6)
            {
                
                player2Speed = 4;
            }
            else if (player2Speed == 7)
            {
                
                player2Speed = 4;
            }
        }

        public void Winner()
        {
            //check for the winner 
            if (player1Score == 5)
            {
                winLabel.Text = "Player 1 Wins";
                gameTimer.Stop();
                restartButton.Enabled = true;
                restartButton.Visible = true;
                
            }
            else if (player2Score == 5)
            {
                winLabel.Text = "Player 2 Wins";
                gameTimer.Stop();
                restartButton.Enabled = true;
                restartButton.Visible = true;
            }
            else if (player1Score == -5)
            {
                winLabel.Text = "Player 2 Wins";
                gameTimer.Stop();
                restartButton.Enabled = true;
                restartButton.Visible = true;
            }
            else if (player2Score == -5)
            {
                winLabel.Text = "Player 1 Wins";
                gameTimer.Stop();
                restartButton.Enabled = true;
                restartButton.Visible = true;
            }
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            //Restart Everything
            
            restartButton.Enabled = false;
            restartButton.Visible = false;

            SpeedRand();
            PointRand();
            NegativeRand();
            FreezeSquareRand();

            winLabel.Text = "";
            p1pointsLabel.Text = "";
            p2pointsLabel.Text = "";

            player1Speed = 4;
            player2Speed = 4;

            player1Score = 0;
            player2Score = 0;

            player1.X = 100;
            player1.Y = 120;

            player2.X = 100;
            player2.Y = 240;

            gameTimer.Start();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
