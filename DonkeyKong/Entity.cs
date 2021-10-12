using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DonkeyKong
{
    abstract class Entity
    {
        public event EventHandler Deleted;
        public int Height
        {
            get
            { return sprite.Height; }
        }
        public int Width
        {
            get
            { return sprite.Width; }
        }

        public Image sprite;
        public float scale = 1;
        public int x;
        public int y;
        public Entity(string ImgPath)
        {
            sprite = Image.FromFile(ImgPath);
            Game.EntityList.Add(this);
        }
        public int[,] GetBoundingPoints()
        {
            int[,] points =
            {
                { x, y },                   // Top left         0
                { x + Width, y },           // Top right        1
                { x, y + Height },          // Bottom left      2
                { x + Width, y + Height}    // Bottom right     3
                };
            return points;
        }
        public bool IsColliding(Entity entity)
        {
            int[,] points1 = GetBoundingPoints();
            int[,] points2 = entity.GetBoundingPoints();

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0]));
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1]));

            if (XOverlap > 0 && YOverlap > 0)
            { return true; }
            else
            { return false; }
        }

        public abstract void Update();
        public void Render(Graphics graphics)
        {
            graphics.DrawImage(sprite, scale * x, scale * y, scale * Width, scale * Height);
        }
        public virtual void Delete()
        {
            Game.EntityList.Remove(this);
            EventHandler handler = Deleted;
            handler?.Invoke(this, new EventArgs());
        }
    }
}