namespace CGPA_Calculator
{
    partial class prw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPdfViewerNavigator1 = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfViewer1 = new Telerik.WinControls.UI.RadPdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPdfViewerNavigator1
            // 
            this.radPdfViewerNavigator1.Location = new System.Drawing.Point(0, 0);
            this.radPdfViewerNavigator1.Name = "radPdfViewerNavigator1";
            this.radPdfViewerNavigator1.Size = new System.Drawing.Size(569, 40);
            this.radPdfViewerNavigator1.TabIndex = 0;
            this.radPdfViewerNavigator1.ThemeName = "Fluent";
            // 
            // radPdfViewer1
            // 
            this.radPdfViewer1.Location = new System.Drawing.Point(0, 46);
            this.radPdfViewer1.Name = "radPdfViewer1";
            this.radPdfViewer1.Size = new System.Drawing.Size(569, 424);
            this.radPdfViewer1.TabIndex = 1;
            this.radPdfViewer1.ThemeName = "Fluent";
            this.radPdfViewer1.ThumbnailsScaleFactor = 0.15F;
            // 
            // prw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 510);
            this.Controls.Add(this.radPdfViewer1);
            this.Controls.Add(this.radPdfViewerNavigator1);
            this.Name = "prw";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "PDF Preview";
            this.ThemeName = "Fluent";
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator1;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer1;
    }
}
