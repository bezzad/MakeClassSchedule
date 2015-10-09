namespace MakeClassSchedule
{
    partial class PasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbtnExit = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblHint);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 127);
            this.panel1.TabIndex = 0;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(32, 99);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(81, 13);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Password Hint: ";
            this.toolTip1.SetToolTip(this.lblHint, "Password Hint for this UserName");
            this.lblHint.Visible = false;
            this.lblHint.TextChanged += new System.EventHandler(this.lblHint_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.Location = new System.Drawing.Point(35, 70);
            this.txtPassword.MaxLength = 40;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(191, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtPassword, "Please enter your Password");
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtUser.Location = new System.Drawing.Point(35, 30);
            this.txtUser.MaxLength = 40;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(191, 26);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "User Name";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtUser, "Please enter your UserName");
            this.txtUser.MouseLeave += new System.EventHandler(this.txtUser_MouseLeave);
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            this.txtUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyUp);
            this.txtUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUser_MouseDown);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            // 
            // btnMove
            // 
            this.btnMove.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.btnMove.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMove.Location = new System.Drawing.Point(27, 2);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(105, 34);
            this.btnMove.TabIndex = 0;
            this.btnMove.TabStop = false;
            this.btnMove.Text = "Login";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseMove);
            this.btnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseDown);
            this.btnMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMove_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(38, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(99, 31);
            this.panel2.TabIndex = 0;
            // 
            // pbtnExit
            // 
            this.pbtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbtnExit.Image = global::MakeClassSchedule.Properties.Resources.Normal;
            this.pbtnExit.Location = new System.Drawing.Point(256, 11);
            this.pbtnExit.Name = "pbtnExit";
            this.pbtnExit.Size = new System.Drawing.Size(27, 27);
            this.pbtnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbtnExit.TabIndex = 2;
            this.pbtnExit.TabStop = false;
            this.pbtnExit.MouseLeave += new System.EventHandler(this.pbtnExit_MouseLeave);
            this.pbtnExit.Click += new System.EventHandler(this.pbtnExit_Click);
            this.pbtnExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbtnExit_MouseDown);
            this.pbtnExit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbtnExit_MouseUp);
            this.pbtnExit.MouseEnter += new System.EventHandler(this.pbtnExit_MouseEnter);
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.ControlBox = false;
            this.Controls.Add(this.pbtnExit);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PasswordForm";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.PictureBox pbtnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblHint;

    }
}