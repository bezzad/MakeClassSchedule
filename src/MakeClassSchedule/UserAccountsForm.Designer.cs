namespace MakeClassSchedule
{
    partial class UserAccountsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelChangePass = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtHint = new System.Windows.Forms.TextBox();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.panelChangeAccounts = new System.Windows.Forms.Panel();
            this.picLocker = new System.Windows.Forms.PictureBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtModifiers = new System.Windows.Forms.TextBox();
            this.txtRePass = new System.Windows.Forms.TextBox();
            this.txtPassHint = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnChangeAccounts = new System.Windows.Forms.Button();
            this.timerOpenPanel_ChangePass = new System.Windows.Forms.Timer(this.components);
            this.timerOpenPanel_ChangeAccounts = new System.Windows.Forms.Timer(this.components);
            this.timerClosePanel_ChangePass = new System.Windows.Forms.Timer(this.components);
            this.timerClosePanel_ChangeAccounts = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvUserPass = new System.Windows.Forms.DataGridView();
            this.txtHashPass = new System.Windows.Forms.TextBox();
            this.txtOriginalPass = new System.Windows.Forms.TextBox();
            this.btnConvertPass = new System.Windows.Forms.Button();
            this.panelChangePass.SuspendLayout();
            this.panelChangeAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLocker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserPass)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChangePass
            // 
            this.panelChangePass.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelChangePass.Controls.Add(this.btnChangePassword);
            this.panelChangePass.Controls.Add(this.txtHint);
            this.panelChangePass.Controls.Add(this.txtConfirmNewPassword);
            this.panelChangePass.Controls.Add(this.txtNewPassword);
            this.panelChangePass.Controls.Add(this.txtCurrentPassword);
            this.panelChangePass.Controls.Add(this.lblUserName);
            this.panelChangePass.Controls.Add(this.label9);
            this.panelChangePass.Controls.Add(this.label8);
            this.panelChangePass.Controls.Add(this.label7);
            this.panelChangePass.Controls.Add(this.label6);
            this.panelChangePass.Controls.Add(this.btnChangePass);
            this.panelChangePass.Location = new System.Drawing.Point(12, 12);
            this.panelChangePass.Name = "panelChangePass";
            this.panelChangePass.Size = new System.Drawing.Size(270, 22);
            this.panelChangePass.TabIndex = 0;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.Location = new System.Drawing.Point(70, 171);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(130, 26);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "&Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtHint
            // 
            this.txtHint.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtHint.ForeColor = System.Drawing.Color.DimGray;
            this.txtHint.Location = new System.Drawing.Point(36, 127);
            this.txtHint.MaxLength = 40;
            this.txtHint.Name = "txtHint";
            this.txtHint.Size = new System.Drawing.Size(199, 20);
            this.txtHint.TabIndex = 4;
            this.txtHint.Text = "Password Hint";
            this.txtHint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtHint, "When you create a password to log on to Make Class Schedule, \r\nyou can create a h" +
                    "int to help you remember it.");
            this.txtHint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHint_KeyDown);
            this.txtHint.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHint_KeyUp);
            this.txtHint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtHint_MouseDown);
            this.txtHint.MouseLeave += new System.EventHandler(this.txtHint_MouseLeave);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(128, 101);
            this.txtConfirmNewPassword.MaxLength = 40;
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(139, 20);
            this.txtConfirmNewPassword.TabIndex = 3;
            this.txtConfirmNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNewPassword.Location = new System.Drawing.Point(127, 75);
            this.txtNewPassword.MaxLength = 40;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(139, 20);
            this.txtNewPassword.TabIndex = 2;
            this.txtNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCurrentPassword.Location = new System.Drawing.Point(98, 49);
            this.txtCurrentPassword.MaxLength = 40;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(169, 20);
            this.txtCurrentPassword.TabIndex = 1;
            this.txtCurrentPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUserName.ForeColor = System.Drawing.Color.Red;
            this.lblUserName.Location = new System.Drawing.Point(67, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(60, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "#Admin#";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Confirm New Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "New Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Current Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "User Name: ";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePass.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePass.Image")));
            this.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePass.Location = new System.Drawing.Point(0, 0);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(270, 22);
            this.btnChangePass.TabIndex = 0;
            this.btnChangePass.Text = "Change your password";
            this.btnChangePass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // panelChangeAccounts
            // 
            this.panelChangeAccounts.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelChangeAccounts.Controls.Add(this.picLocker);
            this.panelChangeAccounts.Controls.Add(this.btnRemove);
            this.panelChangeAccounts.Controls.Add(this.btnAdd);
            this.panelChangeAccounts.Controls.Add(this.label4);
            this.panelChangeAccounts.Controls.Add(this.label3);
            this.panelChangeAccounts.Controls.Add(this.label5);
            this.panelChangeAccounts.Controls.Add(this.label2);
            this.panelChangeAccounts.Controls.Add(this.label1);
            this.panelChangeAccounts.Controls.Add(this.txtUser);
            this.panelChangeAccounts.Controls.Add(this.txtModifiers);
            this.panelChangeAccounts.Controls.Add(this.txtRePass);
            this.panelChangeAccounts.Controls.Add(this.txtPassHint);
            this.panelChangeAccounts.Controls.Add(this.txtPass);
            this.panelChangeAccounts.Controls.Add(this.btnChangeAccounts);
            this.panelChangeAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelChangeAccounts.Location = new System.Drawing.Point(12, 40);
            this.panelChangeAccounts.Name = "panelChangeAccounts";
            this.panelChangeAccounts.Size = new System.Drawing.Size(270, 22);
            this.panelChangeAccounts.TabIndex = 1;
            // 
            // picLocker
            // 
            this.picLocker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLocker.Image = global::MakeClassSchedule.Properties.Resources._lock;
            this.picLocker.Location = new System.Drawing.Point(231, 181);
            this.picLocker.Name = "picLocker";
            this.picLocker.Size = new System.Drawing.Size(36, 36);
            this.picLocker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLocker.TabIndex = 8;
            this.picLocker.TabStop = false;
            this.toolTip1.SetToolTip(this.picLocker, "Manage user password database by Administrator (Lock)");
            this.picLocker.Click += new System.EventHandler(this.picLocker_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRemove.Location = new System.Drawing.Point(141, 166);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 45);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Location = new System.Drawing.Point(55, 166);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 45);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(3, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Modifiers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password Hint:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(3, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Confirm Password: *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Password: *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name: *";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUser.Location = new System.Drawing.Point(90, 28);
            this.txtUser.MaxLength = 40;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(177, 21);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtModifiers
            // 
            this.txtModifiers.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtModifiers.Location = new System.Drawing.Point(70, 136);
            this.txtModifiers.MaxLength = 40;
            this.txtModifiers.Name = "txtModifiers";
            this.txtModifiers.Size = new System.Drawing.Size(197, 21);
            this.txtModifiers.TabIndex = 5;
            this.txtModifiers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRePass
            // 
            this.txtRePass.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRePass.Location = new System.Drawing.Point(127, 82);
            this.txtRePass.MaxLength = 40;
            this.txtRePass.Name = "txtRePass";
            this.txtRePass.Size = new System.Drawing.Size(140, 21);
            this.txtRePass.TabIndex = 3;
            this.txtRePass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRePass.UseSystemPasswordChar = true;
            // 
            // txtPassHint
            // 
            this.txtPassHint.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassHint.Location = new System.Drawing.Point(98, 109);
            this.txtPassHint.MaxLength = 40;
            this.txtPassHint.Name = "txtPassHint";
            this.txtPassHint.Size = new System.Drawing.Size(169, 21);
            this.txtPassHint.TabIndex = 4;
            this.txtPassHint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtPassHint, "When you create a password to log on to Make Class Schedule, \r\nyou can create a h" +
                    "int to help you remember it.");
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPass.Location = new System.Drawing.Point(127, 55);
            this.txtPass.MaxLength = 40;
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(140, 21);
            this.txtPass.TabIndex = 2;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnChangeAccounts
            // 
            this.btnChangeAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnChangeAccounts.Image = global::MakeClassSchedule.Properties.Resources.Downer;
            this.btnChangeAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeAccounts.Location = new System.Drawing.Point(0, 0);
            this.btnChangeAccounts.Name = "btnChangeAccounts";
            this.btnChangeAccounts.Size = new System.Drawing.Size(270, 22);
            this.btnChangeAccounts.TabIndex = 0;
            this.btnChangeAccounts.Text = "Make changes to user accounts";
            this.btnChangeAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeAccounts.UseVisualStyleBackColor = true;
            this.btnChangeAccounts.Click += new System.EventHandler(this.btnChangeAccounts_Click);
            // 
            // timerOpenPanel_ChangePass
            // 
            this.timerOpenPanel_ChangePass.Interval = 1;
            this.timerOpenPanel_ChangePass.Tick += new System.EventHandler(this.timerOpenPanel_ChangePass_Tick);
            // 
            // timerOpenPanel_ChangeAccounts
            // 
            this.timerOpenPanel_ChangeAccounts.Interval = 1;
            this.timerOpenPanel_ChangeAccounts.Tick += new System.EventHandler(this.timerOpenPanel_ChangeAccounts_Tick);
            // 
            // timerClosePanel_ChangePass
            // 
            this.timerClosePanel_ChangePass.Interval = 1;
            this.timerClosePanel_ChangePass.Tick += new System.EventHandler(this.timerClosePanel_ChangePass_Tick);
            // 
            // timerClosePanel_ChangeAccounts
            // 
            this.timerClosePanel_ChangeAccounts.Interval = 1;
            this.timerClosePanel_ChangeAccounts.Tick += new System.EventHandler(this.timerClosePanel_ChangeAccounts_Tick);
            // 
            // dgvUserPass
            // 
            this.dgvUserPass.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dgvUserPass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserPass.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvUserPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUserPass.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvUserPass.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvUserPass.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserPass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserPass.ColumnHeadersHeight = 40;
            this.dgvUserPass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserPass.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserPass.Location = new System.Drawing.Point(301, 37);
            this.dgvUserPass.Name = "dgvUserPass";
            this.dgvUserPass.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvUserPass.RowHeadersWidth = 25;
            this.dgvUserPass.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUserPass.RowTemplate.Height = 35;
            this.dgvUserPass.Size = new System.Drawing.Size(481, 223);
            this.dgvUserPass.TabIndex = 2;
            this.dgvUserPass.TabStop = false;
            this.toolTip1.SetToolTip(this.dgvUserPass, "User Password Database");
            this.dgvUserPass.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserPass_CellEndEdit);
            this.dgvUserPass.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvUserPass_UserDeletingRow);
            // 
            // txtHashPass
            // 
            this.txtHashPass.BackColor = System.Drawing.SystemColors.Window;
            this.txtHashPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtHashPass.Location = new System.Drawing.Point(478, 8);
            this.txtHashPass.Name = "txtHashPass";
            this.txtHashPass.ReadOnly = true;
            this.txtHashPass.Size = new System.Drawing.Size(304, 20);
            this.txtHashPass.TabIndex = 3;
            this.txtHashPass.Text = "HashCode Password";
            this.txtHashPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtHashPass, "Hashing Password");
            // 
            // txtOriginalPass
            // 
            this.txtOriginalPass.ForeColor = System.Drawing.Color.DimGray;
            this.txtOriginalPass.Location = new System.Drawing.Point(301, 8);
            this.txtOriginalPass.Name = "txtOriginalPass";
            this.txtOriginalPass.Size = new System.Drawing.Size(127, 20);
            this.txtOriginalPass.TabIndex = 3;
            this.txtOriginalPass.Text = "Original Password";
            this.txtOriginalPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtOriginalPass, "Original Password");
            this.txtOriginalPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOriginalPass_KeyDown);
            this.txtOriginalPass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOriginalPass_KeyUp);
            this.txtOriginalPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtOriginalPass_MouseDown);
            this.txtOriginalPass.MouseLeave += new System.EventHandler(this.txtOriginalPass_MouseLeave);
            // 
            // btnConvertPass
            // 
            this.btnConvertPass.BackgroundImage = global::MakeClassSchedule.Properties.Resources.Convert;
            this.btnConvertPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConvertPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConvertPass.Location = new System.Drawing.Point(434, 0);
            this.btnConvertPass.Name = "btnConvertPass";
            this.btnConvertPass.Size = new System.Drawing.Size(38, 35);
            this.btnConvertPass.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnConvertPass, "Convert Original Password to MD5 Hashing Password");
            this.btnConvertPass.UseVisualStyleBackColor = true;
            this.btnConvertPass.Click += new System.EventHandler(this.btnConvertPass_Click);
            // 
            // UserAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 272);
            this.Controls.Add(this.btnConvertPass);
            this.Controls.Add(this.txtOriginalPass);
            this.Controls.Add(this.txtHashPass);
            this.Controls.Add(this.dgvUserPass);
            this.Controls.Add(this.panelChangeAccounts);
            this.Controls.Add(this.panelChangePass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAccountsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Accounts";
            this.panelChangePass.ResumeLayout(false);
            this.panelChangePass.PerformLayout();
            this.panelChangeAccounts.ResumeLayout(false);
            this.panelChangeAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLocker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelChangePass;
        private System.Windows.Forms.Panel panelChangeAccounts;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnChangeAccounts;
        private System.Windows.Forms.Timer timerOpenPanel_ChangePass;
        private System.Windows.Forms.Timer timerOpenPanel_ChangeAccounts;
        private System.Windows.Forms.Timer timerClosePanel_ChangePass;
        private System.Windows.Forms.Timer timerClosePanel_ChangeAccounts;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtModifiers;
        private System.Windows.Forms.TextBox txtPassHint;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRePass;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHint;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.PictureBox picLocker;
        private System.Windows.Forms.DataGridView dgvUserPass;
        private System.Windows.Forms.TextBox txtHashPass;
        private System.Windows.Forms.TextBox txtOriginalPass;
        private System.Windows.Forms.Button btnConvertPass;
    }
}