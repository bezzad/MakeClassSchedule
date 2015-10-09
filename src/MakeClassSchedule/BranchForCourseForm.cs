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
    public partial class BranchForCourseForm : Form
    {
        public BranchForCourseForm()
        {
            InitializeComponent();
        }

        private void BranchForCourseForm_Load(object sender, EventArgs e)
        {
            dgvBranch.DataSource = new LINQDataContext().Branches.ToList();
            dgvBranch.Columns[0].HeaderText = "ID";
            dgvBranch.Columns[0].Width = 60;
            dgvBranch.Columns[0].Frozen = true;
            dgvBranch.Columns[1].HeaderText = "Education Course Name";
            dgvBranch.Columns[1].Width = 200;
            dgvBranch.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBranch.Columns[2].HeaderText = "Education Degree";
            dgvBranch.Columns[2].Width = 200;
            dgvBranch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            DataGridViewColumn colAddCourse = new DataGridViewButtonColumn();
            colAddCourse.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAddCourse.HeaderText = "Add Course";
            colAddCourse.Width = 100;
            colAddCourse.DefaultCellStyle.NullValue = "Courses";
            colAddCourse.DefaultCellStyle.Padding = new Padding(3);
            dgvBranch.Columns.Add(colAddCourse);
        }

        private void dgvBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && e.RowIndex < dgvBranch.RowCount)
            {
                CourseForm cForm = new CourseForm(
                    int.Parse(dgvBranch[0, e.RowIndex].Value.ToString()),
                    dgvBranch[1, e.RowIndex].Value.ToString(),
                    dgvBranch[2, e.RowIndex].Value.ToString());

                this.Hide();
                cForm.ShowDialog();
                this.Show();
            }
        }
    }
}
