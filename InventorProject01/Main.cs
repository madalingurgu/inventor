﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Inventor;

namespace InventorProject01
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChild();
        }

        private void OpenChild()
        {
            Form f = new NewTray();
            f.Show();
        }

    }
}
