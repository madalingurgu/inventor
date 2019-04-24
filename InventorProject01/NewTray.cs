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

            foreach (Control gb in Controls)
            {
                if (gb is System.Windows.Forms.TextBox)
                {
                    gb.KeyUp += new KeyEventHandler(General_KeyUp);
                }

                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is NumericUpDown)
                        {
                            tb.KeyUp += new KeyEventHandler(General_KeyUp);
                        }
                        if (tb is GroupBox)
                        {
                            foreach (Control tbb in tb.Controls)
                            {
                                if (tbb is NumericUpDown)
                                {
                                    tbb.KeyUp += new KeyEventHandler(General_KeyUp);
                                }
                            }
                        }
                    }
                }
            }

            nud_TrayLen.Text = "";
            nud_TrayWid.Text = "";

            cb_TrayType.SelectedIndex = 0;
            cb_TrayMat.SelectedIndex = 0;
            cb_TrayCorner.SelectedIndex = 1;
            cb_TrayThk.SelectedIndex = 1;
            cb_TrayHei.SelectedIndex = 2;
            cb_BarbDim.SelectedIndex = 0;
            cb_BarbMat.SelectedIndex = 1;
            cb_BarbType.SelectedIndex = 0;
            cb_MatrixX.SelectedIndex = 0;
            cb_MatrixY.SelectedIndex = 0;
            cb_IndentType.SelectedIndex = 3;
            cb_Orientation.SelectedIndex = 0;

            btn_Preview.Enabled = false;
            btn_Save.Enabled = false;

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

            if (cb_TrayType.SelectedIndex == 0)
            {
                choice = standard;
            }
            else if (cb_TrayType.SelectedIndex == 1)
            {
                choice = inverted1;
            }
            else if (cb_TrayType.SelectedIndex == 2)
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
                oParameters["TLUN"].Expression = nud_TrayLen.Text;
                oParameters["TLAT"].Expression = nud_TrayWid.Text;
                oParameters["TH0"].Expression = cb_TrayHei.Text;
                oParameters["TGM"].Expression = cb_TrayThk.Text;

                if (cb_TrayCorner.SelectedIndex == 0)
                {
                    oParameters["TRC"].Expression = "16";
                }
                else if (cb_TrayCorner.SelectedIndex == 1)
                {
                    oParameters["TRC"].Expression = "43.6";
                }
                else if (cb_TrayCorner.SelectedIndex == 2)
                {
                    oParameters["TRC"].Expression = "69";
                }

                if (cb_BarbDim.SelectedIndex == 0)
                {
                    oParameters["BH0"].Expression = "15.9";
                    oParameters["BGM"].Expression = "4.8";
                }
                else if (cb_BarbDim.SelectedIndex == 1)
                {
                    oParameters["BH0"].Expression = "15.9";
                    oParameters["BGM"].Expression = "3.8";
                }
                else if (cb_BarbDim.SelectedIndex == 2)
                {
                    oParameters["BH0"].Expression = "14.8";
                    oParameters["BGM"].Expression = "4.8";
                }
                else if (cb_BarbDim.SelectedIndex == 3)
                {
                    oParameters["BH0"].Expression = "12.7";
                    oParameters["BGM"].Expression = "4.8";
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
            tb_Path.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        //Indent Type Combobox
        private void indentType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //round indent
            if (cb_IndentType.SelectedIndex == 0)
            {
                gb_IndentTI.Show();
                gb_IndentBO.Show();
                nud_IndentLenTI.Show();
                nud_IndentLenBO.Show();
                lb_IndentLenTI.Hide();
                lb_IndentLenBO.Hide();
                nud_IndentWidTI.Hide();
                nud_IndentWidBO.Hide();
                lb_IndentWidTI.Hide();
                lb_IndentWidBO.Hide();

                lb_Orientation.Hide();
                cb_Orientation.Hide();
                lb_IndentCornerRad.Hide();
                nud_IndentCornerRad.Hide();

                gb_IndentBottom.Show();
                gb_IndentRadius.Show();
                gb_IndentMatrix.Show();
                gb_IndentPitch.Show();
                lb_IndentHei.Show();
                nud_IndentHei.Show();
                ControlGroupBox("gb_Indent");
            }
            //obround indent
            else if (cb_IndentType.SelectedIndex == 1)
            {
                gb_IndentTI.Show();
                gb_IndentBO.Show();
                nud_IndentLenTI.Show();
                nud_IndentLenBO.Show();
                lb_IndentLenTI.Show();
                lb_IndentLenBO.Show();
                nud_IndentWidTI.Show();
                nud_IndentWidBO.Show();
                lb_IndentWidTI.Show();
                lb_IndentWidBO.Show();
                lb_Orientation.Show();
                cb_Orientation.Show();

                gb_IndentBottom.Show();
                gb_IndentRadius.Show();
                gb_IndentMatrix.Show();
                gb_IndentPitch.Show();
                lb_IndentHei.Show();
                nud_IndentHei.Show();
                ControlGroupBox("gb_Indent");
            }
            //rectangle indent
            else if (cb_IndentType.SelectedIndex == 2)
            {
                gb_IndentTI.Show();
                gb_IndentBO.Show();
                nud_IndentLenTI.Show();
                nud_IndentLenBO.Show();
                lb_IndentLenTI.Show();
                lb_IndentLenBO.Show();
                nud_IndentWidTI.Show();
                nud_IndentWidBO.Show();
                lb_IndentWidTI.Show();
                lb_IndentWidBO.Show();
                lb_Orientation.Show();
                cb_Orientation.Show();
                lb_IndentCornerRad.Show();
                nud_IndentCornerRad.Show();

                gb_IndentBottom.Show();
                gb_IndentRadius.Show();
                gb_IndentMatrix.Show();
                gb_IndentPitch.Show();
                lb_IndentHei.Show();
                nud_IndentHei.Show();
                ControlGroupBox("gb_Indent");
            }
            //none
            else
            {
                gb_IndentTI.Hide();
                gb_IndentBO.Hide();
                lb_Orientation.Hide();
                cb_Orientation.Hide();
                lb_IndentCornerRad.Hide();
                nud_IndentCornerRad.Hide();

                gb_IndentBottom.Hide();
                gb_IndentRadius.Hide();
                gb_IndentMatrix.Hide();
                gb_IndentPitch.Hide();
                lb_IndentHei.Hide();
                nud_IndentHei.Hide();
                ControlGroupBox("gb_Indent");
                nud_TrayWid.Focus();
                SendKeys.Send("~");
            }
        }

        private void ControlGroupBox(string groupBox)
        {
            btn_Preview.Enabled = false;
            btn_Save.Enabled = false;

            foreach (Control gb in Controls)
            {
                if (gb is GroupBox && gb.Name == groupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is NumericUpDown)
                        {
                            tb.Text = "";
                        }
                        if (tb is GroupBox)
                        {
                            foreach (Control tbb in tb.Controls)
                            {
                                if (tbb is NumericUpDown)
                                {
                                    tbb.Text = "";
                                }
                            }
                        }
                    }
                }
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
            oPartDoc.ComponentDefinition.SetEndOfPartToTopOrBottom(false);
            
            _invApp.ActiveView.GoHome();
        }

        //Cancel Button
        private void cancel_button_Click(object sender, EventArgs e)
        {
            //test for edit
            //TrayParameters();
            //oPartDoc.Update();
        }
        //Select path on click
        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tb_Path.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void nud_TrayLen_Leave(object sender, EventArgs e)
        {

        }
    }
    }
