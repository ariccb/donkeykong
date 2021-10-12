using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DonkeyKong
{
    class LevelObject : Entity
    {
        bool hasClicked = false;
        bool isClicked = false;

        public LevelObject(string ImgPath) : base(ImgPath)
        {

        }
        public override void Update()
        {
            if (Game.keys.Contains("mouse1"))
            {
                if (!hasClicked)
                {
                    hasClicked = true;
                    int clickx = Game.lastClickLocation.X;
                    int clicky = Game.lastClickLocation.Y;
                    if (clickx <= (x + Width) && clickx >= x && clicky >= y && clicky <= (y + Height))
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