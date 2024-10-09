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
    public partial class frm_edit_courses : Telerik.WinControls.UI.RadForm
    {
        private Course courseToEdit;
        private List<int> creditHoursList;
        private List<string> gradeList;
        private List<int> semesterList;
        public frm_edit_courses(Course course)
        {
            InitializeComponent();
            courseToEdit = course;
            InitializeDataSources();
            PopulateFormData();
            btnCancel_edit.Click += btnCancel_edit_Click;
            btnSave.Click += btnSave_Click;
        }
        private void InitializeDataSources()
        {
            // Populate the credit hours list
            creditHoursList = new List<int> { 1, 2, 3, 4, 5 };

            // Populate the grade list
            gradeList = new List<string> { "A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "F" };

            // Populate the semester list
            semesterList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            // Set the data source for credit hours dropdown
            radDropDownList_Credit_hours_edit.DataSource = creditHoursList;

            // Set the data source for grade dropdown
            radDropDownList_grade_edit.DataSource = gradeList;

            // Set the data source for semester dropdown
            radDropDownList_semester.DataSource = semesterList;
        }
        private void PopulateFormData()
        {
            txt_course_title_edit.Text = courseToEdit.CourseTitle;
            txt_course_code.Text = courseToEdit.CourseCode;
            radDropDownList_Credit_hours_edit.SelectedValue = courseToEdit.CreditHours;
            radDropDownList_grade_edit.SelectedValue = courseToEdit.Grade;
            radDropDownList_semester.SelectedValue = courseToEdit.Semester;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Update the course details with the edited values
                courseToEdit.CourseTitle = txt_course_title_edit.Text;
                courseToEdit.CourseCode = txt_course_code.Text;
                courseToEdit.CreditHours = (int)radDropDownList_Credit_hours_edit.SelectedValue;
                courseToEdit.Grade = radDropDownList_grade_edit.SelectedValue.ToString();
                courseToEdit.Semester = (int)radDropDownList_semester.SelectedValue;

                // Close the form with DialogResult.OK to indicate successful edit
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void btnCancel_edit_Click(object sender, EventArgs e)
        {
            // Close the form with DialogResult.Cancel to indicate cancellation
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
