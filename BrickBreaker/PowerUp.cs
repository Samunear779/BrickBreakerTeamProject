using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    class PowerUp
    {
        public int powerValue;
        public int x, y, pSpeed, size;
        public Color colour;

        // create a random number generator 
        Random randGen = new Random();

        public PowerUp(int _x, int _y, int _pSpeed, int _size)
        {
            x = _x;
            y = _y;
            pSpeed = _pSpeed;
            size = _size;

        }

        public void PaddleCollision(Paddle p, bool pMovingLeft, bool pMovingRight)
        {
            Rectangle powerUpRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);
            powerValue = randGen.Next(1, 5);

            if (powerUpRec.IntersectsWith(paddleRec))
            {
                switch (powerValue)
                {
                    case 1:
                        GameScreen.bSpeedMult = GameScreen.bSpeedMult + 5;
                        break;
                    case 2:
                        GameScreen.pSpeedMult = GameScreen.pSpeedMult + 5;
                        break;
                    case 3:
                        GameScreen.scoreMult = GameScreen.scoreMult + 5;
                        break;
                    case 4:
                        GameScreen.score = GameScreen.score + 2;
                        break;
                }
            }
        }

        //move the power up down the screen
        public void Move()
        {
            y = y - pSpeed;
        }
    }
}
