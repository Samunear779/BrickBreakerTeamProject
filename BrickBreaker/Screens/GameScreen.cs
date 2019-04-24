/*  Created by: Steven HL
 *  Project: Brick Breaker
 *  Date: Tuesday, April 4th
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.Threading;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown, escDown, gamePaused;

        // Game values
        string level, levelName;
        public static int lives, score, scoreMult;
        public static int bSpeedMult = 1;
        public static int pSpeedMult = 1;
        Font scoreFont = new Font("Mongolian Baiti", 14, FontStyle.Regular);
        SolidBrush scoreBrush = new SolidBrush(Color.White);

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();
        List<Ball> ballList = new List<Ball>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);


        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;

            scoreMult = 1;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = escDown = gamePaused = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball           
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);
            ballList.Add(ball);

            //LevelLoad("1");

            #region Creates blocks for generic level. Need to replace with code that loads levels.

            //blocks.Clear();
            //int x = 10;

            //while (blocks.Count < 12)
            //{
            //    x += 57;
            //    Block b1 = new Block(x, 10, 2);
            //    blocks.Add(b1);
            //}

            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Escape:
                    if (gamePaused == true)
                    {
                        //restart the game
                        gamePaused = false;
                        gameTimer.Enabled = true;
                    }
                    else
                    {
                        gamePaused = true;
                    }

                    //TODO: change screen
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //pause the game
            if (gamePaused == true)
            {
                gameTimer.Enabled = false;
            }

            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            if (escDown == true)
            {
                gamePaused = !gamePaused;
            }            

            // Move ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            foreach(Ball b in ballList)
            {
                if (ballList.Count() < 1)
                {
                    if (b.BottomCollision(this))
                    {
                        ballList.Remove(b);
                    }
                }

                if(ballList.Count() == 1)
                {
                    if (b.BottomCollision(this))
                    {
                        lives--;

                        // Moves the ball back to origin
                        b.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                        b.y = (this.Height - paddle.height) - 85;
                        b.xSpeed = 6;
                        b.ySpeed = 6;
                        b.size = 20;

                        Refresh();
                        Thread.Sleep(2000);

                        if (lives == 0)
                        {
                            gameTimer.Enabled = false;
                            OnEnd();
                        }
                    }
                }
            }


            if (ballList.Count() == 0)
            {
                lives--;

                // Moves the ball back to origin
                int ballX = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                int ballY = (this.Height - paddle.height) - 85;
                int xSpeed = 6;
                int ySpeed = 6;
                int ballSize = 20;

                ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);
                ballList.Add(ball);
                
                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            } 

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle, leftArrowDown, rightArrowDown);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    --b.hp;
                    //blocks.Remove(b);

                    if (b.hp == 0)
                    {
                        blocks.Remove(b);
                        score = score + 100*scoreMult;
                    }

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            //redraw the screen
            Refresh();
        }

        //Doesn't work yet as it doesn't actually grab values for x, y and hp.
        private void LevelLoad(string levelNo)
        {

            XmlReader levelReader = XmlReader.Create("Resources/Levels.xml");
            while (levelReader.Read())
            {
                levelReader.ReadToFollowing("level");
                level = levelReader.GetAttribute("number");
                if (level == levelNo)
                {
                    XmlReader brickReader = XmlReader.Create("Resources/Levels.xml");
                    while (brickReader.Read())
                    {
                        string newX, newY, newHP;
                        Block b = new Block(0, 0, 0);

                        brickReader.ReadToFollowing("brick");
                        newX = brickReader.GetAttribute("x");
                        newY = brickReader.GetAttribute("y");
                        newHP = brickReader.GetAttribute("hp");

                        //brickReader.ReadToDescendant("x");
                        //newX = brickReader.ReadString();

                        //brickReader.ReadToNextSibling("y");
                        //newY = brickReader.ReadString();

                        //brickReader.ReadToNextSibling("hp");
                        //newHP = brickReader.ReadString();

                        b.x = Convert.ToInt16(newX);
                        b.y = Convert.ToInt16(newY);
                        b.hp = Convert.ToInt16(newHP);

                        blocks.Add(b);
                    }
                    brickReader.Close();
                }
                levelName = levelReader.GetAttribute("name");
                levelReader.Close();
            }



        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();
            
            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                SolidBrush blockBrush = new SolidBrush(b.UpdateColour());
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            //draws score
            e.Graphics.DrawString("Score: " + score, scoreFont, scoreBrush, 0, 25);

            //draw lives
            e.Graphics.DrawString("Lives: " + lives, scoreFont, scoreBrush, this.Width - 100, 25);
        }
    }
}
