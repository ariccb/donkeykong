﻿using System;
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
            canvas = new Canvas();
            canvas.Show();
        }

        private void NewLevel_Load(object sender, EventArgs e)
        {

        }
    }
}
