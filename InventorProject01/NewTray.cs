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

public enum WorkFeatureTypes
{
    Planes, Axes, Points
}

namespace InventorProject01
{
    public partial class NewTray : Form
    {
        Inventor.Application _invApp;
        PartDocument oPartDoc;
        PartComponentDefinition oCompDef;

        bool _started = false;

       

        public void PlaneVisibilityOff(PartDocument doc, WorkFeatureTypes FeatureType, Boolean visible)
        {
            switch (FeatureType)
            {
                case (WorkFeatureTypes.Planes):
                    WorkPlanes workPlanes;
                    workPlanes = doc.ComponentDefinition.WorkPlanes;
                    foreach (WorkPlane workPlane in workPlanes)
                    {
                        workPlane.Visible = visible;
                    }
                    break;
            }
        }

        public NewTray()
        {
            InitializeComponent();

            trayLength_numericUpDown.Text = "";
            trayWidth_numericUpDown.Text = "";
            numericUpDown3.Text = "";
            numericUpDown2.Text = "";
            numericUpDown1.Text = "";
            numericUpDown7.Text = "";
            numericUpDown6.Text = "";

            roundIndentControl1.roundIndentWidth_numericUpDown.Text = "";
            roundIndentControl1.roundIndentLength_numericUpDown.Text = "";

            rectangleIndentControl1.numericUpDown5.Text = "";
            rectangleIndentControl1.numericUpDown4.Text = "";
            rectangleIndentControl1.numericUpDown3.Text = "";
            rectangleIndentControl1.numericUpDown2.Text = "";
            rectangleIndentControl1.numericUpDown1.Text = "";

            obroundIndentControl1.numericUpDown5.Text = "";
            obroundIndentControl1.numericUpDown3.Text = "";
            obroundIndentControl1.numericUpDown2.Text = "";
            obroundIndentControl1.numericUpDown1.Text = "";

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            trayCorner_comboBox.SelectedIndex = 1;
            trayThickness_comboBox.SelectedIndex = 1;
            trayHeight_comboBox.SelectedIndex = 2;
            comboBox7.SelectedIndex = 0;
            comboBox9.SelectedIndex = 1;
            comboBox10.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;


            indentType_comboBox.SelectedIndex = 3;
            rectangleIndentControl1.comboBox1.SelectedIndex = 0;
            obroundIndentControl1.comboBox1.SelectedIndex = 0;

            roundIndentControl1.Hide();
            obroundIndentControl1.Hide();
            rectangleIndentControl1.Hide();
            preview_button.Enabled = false;
            save_button.Enabled = false;

            try
            {
                _invApp = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");

            }
            catch (Exception ex)
            {
                try
                {
                    Type invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    _invApp = (Inventor.Application)System.Activator.CreateInstance(invAppType);
                    _invApp.Visible = true;

                    //Note: if the Inventor session is left running after this
                    //form is closed, there will still an be and Inventor.exe 
                    //running. We will use this Boolean to test in Form1.Designer.cs 
                    //in the dispose method whether or not the Inventor App should
                    //be shut down when the form is closed.
                    _started = true;

                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.ToString());
                    MessageBox.Show("Unable to get or start Inventor");
                }
            }

        }

        private void NewTray_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_started == true)
            {
                _invApp.Quit();
            }
            _invApp = null;
        }

        private void NewTray_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        public void NewDoc()
        {
            string home, work, choice, standard, inverted1, inverted2;

            home = "C:/Users/MG/Desktop/temp/";
            work = "C:/Users/gxmadalin/Desktop/tray template/";
            choice = "";
            standard = work + "BBT # STD.ipt";
            inverted1 = work + "BBT # INV 1.ipt";
            inverted2 = work + "BBT # INV 2.ipt";

            if (comboBox1.SelectedIndex == 0)
            {
                choice = standard;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                choice = inverted1;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                choice = inverted2;
            }
            else
            {
                MessageBox.Show("No Tray Type Selected!");
                return;
            }
            //Test String
            //MessageBox.Show(choice);

            oPartDoc = (PartDocument)_invApp.Documents.Add(DocumentTypeEnum.kPartDocumentObject, choice);
        }

        public void TrayParameters()
        {
            oCompDef = oPartDoc.ComponentDefinition;
            Parameters oParameters = oCompDef.Parameters;
            //textBox2.Text = oParameters["TLUN"].Expression;
            try
            {
                oParameters["TLUN"].Expression = trayLength_numericUpDown.Text;
                oParameters["TLAT"].Expression = trayWidth_numericUpDown.Text;
                oParameters["TH0"].Expression = trayHeight_comboBox.Text;
                oParameters["TGM"].Expression = trayThickness_comboBox.Text;

                if (trayCorner_comboBox.SelectedIndex == 0)
                {
                    oParameters["TRC"].Expression = "16";
                }
                else if (trayCorner_comboBox.SelectedIndex == 1)
                {
                    oParameters["TRC"].Expression = "43.6";
                }
                else if (trayCorner_comboBox.SelectedIndex == 2)
                {
                    oParameters["TRC"].Expression = "69";
                }
                else
                {
                    //oParameters["TRC"].Expression = "43.6";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Missing Parameter!");
                //MessageBox.Show(ex.ToString());
            }
        }

        public void ObroundIndent()
        {

        }

        //Folder Browser Button
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox6.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        //Indent Type Combobox
        private void indentType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (indentType_comboBox.SelectedIndex == 0)
            {
                roundIndentControl1.Show();
                obroundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
                groupBox4.Show();
                groupBox5.Show();
                groupBox6.Show();
                groupBox7.Show();
                label17.Show();
                numericUpDown3.Show();
            }
            else if (indentType_comboBox.SelectedIndex == 1)
            {
                obroundIndentControl1.Show();
                roundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
                groupBox4.Show();
                groupBox5.Show();
                groupBox6.Show();
                groupBox7.Show();
                label17.Show();
                numericUpDown3.Show();
            }
            else if (indentType_comboBox.SelectedIndex == 2)
            {
                rectangleIndentControl1.Show();
                roundIndentControl1.Hide();
                obroundIndentControl1.Hide();
                groupBox4.Show();
                groupBox5.Show();
                groupBox6.Show();
                groupBox7.Show();
                label17.Show();
                numericUpDown3.Show();
            }
            else
            {
                roundIndentControl1.Hide();
                obroundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
                groupBox4.Hide();
                groupBox5.Hide();
                groupBox6.Hide();
                groupBox7.Hide();
                label17.Hide();
                numericUpDown3.Hide();
            }
        }

        //Save Button
        private void save_button_Click(object sender, EventArgs e)
        {

        }

        //Preview Button
        private void preview_button_Click(object sender, EventArgs e)
        {
            NewDoc();

            TrayParameters();

            PlaneVisibilityOff(oPartDoc, WorkFeatureTypes.Planes, false);

            oPartDoc.Update();
            _invApp.ActiveView.GoHome();
        }

        //Cancel Button
        private void cancel_button_Click(object sender, EventArgs e)
        {
            
        }
        //Select path on click
        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox6.Text = folderBrowserDialog1.SelectedPath.ToString();
        }


    }
}
