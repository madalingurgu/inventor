using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorProject01
{
    public partial class RoundIndentControl : UserControl
    {
        public RoundIndentControl()
        {
            InitializeComponent();

            //Form f = new NewTray();
            //f.ValidateChildren();
        }

        private void roundIndentLength_numericUpDown_Validating(object sender, CancelEventArgs e)
        {
            //string errorMsg;
            //if (!ValidText(roundIndentLength_numericUpDown.Text, out errorMsg))
            //{
                // Cancel the event and select the text to be corrected by the user.
                //e.Cancel = true;
                //roundIndentLength_numericUpDown.Select(0, roundIndentLength_numericUpDown.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                //this.errorProvider_round.SetError(roundIndentLength_numericUpDown, errorMsg);
            //}
        }

        private void roundIndentLength_numericUpDown_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider_round.SetError(roundIndentLength_numericUpDown, "");
        }

        private void roundIndentWidth_numericUpDown_Validating(object sender, CancelEventArgs e)
        {

        }

        private void roundIndentWidth_numericUpDown_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            //errorProvider_round.SetError(comboBox1, "");
        }


    }
}
