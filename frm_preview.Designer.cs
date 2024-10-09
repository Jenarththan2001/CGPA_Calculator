namespace CGPA_Calculator
{
    partial class frm_preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_preview));
            this.btn_Export_confirm = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.radPdfViewerNavigator1 = new Telerik.WinControls.UI.RadPdfViewerNavigator();
            this.radPdfViewer1 = new Telerik.WinControls.UI.RadPdfViewer();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.fluentTheme2 = new Telerik.WinControls.Themes.FluentTheme();
            this.fluentDarkTheme1 = new Telerik.WinControls.Themes.FluentDarkTheme();
            this.fluentTheme3 = new Telerik.WinControls.Themes.FluentTheme();
            this.fluentTheme4 = new Telerik.WinControls.Themes.FluentTheme();
            this.fluentDarkTheme2 = new Telerik.WinControls.Themes.FluentDarkTheme();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Export_confirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Export_confirm
            // 
            this.btn_Export_confirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export_confirm.Location = new System.Drawing.Point(631, 599);
            this.btn_Export_confirm.Name = "btn_Export_confirm";
            this.btn_Export_confirm.Size = new System.Drawing.Size(137, 30);
            this.btn_Export_confirm.TabIndex = 4;
            this.btn_Export_confirm.Text = "Export";
            this.btn_Export_confirm.ThemeName = "Windows8";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(477, 599);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(137, 30);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.ThemeName = "Windows8";
            // 
            // radPdfViewerNavigator1
            // 
            this.radPdfViewerNavigator1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPdfViewerNavigator1.Location = new System.Drawing.Point(12, 12);
            this.radPdfViewerNavigator1.Name = "radPdfViewerNavigator1";
            this.radPdfViewerNavigator1.Size = new System.Drawing.Size(762, 36);
            this.radPdfViewerNavigator1.TabIndex = 0;
            this.radPdfViewerNavigator1.ThemeName = "Windows8";
            // 
            // radPdfViewer1
            // 
            this.radPdfViewer1.AllowDrop = true;
            this.radPdfViewer1.FitToWidth = true;
            this.radPdfViewer1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPdfViewer1.Location = new System.Drawing.Point(12, 56);
            this.radPdfViewer1.MaximumSize = new System.Drawing.Size(762, 529);
            this.radPdfViewer1.MinimumSize = new System.Drawing.Size(762, 529);
            this.radPdfViewer1.Name = "radPdfViewer1";
            // 
            // 
            // 
            this.radPdfViewer1.RootElement.MaxSize = new System.Drawing.Size(762, 529);
            this.radPdfViewer1.RootElement.MinSize = new System.Drawing.Size(762, 529);
            this.radPdfViewer1.Size = new System.Drawing.Size(762, 529);
            this.radPdfViewer1.TabIndex = 5;
            this.radPdfViewer1.ThemeName = "Windows8";
            this.radPdfViewer1.ThumbnailsScaleFactor = 0.15F;
            this.radPdfViewer1.ViewerMode = Telerik.WinControls.UI.FixedDocumentViewerMode.None;
            // 
            // frm_preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(780, 641);
            this.Controls.Add(this.radPdfViewer1);
            this.Controls.Add(this.radPdfViewerNavigator1);
            this.Controls.Add(this.btn_Export_confirm);
            this.Controls.Add(this.btn_cancel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(788, 674);
            this.MinimumSize = new System.Drawing.Size(788, 674);
            this.Name = "frm_preview";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(788, 674);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF Preview";
            this.ThemeName = "Windows8";
            ((System.ComponentModel.ISupportInitialize)(this.btn_Export_confirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewerNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPdfViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_Export_confirm;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.UI.RadPdfViewerNavigator radPdfViewerNavigator1;
        private Telerik.WinControls.UI.RadPdfViewer radPdfViewer1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme2;
        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme1;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme3;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme4;
        private Telerik.WinControls.Themes.FluentDarkTheme fluentDarkTheme2;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
    }
}
