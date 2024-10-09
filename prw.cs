using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using Telerik.WinControls.UI;

namespace CGPA_Calculator
{
    public partial class prw : Telerik.WinControls.UI.RadForm
    {
        private string pdfFilePath;
        public prw(string pdfFilePath)
        {
            InitializeComponent();
            this.pdfFilePath = pdfFilePath;
            LoadPdf();

            // Wire up event handlers
           // btn_Export_confirm.Click += btn_Export_confirm_Click;
           // btn_cancel.Click += btn_cancel_Click;
            this.FormClosing += frm_preview_FormClosing;
        }
        private void LoadPdf()
        {
            if (!string.IsNullOrEmpty(pdfFilePath) && File.Exists(pdfFilePath))
            {
                radPdfViewer1.LoadDocument(pdfFilePath);
                this.radPdfViewerNavigator1.AssociatedViewer = this.radPdfViewer1;

            }
            else
            {
                MessageBox.Show("PDF file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void frm_preview_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the PDF file is deleted if the form is closed without exporting
            if (this.DialogResult == DialogResult.Cancel && File.Exists(pdfFilePath))
            {
                File.Delete(pdfFilePath);
            }
        }
    }
}

