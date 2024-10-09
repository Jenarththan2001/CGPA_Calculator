using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.IO;
using System.Diagnostics;
using Telerik.Charting;

namespace CGPA_Calculator
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        private List<Course> courses;
        private int selectedSemester = -1; // Initialize with an invalid value


        public MainForm()
        {
            InitializeComponent();
            InitializeCourseList();
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
            radDropDownList_select_semester.SelectedIndexChanged += radDropDownList_select_semester_SelectedIndexChanged;
            _ = new DayNight(this); // Initialize Day/Night mode
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to close the application? Your data will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // If the user clicks No, cancel the closing process
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        // Populate the bar chart with semester-wise GPA data
        // Populate the bar chart with semester-wise GPA data

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateGridView();
            PopulateBarChart();
            btnAddCourse.Click += btnAddCourse_Click;
            btn_delete.Click += btn_delete_Click;
            btn_edit.Click += btn_edit_Click;
            txt_search.TextChanged += txt_search_TextChanged;
            btn_export.Click += btn_export_Click;
            btn_set_target.Click += btn_set_target_Click;
            btn_show.Click += btn_show_Click; // Add this line
            btn_remove.Click += btn_remove_Click; // Add this line
            btn_edit_grade.Click += btn_edit_grade_Click;
            btn_linked_in.Click += btn_linked_in_Click;
            LoadSemesters(); // Load available semesters into the dropdown
        }
        private void InitializeCourseList()
        {
            courses = new List<Course>();
        }

        private void PopulateGridView()
        {
            List<Course> filteredCourses;
            if (selectedSemester == -1)
            {
                // Display all courses if "All Semesters" is selected
                filteredCourses = courses;
            }
            else
            {
                // Filter courses based on the selected semester
                filteredCourses = courses.Where(c => c.Semester == selectedSemester).ToList();
            }

            radGridView1.DataSource = filteredCourses;
            radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string searchText = txt_search.Text.Trim().ToLower();

            // Filter courses based on the search text
            List<Course> filteredCourses = courses.Where(c =>
                c.CourseCode.ToLower().Contains(searchText) ||
                c.CourseTitle.ToLower().Contains(searchText)
            ).ToList();

            // Update the GridView with the filtered courses
            radGridView1.DataSource = filteredCourses;
        }


        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            frm_add_courses addCourseForm = new frm_add_courses();
            if (addCourseForm.ShowDialog() == DialogResult.OK)
            {
                Course newCourse = addCourseForm.NewCourse;
                courses.Add(newCourse);
                radGridView1.DataSource = null;
                radGridView1.DataSource = courses;
                UpdateStatistics();
                UpdateGPAForSelectedSemester();
                PopulateBarChart();
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = radGridView1.SelectedRows[0].Index;
                    courses.RemoveAt(selectedIndex);
                    radGridView1.DataSource = null;
                    radGridView1.DataSource = courses;
                    UpdateStatistics();
                    UpdateGPAForSelectedSemester();
                    PopulateBarChart();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (radGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = radGridView1.SelectedRows[0].Index;
                Course selectedCourse = courses[selectedIndex];

                frm_edit_courses editCourseForm = new frm_edit_courses(selectedCourse);
                if (editCourseForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh the GridView after editing
                    radGridView1.DataSource = null;
                    radGridView1.DataSource = courses;
                    UpdateStatistics();
                    UpdateGPAForSelectedSemester();
                    PopulateBarChart();
                }
            }
            else
            {
                MessageBox.Show("Please select a course to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void radDropDownList_select_semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the selected semester and refresh the GridView
            if (radDropDownList_select_semester.SelectedIndex == 8)
            {
                selectedSemester = -1; // Set to -1 for "All Semesters"
            }
            else
            {
                selectedSemester = radDropDownList_select_semester.SelectedIndex + 1; // Add 1 because semesters are typically 1-based
            }
            PopulateGridView();
            UpdateStatistics();
            UpdateGPAForSelectedSemester();
            PopulateBarChart();
        }

        private void LoadSemesters()
        {
            // Populate the dropdown with semesters 1 to 8
            for (int i = 1; i <= 8; i++)
            {
                radDropDownList_select_semester.Items.Add("Semester " + i);
            }

            // Add the option for displaying all semesters at the end
            radDropDownList_select_semester.Items.Add("All Semesters");

            // Select the "All Semesters" option by default
            radDropDownList_select_semester.SelectedIndex = 8; // Index 8 corresponds to "All Semesters"
        }
        private void UpdateStatistics()
        {
            // Calculate total credits entered
            int totalCredits = courses.Sum(c => c.CreditHours);

            // Calculate total courses entered
            int totalCourses = courses.Count;

            // Calculate total semesters entered (assuming semesters are sequential)
            int totalSemesters = courses.Select(c => c.Semester).Distinct().Count();

            // Update the other statistics labels
            lblCGPA.Text = $"{GetCGPA():F2}";
            lbl_credits_entered.Text = $"{totalCredits}";
            lblCoursesEntered.Text = $"{totalCourses}";
            lblSemestersEntered.Text = $"{totalSemesters}";
        }
        private double GetCGPA()
        {
            if (courses.Count == 0)
                return 0;

            double totalGradePoints = 0;
            double totalCredits = 0;

            foreach (var course in courses)
            {
                totalGradePoints += GetGradePoint(course.Grade) * course.CreditHours;
                totalCredits += course.CreditHours;
            }

            return totalGradePoints / totalCredits;
        }
        private void UpdateGPA(IEnumerable<Course> filteredCourses)
        {
            double totalPoints = filteredCourses.Sum(c => c.CreditHours * GetGradePoint(c.Grade));
            double totalCredits = filteredCourses.Sum(c => c.CreditHours);
            double gpa = totalCredits > 0 ? totalPoints / totalCredits : 0;

            lbl_gpa.Text = $"CGPA: {gpa:0.00}";
        }
        private void UpdateGPAForSelectedSemester()
        {
            var filteredCourses = selectedSemester == -1 ? courses : courses.Where(c => c.Semester == selectedSemester);
            UpdateGPA(filteredCourses);
        }

        // Helper method to convert grade to grade point
        private double GetGradePoint(string grade)
        {
            switch (grade)
            {
                case "A+": return 4.0;
                case "A": return 4.0;
                case "A-": return 3.7;
                case "B+": return 3.3;
                case "B": return 3.0;
                case "B-": return 2.7;
                case "C+": return 2.3;
                case "C": return 2.0;
                case "C-": return 1.7;
                case "D+": return 1.3;
                case "D": return 1.0;
                default: return 0.0; // F or any other grade
            }
        }
        
        private void btn_export_Click(object sender, EventArgs e)
        {

            // Generate PDF file in the same folder as the application's executable
            string pdfFilePath = Path.Combine(Application.StartupPath, "CGPA.pdf");
             DataExporter.GenerateExportData(courses, pdfFilePath);
            // frm_preview previewForm = new frm_preview(pdfFilePath);
            //previewForm.ShowDialog();
            
            using (frm_preview previewForm = new frm_preview(pdfFilePath))
            {

                if (previewForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Data exported successfully.", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // User canceled the export, delete the PDF file
                    File.Delete(pdfFilePath);
                }
            }
            /*
            string pdfFilePath = Path.Combine(Application.StartupPath, "CGPA.pdf");
            DataExporter.GenerateExportData(courses, pdfFilePath);
            prw prw = new prw(pdfFilePath);
            prw.ShowDialog();
            */

        }
        private void btn_set_target_Click(object sender, EventArgs e)
        {
            // Get the values from the text boxes
            string targetCGPA = txt_set_CGPA.Text;
            string targetCredits = txt_set_tot_credits.Text;

            // Validate and set the values to the labels
            if (double.TryParse(targetCGPA, out double cgpa) && cgpa >= 0 && cgpa <= 4.0 &&
                int.TryParse(targetCredits, out int credits) && credits >= 100 && credits <= 200)
            {
                lbl_target_cgpa.Text = $"{cgpa:F2}";
                lbl_target_credit.Text = $"{credits}";
                MessageBox.Show("Target values set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid values for CGPA (0-4) and Credits (100-200).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            // Ask the user for confirmation before removing all courses
            DialogResult result = MessageBox.Show("Are you sure you want to remove all the data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear the course list
                courses.Clear();

                // Update the GridView and statistics
                radGridView1.DataSource = null;
                radGridView1.DataSource = courses;
                UpdateStatistics();
                UpdateGPAForSelectedSemester();
                PopulateBarChart();

                MessageBox.Show("All courses have been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            string gradingScale = @"Grading Scale:
A+ : 4.0
A  : 4.0
A- : 3.7
B+ : 3.3
B  : 3.0
B- : 2.7
C+ : 2.3
C  : 2.0
C- : 1.7
D+ : 1.3
D  : 1.0";

            MessageBox.Show(gradingScale, "Grading Scale", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_edit_grade_Click(object sender, EventArgs e)
        {

            MessageBox.Show("This Feature is under Construction", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_linked_in_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/jenarththan-akilan-65b912296";
            try
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open the link. Please check your internet connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
                private void PopulateBarChart()
                {
                    // Clear any existing series to avoid duplication
                    this.radChartView1.Series.Clear();

                    // Add some dummy data for testing
                    courses = new List<Course>
            {
                new Course { CourseCode = "CS101", CourseTitle = "Introduction to Computer Science", CreditHours = 3, Grade = "A", Semester = 1 },
                new Course { CourseCode = "MA101", CourseTitle = "Calculus I", CreditHours = 4, Grade = "B+", Semester = 1 },
                new Course { CourseCode = "PH101", CourseTitle = "Physics I", CreditHours = 3, Grade = "B", Semester = 1 },
                new Course { CourseCode = "CS102", CourseTitle = "Data Structures", CreditHours = 3, Grade = "A-", Semester = 2 },
                new Course { CourseCode = "MA102", CourseTitle = "Calculus II", CreditHours = 4, Grade = "B-", Semester = 2 },
                new Course { CourseCode = "PH102", CourseTitle = "Physics II", CreditHours = 3, Grade = "C+", Semester = 2 },
                new Course { CourseCode = "CS201", CourseTitle = "Algorithms", CreditHours = 3, Grade = "B+", Semester = 3 },
                new Course { CourseCode = "MA201", CourseTitle = "Linear Algebra", CreditHours = 4, Grade = "A", Semester = 3 },
                new Course { CourseCode = "PH201", CourseTitle = "Modern Physics", CreditHours = 3, Grade = "B-", Semester = 3 }
            };

                    // Dictionary to hold the total grade points and total credit hours for each semester
                    Dictionary<int, (double totalGradePoints, double totalCredits)> semesterData = new Dictionary<int, (double totalGradePoints, double totalCredits)>();

                    // Populate the dictionary with data from the courses list
                    foreach (var course in courses)
                    {
                        if (!semesterData.ContainsKey(course.Semester))
                        {
                            semesterData[course.Semester] = (0, 0);
                        }

                        semesterData[course.Semester] = (
                            semesterData[course.Semester].totalGradePoints + GetGradePoint(course.Grade) * course.CreditHours,
                            semesterData[course.Semester].totalCredits + course.CreditHours
                        );
                    }

                    // Create a bar series
                    BarSeries barSeries = new BarSeries("CGPA", "Semester");

                    // Calculate CGPA for each semester and add to the bar series
                    foreach (var semester in semesterData)
                    {
                        double cgpa = semester.Value.totalCredits > 0 ? semester.Value.totalGradePoints / semester.Value.totalCredits : 0;
                        barSeries.DataPoints.Add(new CategoricalDataPoint(cgpa, $"Semester {semester.Key}"));
                    }

                    // Add the bar series to the chart
                    this.radChartView1.Series.Add(barSeries);
                }
        */

        private void PopulateBarChart()
        {
            // Clear any existing series to avoid duplication
            this.radChartView1.Series.Clear();

            // Dictionary to hold the total grade points and total credit hours for each semester
            Dictionary<int, (double totalGradePoints, double totalCredits)> semesterData = new Dictionary<int, (double totalGradePoints, double totalCredits)>();

            // Populate the dictionary with data from the courses list
            foreach (var course in courses)
            {
                if (!semesterData.ContainsKey(course.Semester))
                {
                    semesterData[course.Semester] = (0, 0);
                }

                semesterData[course.Semester] = (
                    semesterData[course.Semester].totalGradePoints + GetGradePoint(course.Grade) * course.CreditHours,
                    semesterData[course.Semester].totalCredits + course.CreditHours
                );
            }

            // Create a bar series
            BarSeries barSeries = new BarSeries();

            // Calculate CGPA for each semester and add to the bar series
            foreach (var semester in semesterData)
            {
                double cgpa = semester.Value.totalCredits > 0 ? semester.Value.totalGradePoints / semester.Value.totalCredits : 0;
                barSeries.DataPoints.Add(new CategoricalDataPoint(cgpa, $"Semester {semester.Key}"));


            }

            // Add the bar series to the chart
            this.radChartView1.Series.Add(barSeries);
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_2(object sender, EventArgs e)
        {

        }

    }
    internal class DayNight
    {
        private bool themeDay;
        private RadImageButtonElement daynightButton;

        public DayNight(RadForm form)
        {
            new Telerik.WinControls.Themes.FluentTheme().DeserializeTheme();
            new Telerik.WinControls.Themes.FluentDarkTheme().DeserializeTheme();
            CreateDayNightButton(form);
            themeDay = Telerik.WinControls.WindowsSettings.AppsUseLightTheme;
            SetDayNight();
        }

        private void CreateDayNightButton(RadForm form)
        {
            daynightButton = new RadImageButtonElement
            {
                ThemeRole = "TitleBarMinimizeButton",
                Text = "☾",
                DisplayStyle = DisplayStyle.Text,
                ShowBorder = false,
                AutoSize = false,
                Size = form.FormElement.TitleBar.MinimizeButton.Size
            };
            daynightButton.Click += DayNight_Click;
            form.FormElement.TitleBar.SystemButtons.Children.Insert(0, daynightButton);
        }

        private void DayNight_Click(object sender, EventArgs e)
        {
            themeDay = !themeDay;
            SetDayNight();
        }

        private void SetDayNight()
        {
            if (themeDay)
            {
                ThemeResolutionService.ApplicationThemeName = "Fluent";
                daynightButton.Text = "☾";
            }
            else
            {
                ThemeResolutionService.ApplicationThemeName = "FluentDark";
                daynightButton.Text = "☼";
            }
        }
    }
}
