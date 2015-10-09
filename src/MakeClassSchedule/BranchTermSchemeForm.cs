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
    public partial class BranchTermSchemeForm : Form
    {
        public BranchTermSchemeForm(int branch_id)
        {
            InitializeComponent();
            Branch_ID_Index = branch_id;
        }

        private int Branch_ID_Index;
        //private Nullable<int> intNull = null;

        /// <summary>
        /// Compile string Course_ID and combine finded ID in list 
        /// and set that name.
        /// </summary>
        /// <param name="Course_ID">List of Course ID to be String file</param>
        /// <returns>Compiled name of course id</returns>
        private string find_CourseName(string Course_ID)
        {
            string strCourseID = "";
            string Course_Name = "";
            // compile string to some int ID to List<int> lstCourseID
            foreach (char cId in Course_ID.ToCharArray())
            {
                try
                {
                    if (char.IsDigit(cId))
                        strCourseID += cId.ToString();
                    else if (strCourseID != "")
                    {
                        Course_Name += (from CIN in new LINQDataContext().Courses
                                        where CIN.Course_ID == int.Parse(strCourseID)
                                        select CIN.Name_Course).ToArray()[0].ToString() + "  &  ";
                        strCourseID = "";
                    }
                }
                catch { }
            }
        
            Course_Name = (Course_Name.Length > 5) ? Course_Name.Substring(0, Course_Name.Length - 5) : Course_Name;
            return Course_Name;
        }

        private void BranchTermSchemeForm_Load(object sender, EventArgs e)
        {
            var TermSchemeTable = (from termScheme in new LINQDataContext().Courses
                                   where termScheme.Branch_ID == Branch_ID_Index
                                   orderby (termScheme.TermNo)
                                   select new
                                   {
                                       termScheme.TermNo,
                                       InRequisite = find_CourseName(termScheme.InRequisite_CourseID),
                                       PreRequisite = find_CourseName(termScheme.PreRequisite_CourseID),
                                       termScheme.Type_Course,
                                       termScheme.PracticalUnitNo,
                                       termScheme.TheoryUnitNo,
                                       termScheme.Name_Course
                                   }).ToArray();
            //
            // read any data in TermSchemeTable and show in Data Grid View
            int? bufferOldTermNo = 1;
            Color bufferOldTermBackColor = Color.White;
            for (int rowC = 0; rowC < TermSchemeTable.Length; rowC++)
            {
                dgvBranchTermScheme.Rows.Add();
                if (bufferOldTermNo == TermSchemeTable[rowC].TermNo.Value)
                {
                    dgvBranchTermScheme.Rows[rowC].DefaultCellStyle.BackColor = bufferOldTermBackColor;
                }
                else
                {
                    bufferOldTermNo = TermSchemeTable[rowC].TermNo.Value;
                    Random r = new Random();
                    System.Threading.Thread.Sleep(10); // for change R random number's
                    int R = r.Next(50, 255);
                    System.Threading.Thread.Sleep(10); // for change G random number's
                    int G = r.Next(50, 255);
                    System.Threading.Thread.Sleep(10); // for change B random number's
                    int B = r.Next(50, 255);
                    bufferOldTermBackColor = Color.FromArgb(R, G, B);
                    dgvBranchTermScheme.Rows[rowC].DefaultCellStyle.BackColor = bufferOldTermBackColor;
                }
                //
                // Whether or no below code is being run ... 
                dgvBranchTermScheme[0, rowC].Value = TermSchemeTable[rowC].TermNo.Value;
                dgvBranchTermScheme[1, rowC].Value = TermSchemeTable[rowC].InRequisite;
                dgvBranchTermScheme[2, rowC].Value = TermSchemeTable[rowC].PreRequisite;
                dgvBranchTermScheme[3, rowC].Value = TermSchemeTable[rowC].Type_Course;
                dgvBranchTermScheme[4, rowC].Value = TermSchemeTable[rowC].PracticalUnitNo.Value;
                dgvBranchTermScheme[5, rowC].Value = TermSchemeTable[rowC].TheoryUnitNo.Value;
                dgvBranchTermScheme[6, rowC].Value = TermSchemeTable[rowC].Name_Course;
            }
        }
    }
}
