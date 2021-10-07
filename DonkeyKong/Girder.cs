using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKong
{
    class Girder
    {
        Image sprite;
        int x = 0;
        int y = 0;
        int width = 16;
        int height = 8;
        bool hasClicked = false;
        bool isClicked = false;

        public Girder()
        {
            sprite = Bitmap.FromFile("D:\\Code\\Lessons\\donkeykong\\DonkeyKong\\Sprites\\girder.bmp");
        }
        public void Update()
        {
            if (Game.keys.Contains("mouseleft"))
            {
                if (!hasClicked)
                {
                    hasClicked = true;
                    int clickx = Game.lastClickLocation.X;
                    int clicky = Game.lastClickLocation.Y;
                    if((clickx <= (x + width) && clickx >= x && clicky >= y && clicky <= (y + height)))
                    {
                        isClicked = true;
                    }
                }
            }
            else
            {
                isClicked = false;
                hasClicked = false;
            }
            if (isClicked)
            {
                x = Game.mouseLocation.X;
                y = Game.mouseLocation.Y;
            }
        }

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}
       
                 
          