using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MakeClassSchedule
{
    public partial class TermSchemeForm : Form
    {
        public TermSchemeForm()
        {
            InitializeComponent();
        }

        private void TermSchemeForm_Load(object sender, EventArgs e)
        {
            var db = new LINQDataContext();
            dgvTermScheme.DataSource = db.Branches;


            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            // 
            // colBtnTermScheme
            // 
            this.colBtnTermScheme = new System.Windows.Forms.DataGridViewButtonColumn();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Term Scheme";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            this.colBtnTermScheme.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBtnTermScheme.Frozen = false;
            this.colBtnTermScheme.HeaderText = "Term Scheme";
            this.colBtnTermScheme.Name = "colBtnTermScheme";
            this.colBtnTermScheme.Text = "Term Scheme";
            this.dgvTermScheme.Columns.Add(this.colBtnTermScheme);
            //
            // other col setup
            //
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            dgvTermScheme.Columns[0].DefaultCellStyle = dataGridViewCellStyle4;
            dgvTermScheme.Columns[0].Width = 50;
            dgvTermScheme.Columns[0].HeaderText = "ID";
            dgvTermScheme.Columns[0].ReadOnly = true;
            dgvTermScheme.Columns[0].Frozen = true;

            dgvTermScheme.Columns[1].DefaultCellStyle = dataGridViewCellStyle4;
            dgvTermScheme.Columns[1].Width = 150;
            dgvTermScheme.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTermScheme.Columns[1].ReadOnly = true;
            dgvTermScheme.Columns[1].HeaderText = "Education Course Name";

            dgvTermScheme.Columns[2].DefaultCellStyle = dataGridViewCellStyle4;
            dgvTermScheme.Columns[2].Width = 200;
            dgvTermScheme.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTermScheme.Columns[2].ReadOnly = true;
            dgvTermScheme.Columns[2].HeaderText = "Education Degree";
        }

        private void dgvTermScheme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                BranchTermSchemeForm btsForm = new BranchTermSchemeForm(int.Parse(dgvTermScheme[0, e.RowIndex].Value.ToString()));
                btsForm.Text = dgvTermScheme[1, e.RowIndex].Value.ToString() + "  -  " + dgvTermScheme[2, e.RowIndex].Value.ToString() + "   Term Scheme's";
                this.Hide();
                btsForm.ShowDialog();
                this.Show();
            }
        }
    }
}
