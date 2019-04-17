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

        private void trayLength_numericUpDown_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(trayLength_numericUpDown.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                trayLength_numericUpDown.Select(0, trayLength_numericUpDown.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(trayLength_numericUpDown, errorMsg);
            }
        }

        private void trayLength_numericUpDown_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(trayLength_numericUpDown, "");
        }

        private void trayWidth_numericUpDown_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(trayWidth_numericUpDown.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                trayWidth_numericUpDown.Select(0, trayWidth_numericUpDown.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(trayWidth_numericUpDown, errorMsg);
            }
        }

        private void trayWidth_numericUpDown_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(trayWidth_numericUpDown, "");
        }

        private void numericUpDown3_Validating(object sender, CancelEventArgs e)
        {
            if (!(indentType_comboBox.SelectedIndex == 3))
            {
                string errorMsg;
                if (!ValidText(numericUpDown3.Text, out errorMsg))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    numericUpDown3.Select(0, numericUpDown3.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(numericUpDown3, errorMsg);
                }
            }
        }

        private void numericUpDown3_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(numericUpDown3, "");
        }

        private void numericUpDown1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numericUpDown2_Validated(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numericUpDown7_Validated(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_Validating(object sender, CancelEventArgs e)
        {

        }

        private void numericUpDown6_Validated(object sender, EventArgs e)
        {

        }









        private void roundIndentControl1_Validating(object sender, CancelEventArgs e)
        {
                string errorMsg;
                if (!ValidText(roundIndentControl1.roundIndentLength_numericUpDown.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 0)
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    roundIndentControl1.roundIndentLength_numericUpDown.Select(0, roundIndentControl1.roundIndentLength_numericUpDown.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(roundIndentControl1.roundIndentLength_numericUpDown, errorMsg);
                }
                if (!ValidText(roundIndentControl1.roundIndentWidth_numericUpDown.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 0)
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    roundIndentControl1.roundIndentWidth_numericUpDown.Select(0, roundIndentControl1.roundIndentWidth_numericUpDown.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(roundIndentControl1.roundIndentWidth_numericUpDown, errorMsg);
                }
        }

        private void roundIndentControl1_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(roundIndentControl1.roundIndentLength_numericUpDown, "");
            errorProvider1.SetError(roundIndentControl1.roundIndentWidth_numericUpDown, "");
        }

        private void obroundIndentControl1_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(obroundIndentControl1.numericUpDown5.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                obroundIndentControl1.numericUpDown5.Select(0, obroundIndentControl1.numericUpDown5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(obroundIndentControl1.numericUpDown5, errorMsg);
            }
            if (!ValidText(obroundIndentControl1.numericUpDown1.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                obroundIndentControl1.numericUpDown1.Select(0, obroundIndentControl1.numericUpDown1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(obroundIndentControl1.numericUpDown1, errorMsg);
            }
            if (!ValidText(obroundIndentControl1.numericUpDown2.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                obroundIndentControl1.numericUpDown2.Select(0, obroundIndentControl1.numericUpDown2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(obroundIndentControl1.numericUpDown2, errorMsg);
            }
            if (!ValidText(obroundIndentControl1.numericUpDown3.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 1)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                obroundIndentControl1.numericUpDown3.Select(0, obroundIndentControl1.numericUpDown3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(obroundIndentControl1.numericUpDown3, errorMsg);
            }
        }

        private void obroundIndentControl1_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(obroundIndentControl1.numericUpDown5, "");
            errorProvider1.SetError(obroundIndentControl1.numericUpDown1, "");
            errorProvider1.SetError(obroundIndentControl1.numericUpDown2, "");
            errorProvider1.SetError(obroundIndentControl1.numericUpDown3, "");
        }

        private void rectangleIndentControl1_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidText(rectangleIndentControl1.numericUpDown5.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 2)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                rectangleIndentControl1.numericUpDown5.Select(0, rectangleIndentControl1.numericUpDown5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(rectangleIndentControl1.numericUpDown5, errorMsg);
            }
            if (!ValidText(rectangleIndentControl1.numericUpDown1.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 2)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                rectangleIndentControl1.numericUpDown1.Select(0, rectangleIndentControl1.numericUpDown1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(rectangleIndentControl1.numericUpDown1, errorMsg);
            }
            if (!ValidText(rectangleIndentControl1.numericUpDown2.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 2)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                rectangleIndentControl1.numericUpDown2.Select(0, rectangleIndentControl1.numericUpDown2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(rectangleIndentControl1.numericUpDown2, errorMsg);
            }
            if (!ValidText(rectangleIndentControl1.numericUpDown3.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 2)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                rectangleIndentControl1.numericUpDown3.Select(0, rectangleIndentControl1.numericUpDown3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(rectangleIndentControl1.numericUpDown3, errorMsg);
            }
            if (!ValidText(rectangleIndentControl1.numericUpDown4.Text, out errorMsg) && indentType_comboBox.SelectedIndex == 2)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                rectangleIndentControl1.numericUpDown4.Select(0, rectangleIndentControl1.numericUpDown4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(rectangleIndentControl1.numericUpDown4, errorMsg);
            }
        }

        private void rectangleIndentControl1_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(rectangleIndentControl1.numericUpDown5, "");
            errorProvider1.SetError(rectangleIndentControl1.numericUpDown1, "");
            errorProvider1.SetError(rectangleIndentControl1.numericUpDown2, "");
            errorProvider1.SetError(rectangleIndentControl1.numericUpDown3, "");
            errorProvider1.SetError(rectangleIndentControl1.numericUpDown4, "");
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

                preview_button.Enabled = true;
                save_button.Enabled = true;
                return true;
            }
        }
    }
}
