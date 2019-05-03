using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;

        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockBotRec = new Rectangle(b.x, (b.y + (b.height / 2)), b.width, b.height);
            Rectangle blockTopRec = new Rectangle(b.x, b.y, b.width, b.height / 2);
            Rectangle blockLeftRec = new Rectangle(b.x, b.y + (b.height / 4), b.width / 2, b.height / 2);
            Rectangle blockRightRec = new Rectangle(b.x + (b.width / 2), b.y + (b.height / 4), b.width / 2, b.height / 2);

            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockTopRec))
            {
                if (ySpeed > 0)
                {
                    ySpeed = ySpeed * -1;
                }
            }
            else if (ballRec.IntersectsWith(blockBotRec))
            {
                if (ySpeed < 0)
                {
                    ySpeed = ySpeed * -1;
                }
            }
            else if (ballRec.IntersectsWith(blockLeftRec))
            {
                if (xSpeed > 0)
                {
                    xSpeed = xSpeed * -1;
                }

            }
            else if (ballRec.IntersectsWith(blockRightRec))
            {
                if (xSpeed < 0)
                {
                    xSpeed = xSpeed * -1;
                }
            }

            if (blockBotRec.IntersectsWith(ballRec) || blockTopRec.IntersectsWith(ballRec) || blockLeftRec.IntersectsWith(ballRec) || blockRightRec.IntersectsWith(ballRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                if (x < p.x + p.width * 4 / 8) // divide the paddle into 8 sections with different angles of ball launch
                {
                    ySpeed = -5;
                    xSpeed = -5;
                }
                else if (x < p.x + p.width * 5 / 8)
                {
                    ySpeed = -5;
                    xSpeed = 5;
                }
                else if (x <= p.x + p.width / 8)
                {
                    ySpeed = -2;
                    xSpeed = -8;
                }
                else if (x < p.x + p.width * 2 / 8)
                {
                    ySpeed = -3;
                    xSpeed = -7;
                }
                else if (x < p.x + p.width * 3 / 8)
                {
                    ySpeed = -4;
                    xSpeed = -6;
                }
                else if (x < p.x + p.width * 6 / 8)
                {
                    ySpeed = -4;
                    xSpeed = 6;
                }
                else if (x < p.x + p.width * 7 / 8)
                {
                    ySpeed = -3;
                    xSpeed = 7;
                }
                else if ((x + size) <= p.x + p.width)
                {
                    ySpeed = -2;
                    xSpeed = 8;
                }

                if (pMovingLeft)
                    xSpeed = -Math.Abs(xSpeed);
                else if (pMovingRight)
                    xSpeed = Math.Abs(xSpeed);
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                if (xSpeed <= 0)
                {
                    xSpeed = xSpeed * -1;
                }
            }

            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                if (xSpeed >= 0)
                {
                    xSpeed = xSpeed * -1;
                }
            }

            // Collision with top wall
            if (y <= 41)
            {
                if (ySpeed <= 0)
                {
                    ySpeed = ySpeed * -1;
                }
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
