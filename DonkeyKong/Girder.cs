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

        public Girder()
        {
            sprite = Bitmap.FromFile("D:\\Code\\Lessons\\donkeykong\\DonkeyKong\\Sprites\\girder.bmp");
        }
        public bool IsClicked(int mousex, int mousey)
        {
            if (mousex <= (x + width) && mousex >= x && mousey <= y && mousey >= (y - height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}
      
                 
          