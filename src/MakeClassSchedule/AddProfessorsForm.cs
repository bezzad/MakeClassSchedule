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
    public partial class AddProfessorsForm : Form
    {
        DataGridViewTextBoxCell interface_TextBox;
        public DataGridViewTextBoxCell Interface_TextBox
        {
            get { return interface_TextBox; }
            set { interface_TextBox = value; }
        }

        Timer startOpacity = new Timer();
        Timer stopOpacity = new Timer();

        int Class_ID = 0;
        public AddProfessorsForm(int class_id)
        {
            InitializeComponent();
            Class_ID = class_id;
            startOpacity.Stop();
            stopOpacity.Stop();
            startOpacity.Interval = 10;
            stopOpacity.Interval = 10;
            startOpacity.Tick += new EventHandler(starterOpacity_Tick);
            stopOpacity.Tick += new EventHandler(stopOpacity_Tick);
        }

        void stopOpacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
                this.Opacity -= 0.05;
            else
            {
                this.Opacity = 0.0;
                stopOpacity.Stop();
                this.Close();
            }
        }

        void starterOpacity_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
                this.Opacity += 0.05;
            else
            {
                this.Opacity = 1.0;
                startOpacity.Stop();
            }
        }

        private string find_Priority(ref Dictionary<int, int> PP, int key)
        {
            return ((PP.ContainsKey(key)) ? PP[key].ToString() : "1");
        }
        private void AddProfessorsForm_Load(object sender, EventArgs e)
        {
            startOpacity.Start();
            //
            // Compile the priority 
            //
            Dictionary<int, int> ProfessorKey_PriorityValue = new Dictionary<int, int>();
            if(Interface_TextBox.Value != null)
            {
                string keyBuffer = "";
                string valueBuffer = "";
                bool showParantes = false;

                foreach (char ch in Interface_TextBox.Value.ToString().ToCharArray())
                {
                    if (char.IsDigit(ch) && !showParantes) // a Key Number char
                    {
                        keyBuffer += ch.ToString();
                    }
                    else if (ch == '(') // a '(' before Value Number char
                    {
                        showParantes = true;
                    }
                    else if (char.IsDigit(ch) && showParantes) // a Value Number char
                    {
                        valueBuffer += ch.ToString();
                    }
                    else if (ch == ')')
                    {
                        showParantes = false;
                        ProfessorKey_PriorityValue.Add(int.Parse(keyBuffer), int.Parse(valueBuffer));
                        keyBuffer = string.Empty;
                        valueBuffer = string.Empty;
                    }
                    else
                        continue;
                }
            }
            //
            // set dgvProfessors data as Class_ID
            // 
            var prof = from db in new LINQDataContext().Professors
                       select new
                       {
                           db.ID,
                           db.Name_Professor,
                           Priority = find_Priority(ref ProfessorKey_PriorityValue, db.ID),
                           Selected = (ProfessorKey_PriorityValue.ContainsKey(db.ID))
                       };

            foreach (var anyProf in prof.ToArray())
                dgvProfessors.Rows.Add(new object[] {
                                                     anyProf.ID,
                                                     anyProf.Name_Professor,
                                                     anyProf.Priority,
                                                     anyProf.Selected
                                                    });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProfessors[0, 0].Selected = true;
                //
                // Save Selected Profssor data
                //
                Interface_TextBox.Value = string.Empty;
                foreach (DataGridViewRow row in dgvProfessors.Rows)
                {
                    try
                    {
                        if (bool.Parse(row.Cells[3].Value.ToString()))
                        {
                            Interface_TextBox.Value = Interface_TextBox.Value.ToString() +
                                row.Cells[0].Value.ToString() + "(" + row.Cells[2].Value.ToString() + ")  ";
                        }
                    }
                    catch { }
                }
            }
            catch { }
            //
            // Close Form
            //
            stopOpacity.Start();
        }

        bool keyDown = false;
        private void AddProfessorsForm_MouseDown(object sender, MouseEventArgs e)
        {
            locBuffer = e.Location;
            keyDown = true;
        }

        private void AddProfessorsForm_MouseUp(object sender, MouseEventArgs e)
        {
            keyDown = false;
        }

        Point locBuffer;
        private void AddProfessorsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (keyDown)
            {
                this.Location = new Point(this.Location.X + (e.X - locBuffer.X),
                                          this.Location.Y + (e.Y - locBuffer.Y));
            }
        }

    }
}
