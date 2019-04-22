using System;
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
    public partial class NewTray : Form
    {

        public void myControlText_Leave(object sender, EventArgs e)
        {

        }

        private void myTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            int TbCount = 0;
            int allTbCount = 0;
            int NudCount = 0;
            int allNudCount = 0;

            foreach (Control tb in Controls)
            {

                if (tb is System.Windows.Forms.NumericUpDown)
                {
                    allNudCount++;
                }

                if (tb is System.Windows.Forms.TextBox)
                {
                    allTbCount++;
                    if (!(tb.Text.Length <= 0))
                    {
                        TbCount++;
                    }
                }


            }

            MessageBox.Show("Numeric Up Down controls: " + allNudCount);

            if (allTbCount == TbCount)
            {
                preview_button.Enabled = true;
                save_button.Enabled = false;
            }
            else
            {
                preview_button.Enabled = false;
                save_button.Enabled = false;
            }
        }

    }
}
