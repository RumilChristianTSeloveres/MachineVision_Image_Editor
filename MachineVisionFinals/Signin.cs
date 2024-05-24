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
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        //Close
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "System Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
                PwdFacialForm pwdFacialForm = new PwdFacialForm();
                pwdFacialForm.Show();
            }
        }

        //Log-in Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String username = txtUsername.Text;
                String password = txtPassword.Text;
                if (username.Equals("rumil.christian@gmail.com") && password.Equals("@Bobong1") || username.Equals("") && password.Equals(""))
                {
                    Dispose();
                    HomePageImageEditor hmp = new HomePageImageEditor();
                    hmp.Show();
                    MessageBox.Show("Welcome!", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else if (username.Equals("") && password.Equals(""))
                {
                    MessageBox.Show("Error! Please provide username or password...", "Message Info", MessageBoxButtons.OK, MessageBoxIcon.None);

                    txtUsername.ResetText();
                    txtPassword.ResetText();
                }
                else
                {
                    MessageBox.Show("Error! either username or password is incorrect...", "Caution!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtUsername.ResetText();
                    txtPassword.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Reset Button
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.ResetText();
            txtPassword.ResetText();
        }

        private void Signin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
