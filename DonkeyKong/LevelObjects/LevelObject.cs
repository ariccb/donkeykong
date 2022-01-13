using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;


namespace DonkeyKong
{
    [XmlInclude(typeof(OilDrum))]
    [XmlInclude(typeof(Ladder))]
    [XmlInclude(typeof(Girder))]
    [XmlInclude(typeof(Bitmap))]
    [Serializable]
    public class LevelObject : Entity
    {
        bool hasClicked = false;
        bool isClicked = false;
        int xoffset = 0;
        int yoffset = 0;
        
        public event EventHandler Clicked;
        public event EventHandler Released;

        public LevelObject() : base("")
        {
            
        }

        public LevelObject(string ImgPath) : base(ImgPath)
        {
            Editor.level.LevelObjectList.Add(this);
        }
        public override void Update()
        {
            if (Editor.keys.Contains("mouse1"))
            {
                if (!hasClicked)
                {
                    hasClicked = true;
                    int clickx = Editor.lastClickLocation.X;
                    int clicky = Editor.lastClickLocation.Y;
                    if (clickx <= (x + Width) && clickx >= x && clicky >= y && clicky <= (y + Height))
                    {
                        isClicked = true;
                        xoffset = x - clickx;
                        yoffset = y - clicky;
                    }
                }
            }
            else
            {
                if (isClicked)
                {
                    Released?.Invoke(this, new EventArgs()); // ? means it only gets called if it has event handlers
                }
                isClicked = false;
                hasClicked = false;
            }
            if (isClicked)
            {
                x = Editor.mouseLocation.X + xoffset;
                y = Editor.mouseLocation.Y + yoffset;
                foreach (Entity entity in Editor.EntityList)
                {

                    if (entity != this)
                    {
                        entity.PushOutCollision(this);
                    }    
                }
                //Clicked?.Invoke(this, new EventArgs());
            }
        }

        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, x, y);
        }
    }
}