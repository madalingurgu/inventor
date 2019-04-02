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

        bool _started = false;


        public void PlaneVisibilityOff(PartDocument doc, WorkFeatureTypes featureTypes, Boolean visible)
        {
            //switch (featureTypes)
            //{
                //case WorkFeatureTypes.Planes:
                    //WorkPlanes workPlanes;
                    //WorkPlane workPlane;
                   // workPlanes = doc.ComponentDefinition.WorkPlanes;
                    //foreach
                    //{
                     //   workPlane.Visible = Visible;
                   // }
                    //break;
            //}
        }

        public NewTray()
        {
            InitializeComponent();

            roundIndentControl1.Hide();
            obroundIndentControl1.Hide();
            rectangleIndentControl1.Hide();

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

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox6.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 0)
            {
                roundIndentControl1.Show();
                obroundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
            }
            else if (comboBox8.SelectedIndex == 1)
            {
                obroundIndentControl1.Show();
                roundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
            }
            else if (comboBox8.SelectedIndex == 2)
            {
                rectangleIndentControl1.Show();
                roundIndentControl1.Hide();
                obroundIndentControl1.Hide();
            }
            else
            {
                roundIndentControl1.Hide();
                obroundIndentControl1.Hide();
                rectangleIndentControl1.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewDoc();
        }

        public void NewDoc()
        {
            string choice, standard, inverted1, inverted2;

            choice = "";
            standard = "C:/Users/gxmadalin/Desktop/tray template/BBT # STD.ipt";
            inverted1 = "C:/Users/gxmadalin/Desktop/tray template/BBT # INV 1.ipt";
            inverted2 = "C:/Users/gxmadalin/Desktop/tray template/BBT # INV 2.ipt";

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
            MessageBox.Show(choice);

            oPartDoc = (PartDocument)_invApp.Documents.Add(DocumentTypeEnum.kPartDocumentObject, choice);
        }
    }
}
