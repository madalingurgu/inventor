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

        private void General_KeyUp(object sender, KeyEventArgs e)
        {
            int Count = 0;
            int allCount = 0;

            foreach (Control gb in Controls)
            {
                if (gb is System.Windows.Forms.TextBox)
                {
                    allCount++;
                    //MessageBox.Show("Text Box Name = " + gb.Name);
                    if (gb.Text.Length > 0)
                    {
                        Count++;
                    }
                }

                if (gb is GroupBox && cb_IndentType.SelectedIndex == 3 && (gb.Name == "groupBox1" || gb.Name == "groupBox2"))
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is NumericUpDown)
                        {
                            allCount++;
                            //MessageBox.Show("Numeric Up Down Name = " + tb.Name);
                            if (tb.Text.Length > 0)
                            {
                                Count++;
                            }
                        }
                    }
                }

                if (gb is GroupBox && !(cb_IndentType.SelectedIndex == 3))
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is NumericUpDown)
                        {
                            allCount++;
                            //MessageBox.Show("Numeric Up Down Name = " + tb.Name);
                            if (tb.Text.Length > 0)
                            {
                                Count++;
                            }
                        }

                        if (tb is GroupBox)
                        {
                            //MessageBox.Show("Group Box Name = " + tb.Name);
                            foreach(Control tbb in tb.Controls)
                            {
                                //MessageBox.Show("Numeric UpDown Name = " + tbb.Name);
                                if (tbb is NumericUpDown)
                                {
                                    allCount++;
                                    if (tbb.Text.Length > 0)
                                    {
                                        Count++;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            //MessageBox.Show(Count.ToString() + "/" + allCount.ToString());
            if (Count == allCount)
            {
                btn_Preview.Enabled = true;
                btn_Save.Enabled = false;
            }
            else
            {
                btn_Preview.Enabled = false;
                btn_Save.Enabled = false;
            }
        }

    }
}
