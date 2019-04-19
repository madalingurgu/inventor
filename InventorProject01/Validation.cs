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
        //textBox1 - BBT number validating
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(textBox1.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBox1.Select(0, textBox1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBox1, errorMsg);
            }
        }

        //textBox1 validated
        private void textBox1_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBox1, "");
            textBox6.Focus();
        }

        //textBox6 - path validating
        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(textBox6.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBox6.Select(0, textBox6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBox6, errorMsg);
            }
        }

        private void textBox6_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBox6, "");
            trayLength_numericUpDown.Focus();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(comboBox1.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                comboBox1.Select(0, comboBox1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(comboBox1, errorMsg);
            }
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(comboBox1, "");
        }
        

        private void numericUpDown6_Validating(object sender, CancelEventArgs e)
        {
            if (!(indentType_comboBox.SelectedIndex == 3))
            {
                string errorMsg;
                if (!ValidText(numericUpDown6.Text, out errorMsg))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    numericUpDown6.Select(0, numericUpDown6.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(numericUpDown6, errorMsg);
                }
            }
        }

        private void numericUpDown6_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(numericUpDown6, "");
        }





        public bool ValidText(string textValue, out string errorMessage)
        {
            // Confirm that the Tray number string is not empty.
            if (textValue.Length <= 0)
            {
                errorMessage = "Value required!";

                preview_button.Enabled = false;
                save_button.Enabled = false;
                return false;
            }
            else
            {
                errorMessage = "";

                //preview_button.Enabled = true;
                //save_button.Enabled = true;
                return true;
            }
        }
    }
}
