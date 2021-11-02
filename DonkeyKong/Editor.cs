using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonkeyKong
{
    class Editor
    {
        private Thread gameLoopThread;
        public bool canvasClosed = false;

        public static HashSet<string> keys;
        public static Point lastClickLocation;
        public static Point mouseLocation;
        public Canvas canvas;
        public Toolbar toolbar;
        public Level level;

        private ManualResetEvent pause = new ManualResetEvent(true);
        public static List<Entity> EntityList = new List<Entity>();


        public Editor(Canvas canvas, Level level)
        {
            this.canvas = canvas;
            canvas.KeyDown += Canvas_KeyPress;
            canvas.KeyUp += Canvas_KeyRelease;
            canvas.MouseUp += Canvas_MouseUp;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.Paint += Canvas_Renderer;

            keys = new HashSet<string>();
            toolbar = new Toolbar();
            this.level = level;

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                keys.Add("mouse1");
                lastClickLocation = e.Location;
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                keys.Remove("mouse1");
            }
        }

        public void PauseGame()
        {
            if (!pause.WaitOne(0))
            {
                pause.Set();
            }
            else
            {
                pause.Reset();
            }
        }



        private void Canvas_KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                keys.Remove("left");
            }
            else if (e.KeyCode == Keys.Right)
            {
                keys.Remove("right");
            }
            else if (e.KeyCode == Keys.Space)
            {
                keys.Remove("space");
            }
            else if (e.KeyCode == Keys.S)
            {
                keys.Remove("s");
            }
        }
        //Key release listener and logic.

        private void Canvas_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                keys.Add("left");
            }
            else if (e.KeyCode == Keys.Right)
            {
                keys.Add("right");
            }
            else if (e.KeyCode == Keys.Space)
            {
                keys.Add("space");
            }
            else if (e.KeyCode == Keys.S)
            {
                keys.Add("s");
            }
        }

        private void Canvas_Renderer(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);
            for (int i = 0; i < EntityList.Count; i++)
            {
                EntityList[i].Update();
            }
            for (int i = 0; i < EntityList.Count; i++)
            {
                EntityList[i].Render(graphics);
            }
            level.Update();
        }

        public void GameLoop()
        {
            while (gameLoopThread.IsAlive && !canvasClosed) // the && checks for a logical condition  - if canvasClosed is NOT closed
            {
                canvas.BeginInvoke((MethodInvoker)delegate { canvas.Refresh(); });
                pause.WaitOne();
                Thread.Sleep(1);
            }
        }

    }
}