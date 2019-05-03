using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int width = 50;
        public int height = 25;

        public int x;
        public int y; 
        public int hp;
        public Color colour;
        public Rectangle rightRec, leftRec, topRec, bottomRec;

        public static Random rand = new Random();

        public Block(int _x, int _y, int _hp)
        {
            x = _x;
            y = _y;
            hp = _hp;
            leftRec = new Rectangle(x, y, 2, height);
            rightRec = new Rectangle(x + width, y, 2, height);
            topRec = new Rectangle(x, y, width, 2);
            bottomRec = new Rectangle(x, y + height, width, 2);
        }
        public Image UpdateColour()
        {
            switch (hp)
            {
                case 1:
                     return Properties.Resources.redBrick2;
                    
                case 2:
                    return Properties.Resources.purpBrick2;
                    
                case 3:
                    return Properties.Resources.blueBrick2;
                   
                case 4:
                    return Properties.Resources.greenBrick2;
                    
            }
            return Properties.Resources.button;
        }
    }
} 