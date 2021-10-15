using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DonkeyKong
{
    partial class Canvas : Form
    {
        public Game game;
        public Canvas()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Load += Canvas_Load;
            Image image = Bitmap.FromFile("D:\\Code\\Lessons\\donkeykong\\DonkeyKong\\Sprites\\LevelItems\\girder.bmp");
            
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            game = new Game(this);
        }
    }
}
