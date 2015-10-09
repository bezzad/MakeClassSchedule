using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MakeClassSchedule
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            #region Define Admin
            new LINQ_UserPassDataContext().SaveUserPass(@"#admin#",
                "6E68BCEE1160C9CE79643F96EE24AD95",
                "Administrator", "A13");
            #endregion
        }

        protected bool MouseDown_TF = false;
        Point oldMouseLoc;
        private void btnMove_MouseDown(object sender, MouseEventArgs e)
        {
            oldMouseLoc = e.Location;
            MouseDown_TF = true;
        }

        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown_TF = false;
            txtUser.Focus();
        }

        private void btnMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown_TF)
            {
                this.Location = new Point(this.Location.X + (e.X - oldMouseLoc.X), this.Location.Y + (e.Y - oldMouseLoc.Y));
            }
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            //
            // Password TextBox
            //
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            txtPassword.ForeColor = Color.DimGray;
            txtPassword.Text = "Password";
            txtPassword.UseSystemPasswordChar = false;
            //
            // User Name TextBox
            //
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            txtUser.ForeColor = Color.DimGray;
            txtUser.Text = "User Name";
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.ForeColor = Color.DimGray;
                txtUser.Text = "User Name";
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUser.ForeColor == Color.DimGray)
            {
                txtUser.Text = string.Empty;
                txtUser.ForeColor = Color.Black;
            }
            if (e.KeyData == Keys.Enter)
            {
                if (txtUser.Text == string.Empty || txtUser.ForeColor == Color.DimGray)
                {
                    MessageBox.Show("Please Enter Your UserName", "Empty TextBox Error");
                    return;
                }
                else if (txtPassword.Text == string.Empty)
                {
                    txtPassword.Focus();
                }
                else
                {
                    CheckUserPass(txtUser.Text, txtPassword.Text);
                }
            }
        }

        private void txtUser_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtUser.ForeColor == Color.DimGray)
            {
                txtUser.Text = string.Empty;
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_MouseLeave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.ForeColor = Color.DimGray;
                txtUser.Text = "User Name";
            }
        }

        private void pbtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void pbtnExit_MouseEnter(object sender, EventArgs e)
        {
            this.pbtnExit.Image = global::MakeClassSchedule.Properties.Resources.Mouse_Over;
        }

        private void pbtnExit_MouseLeave(object sender, EventArgs e)
        {
            this.pbtnExit.Image = global::MakeClassSchedule.Properties.Resources.Normal;
        }

        private void pbtnExit_MouseDown(object sender, MouseEventArgs e)
        {
            this.pbtnExit.Image = global::MakeClassSchedule.Properties.Resources.Mouse_Down;
        }

        private void pbtnExit_MouseUp(object sender, MouseEventArgs e)
        {
            this.pbtnExit.Image = global::MakeClassSchedule.Properties.Resources.Mouse_Over;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Your Password", "Empty TextBox Error");
                    return;
                }
                else if (txtUser.Text == string.Empty || txtUser.ForeColor == Color.DimGray)
                {
                    txtUser.Focus();
                }
                else
                {
                    CheckUserPass(txtUser.Text, txtPassword.Text);
                }
            }
        }

        bool CloseOK = false;
        private void CheckUserPass(string user, string pass)
        {
            var dbUser = (from qUP in new LINQ_UserPassDataContext().User_Passwords
                          where qUP.UserName == user
                          select new { qUP.UserName, qUP.Password, qUP.PasswordHint }).SingleOrDefault();
            if (dbUser == null)
            {
                lblHint.ForeColor = Color.Red;
                lblHint.Text = "User or Pass is incorrect";

                txtPassword.Text = string.Empty;

                txtUser.ForeColor = Color.DimGray;
                txtUser.Text = "User Name";
                txtUser.Focus();
            }
            else
            {
                string PassCode = CreateMD5Hash(pass);
      
                if (dbUser.Password != PassCode)
                {
                    MessageBox.Show("Your Password is incorrect", "Password Error");
                    if (dbUser.PasswordHint != null)
                    {
                        lblHint.ForeColor = Color.Black;
                        lblHint.Text = "Password Hint:   " + dbUser.PasswordHint;
                    }
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    CloseOK = true;
                    UserAccountsForm.Entry_UserName = dbUser.UserName;
                    this.Close();
                }
            }

        }

        private void PasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseOK) this.DialogResult = DialogResult.Cancel;
        }

        private void lblHint_TextChanged(object sender, EventArgs e)
        {
            lblHint.Visible = true;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.DimGray)
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.Text = "Password";
                txtUser.Focus();
                txtUser.DeselectAll();
            }
        }

        public string CreateMD5Hash(string input)
        {
            //Create a byte array from source data
            byte[] inputBytes = ASCIIEncoding.ASCII.GetBytes(input);
            //
            //Compute hash based on source data
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes);
            //
            // Convert the byte array to hexadecimal string
            //
            StringBuilder sOutput = new StringBuilder(hashBytes.Length);
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sOutput.Append(hashBytes[i].ToString("X2"));
                // To force the hex string to lower-case letters instead of
                // upper-case, use he following line instead:
                // sOutput.Append(hashBytes[i].ToString("x2")); 
            }
            return sOutput.ToString();
        }
    }
}
