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
    public partial class Form1 : Form
    {
        NewLevel levelDialog; //this is declaring that it will exist
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            levelDialog = new NewLevel(); // this is instantiating it, ie. creating it
            levelDialog.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
