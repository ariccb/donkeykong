using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonkeyKong
{
    public partial class NewLevel : Form
    {
        Canvas canvas;
        public NewLevel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level level = new Level();
            level.name = textBox1.Text;
            canvas = new Canvas(level);
            canvas.Show();
        }

        private void NewLevel_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Level level = Level.Deserialize(textBox1.Text);
            canvas = new Canvas(level);
            canvas.Show();
        }
    }
}
