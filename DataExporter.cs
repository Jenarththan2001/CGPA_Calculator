using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CGPA_Calculator
{
    public class DataExporter
    {
        public static void GenerateExportData(List<Course> courses, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                // Overall Statistics
                document.Add(new Paragraph("Overall Statistics:"));
                document.Add(new Paragraph($"Courses Entered: {courses.Count}"));
                document.Add(new Paragraph($"Total Credits: {courses.Sum(c => c.CreditHours)}"));
                var semesters = courses.Select(c => c.Semester).Distinct().Count();
                document.Add(new Paragraph($"Semesters Entered: {semesters}"));
                double totalPoints = courses.Sum(c => c.CreditHours * GetGradePoint(c.Grade));
                double totalCredits = courses.Sum(c => c.CreditHours);
                double cgpa = totalCredits > 0 ? totalPoints / totalCredits : 0;
                document.Add(new Paragraph($"CGPA: {cgpa:0.00}"));
                document.Add(new Paragraph("\n"));

                // Detailed Course Information
                document.Add(new Paragraph("Course Details:"));
                document.Add(new Paragraph("\n"));
                var groupedCourses = courses.GroupBy(c => c.Semester);
                foreach (var group in groupedCourses)
                {
                    double semesterTotalPoints = group.Sum(c => c.CreditHours * GetGradePoint(c.Grade));
                    double semesterTotalCredits = group.Sum(c => c.CreditHours);
                    double semesterCGPA = semesterTotalCredits > 0 ? semesterTotalPoints / semesterTotalCredits : 0;

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 10f, 30f, 10f, 15f, 10f });

                    PdfPCell cell = new PdfPCell(new Phrase($"Semester {group.Key} - Semester CGPA: {semesterCGPA:0.00}"));
                    cell.Colspan = 5;
                    cell.HorizontalAlignment = 1;
                    table.AddCell(cell);

                    table.AddCell("Semester");
                    table.AddCell("Title");
                    table.AddCell("Code");
                    table.AddCell("Credit Hours");
                    table.AddCell("Grade Point");

                    foreach (var course in group)
                    {
                        table.AddCell(course.Semester.ToString());
                        table.AddCell(course.CourseTitle);
                        table.AddCell(course.CourseCode);
                        table.AddCell(course.CreditHours.ToString());
                        table.AddCell(GetGradePoint(course.Grade).ToString("0.00"));
                    }

                    document.Add(table);
                    document.Add(new Paragraph("\n"));
                }

                document.Close();
                writer.Close();
                fs.Close();
            }
        }

        // Helper method to convert grade to grade point
        private static double GetGradePoint(string grade)
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
    }
}
