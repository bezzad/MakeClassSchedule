namespace DisconnectDB
{
    partial class DisconnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisconnectForm));
            this.picWait = new System.Windows.Forms.PictureBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.timerWait = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            this.SuspendLayout();
            // 
            // picWait
            // 
            this.picWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWait.Image = global::DisconnectDB.Properties.Resources.Wait_01;
            this.picWait.Location = new System.Drawing.Point(43, 3);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(67, 67);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWait.TabIndex = 0;
            this.picWait.TabStop = false;
            // 
            // lblWait
            // 
            this.lblWait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblWait.Location = new System.Drawing.Point(1, 73);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(151, 18);
            this.lblWait.TabIndex = 1;
            this.lblWait.Text = "Please Wait . . . . .";
            // 
            // timerWait
            // 
            this.timerWait.Enabled = true;
            this.timerWait.Tick += new System.EventHandler(this.timerWait_Tick);
            // 
            // DisconnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(152, 95);
            this.ControlBox = false;
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.picWait);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisconnectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.DisconnectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWait;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.Timer timerWait;
    }
}

