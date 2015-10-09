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
    public partial class SelectCourseForm : Form
    {
        private int BranchID = 0;
        public SelectCourseForm(int Branch_ID)
        {
            InitializeComponent();
            BranchID = Branch_ID;
        }

        DataGridViewTextBoxCell lstSelectedCourse;
        public DataGridViewTextBoxCell LstSelectedCourse
        {
            get { return lstSelectedCourse; }
            set { lstSelectedCourse = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var db = from course in new LINQDataContext().Courses
                     where course.Branch_ID == BranchID
                     select course;
            //
            // save list data
            //
            LstSelectedCourse.Value = "";
            for (int c = 0; c < chblstSelectCourse.Items.Count; c++) 
            {
                if (chblstSelectCourse.GetItemChecked(c))
                {
                    LstSelectedCourse.Value += (from name in db
                                                where name.Name_Course == chblstSelectCourse.Items[c].ToString()
                                                select name.Course_ID.ToString()).SingleOrDefault() + " ";
                }
            }
            //
            // close form
            //
            this.Close();
        }

        private void SelectCourseForm_Load(object sender, EventArgs e)
        {
            if (chblstSelectCourse.Items.Count > 0)
                chblstSelectCourse.SelectedIndex = 0;
        }

    }
}
