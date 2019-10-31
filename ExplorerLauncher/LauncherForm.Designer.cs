namespace ExplorerLauncher
{
   partial class LauncherForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
         this.lblExitPoint = new System.Windows.Forms.Label();
         this.txtExitPoint = new System.Windows.Forms.TextBox();
         this.lblFacetsData = new System.Windows.Forms.Label();
         this.txtFacetsData = new System.Windows.Forms.TextBox();
         this.btnLaunch = new System.Windows.Forms.Button();
         this.btnClose = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // lblExitPoint
         // 
         this.lblExitPoint.AutoSize = true;
         this.lblExitPoint.Location = new System.Drawing.Point(12, 15);
         this.lblExitPoint.Name = "lblExitPoint";
         this.lblExitPoint.Size = new System.Drawing.Size(51, 13);
         this.lblExitPoint.TabIndex = 0;
         this.lblExitPoint.Text = "Exit Point";
         // 
         // txtExitPoint
         // 
         this.txtExitPoint.Location = new System.Drawing.Point(73, 12);
         this.txtExitPoint.Name = "txtExitPoint";
         this.txtExitPoint.Size = new System.Drawing.Size(114, 20);
         this.txtExitPoint.TabIndex = 2;
         // 
         // lblFacetsData
         // 
         this.lblFacetsData.AutoSize = true;
         this.lblFacetsData.Location = new System.Drawing.Point(12, 44);
         this.lblFacetsData.Name = "lblFacetsData";
         this.lblFacetsData.Size = new System.Drawing.Size(65, 13);
         this.lblFacetsData.TabIndex = 3;
         this.lblFacetsData.Text = "Facets Data";
         // 
         // txtFacetsData
         // 
         this.txtFacetsData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFacetsData.Location = new System.Drawing.Point(12, 60);
         this.txtFacetsData.MaxLength = 0;
         this.txtFacetsData.Multiline = true;
         this.txtFacetsData.Name = "txtFacetsData";
         this.txtFacetsData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtFacetsData.Size = new System.Drawing.Size(336, 150);
         this.txtFacetsData.TabIndex = 4;
         // 
         // btnLaunch
         // 
         this.btnLaunch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btnLaunch.Location = new System.Drawing.Point(82, 216);
         this.btnLaunch.Name = "btnLaunch";
         this.btnLaunch.Size = new System.Drawing.Size(138, 29);
         this.btnLaunch.TabIndex = 5;
         this.btnLaunch.Text = "Launch &Explorer Dialog";
         this.btnLaunch.UseVisualStyleBackColor = true;
         this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
         // 
         // btnClose
         // 
         this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btnClose.Location = new System.Drawing.Point(226, 216);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(52, 29);
         this.btnClose.TabIndex = 6;
         this.btnClose.Text = "E&xit";
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // LauncherForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(360, 257);
         this.Controls.Add(this.btnClose);
         this.Controls.Add(this.btnLaunch);
         this.Controls.Add(this.txtFacetsData);
         this.Controls.Add(this.lblFacetsData);
         this.Controls.Add(this.txtExitPoint);
         this.Controls.Add(this.lblExitPoint);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimumSize = new System.Drawing.Size(236, 185);
         this.Name = "LauncherForm";
         this.Text = "Entry Form for FacetsData Explorer";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lblExitPoint;
      private System.Windows.Forms.TextBox txtExitPoint;
      private System.Windows.Forms.Label lblFacetsData;
      private System.Windows.Forms.TextBox txtFacetsData;
      private System.Windows.Forms.Button btnLaunch;
      private System.Windows.Forms.Button btnClose;
   }
}

