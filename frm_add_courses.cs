using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CGPA_Calculator
{
    public partial class frm_add_courses : Telerik.WinControls.UI.RadForm
    {
        public Course NewCourse { get; private set; }
        private List<int> creditHoursList;
        private List<string> gradeList;
        private List<int> semesterList;

        public frm_add_courses()
        {
            InitializeComponent();
            InitializeDataSources();
            PopulateDropDownLists();
            btnAdd.Click += btnAdd_Click;
            btnCancel.Click += btnCancel_Click;
        }
        private void InitializeDataSources()
        {
            // Populate the credit hours list
            creditHoursList = new List<int> { 1, 2, 3, 4, 5 };

            // Populate the grade list
            gradeList = new List<string> { "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F" };

            // Populate the semester list
            semesterList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        private void PopulateDropDownLists()
        {
            // Set the data source and display member for credit hours dropdown
            radDropDownList_Credit_hours.DataSource = creditHoursList;
            radDropDownList_Credit_hours.DisplayMember = "ToString";

            // Set the data source and display member for grade dropdown
            radDropDownList_grade.DataSource = gradeList;
            radDropDownList_grade.DisplayMember = "ToString";

            // Set the data source and display member for semester dropdown
            radDropDownList_semester.DataSource = semesterList;
            radDropDownList_semester.DisplayMember = "ToString";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AreAllFieldsFilled())
            {
                string courseTitle = txt_course_title.Text;
                string courseCode = txt_course_code.Text;
                int creditHours = (int)radDropDownList_Credit_hours.SelectedValue;
                string grade = radDropDownList_grade.SelectedItem.Text;
                int semester = (int)radDropDownList_semester.SelectedValue;

                NewCourse = new Course
                {
                    CourseTitle = courseTitle,
                    CourseCode = courseCode,
                    CreditHours = creditHours,
                    Grade = grade,
                    Semester = semester
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrEmpty(txt_course_title.Text)
                && !string.IsNullOrEmpty(txt_course_code.Text)
                && radDropDownList_Credit_hours.SelectedItem != null
                && radDropDownList_grade.SelectedItem != null
                && radDropDownList_semester.SelectedItem != null;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
