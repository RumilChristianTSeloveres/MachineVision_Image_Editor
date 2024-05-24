using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineVisionFinals
{
     public partial class PwdFacialForm : Form
     {
          public PwdFacialForm()
          {
               InitializeComponent();
          }

          //Log-in Button
          private void btnPassword_Click(object sender, EventArgs e)
          { 
            try
            {
                this.Hide();
                Signin signin = new Signin();
                signin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          }

          private void btnFacial_Click(object sender, EventArgs e)
          {
               try
               {
                    this.Hide();
                    FacialRecognitionForm facialRecognitionForm = new FacialRecognitionForm();
                    facialRecognitionForm.Show();
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PwdFacialForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
