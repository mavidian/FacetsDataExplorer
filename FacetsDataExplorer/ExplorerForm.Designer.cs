namespace FacetsDataExplorer
{
   partial class ExplorerForm
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
         this.btnClose = new System.Windows.Forms.Button();
         this.btnSetAndClose = new System.Windows.Forms.Button();
         this.conTreeAndContents = new System.Windows.Forms.SplitContainer();
         this.treDataNodes = new System.Windows.Forms.TreeView();
         this.txtNodeContents = new System.Windows.Forms.TextBox();
         this.mnuNodeContents = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.updateNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.lblExitPoint = new System.Windows.Forms.Label();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.conTreeAndContents)).BeginInit();
         this.conTreeAndContents.Panel1.SuspendLayout();
         this.conTreeAndContents.Panel2.SuspendLayout();
         this.conTreeAndContents.SuspendLayout();
         this.mnuNodeContents.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnClose
         // 
         this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btnClose.Location = new System.Drawing.Point(331, 315);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(74, 29);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "&Close";
         this.toolTip1.SetToolTip(this.btnClose, "Click to dismiss the form without setting data.");
         this.btnClose.UseVisualStyleBackColor = true;
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnSetAndClose
         // 
         this.btnSetAndClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btnSetAndClose.DialogResult = System.Windows.Forms.DialogResult.Yes;
         this.btnSetAndClose.Location = new System.Drawing.Point(180, 315);
         this.btnSetAndClose.Name = "btnSetAndClose";
         this.btnSetAndClose.Size = new System.Drawing.Size(145, 29);
         this.btnSetAndClose.TabIndex = 1;
         this.btnSetAndClose.Text = "&SetData and Close";
         this.toolTip1.SetToolTip(this.btnSetAndClose, "Click to set current data and dismiss the form.");
         this.btnSetAndClose.UseVisualStyleBackColor = true;
         this.btnSetAndClose.Click += new System.EventHandler(this.btnSetAndClose_Click);
         // 
         // conTreeAndContents
         // 
         this.conTreeAndContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.conTreeAndContents.Location = new System.Drawing.Point(12, 41);
         this.conTreeAndContents.Name = "conTreeAndContents";
         // 
         // conTreeAndContents.Panel1
         // 
         this.conTreeAndContents.Panel1.Controls.Add(this.treDataNodes);
         // 
         // conTreeAndContents.Panel2
         // 
         this.conTreeAndContents.Panel2.Controls.Add(this.txtNodeContents);
         this.conTreeAndContents.Size = new System.Drawing.Size(560, 268);
         this.conTreeAndContents.SplitterDistance = 184;
         this.conTreeAndContents.TabIndex = 2;
         // 
         // treDataNodes
         // 
         this.treDataNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treDataNodes.Location = new System.Drawing.Point(0, 0);
         this.treDataNodes.Name = "treDataNodes";
         this.treDataNodes.Size = new System.Drawing.Size(181, 268);
         this.treDataNodes.TabIndex = 0;
         this.toolTip1.SetToolTip(this.treDataNodes, "Expand/colapse nodes; select node to display its contents.");
         this.treDataNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treDataNodes_AfterSelect);
         // 
         // txtNodeContents
         // 
         this.txtNodeContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNodeContents.ContextMenuStrip = this.mnuNodeContents;
         this.txtNodeContents.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtNodeContents.Location = new System.Drawing.Point(3, 0);
         this.txtNodeContents.MaxLength = 0;
         this.txtNodeContents.Multiline = true;
         this.txtNodeContents.Name = "txtNodeContents";
         this.txtNodeContents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.txtNodeContents.Size = new System.Drawing.Size(369, 268);
         this.txtNodeContents.TabIndex = 0;
         this.toolTip1.SetToolTip(this.txtNodeContents, "To update contents, make changes, then R-click and select \"Update Node Contents\"." +
        "\r\nR-click..\"Copy\" copies last good known XML of current node to clipboard.\r\n");
         // 
         // mnuNodeContents
         // 
         this.mnuNodeContents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateNodeToolStripMenuItem,
            this.copyToolStripMenuItem});
         this.mnuNodeContents.Name = "mnuNodeContents";
         this.mnuNodeContents.Size = new System.Drawing.Size(196, 48);
         // 
         // updateNodeToolStripMenuItem
         // 
         this.updateNodeToolStripMenuItem.Name = "updateNodeToolStripMenuItem";
         this.updateNodeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
         this.updateNodeToolStripMenuItem.Text = "Update Node Contents";
         this.updateNodeToolStripMenuItem.Click += new System.EventHandler(this.updateNodeToolStripMenuItem_Click);
         // 
         // copyToolStripMenuItem
         // 
         this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
         this.copyToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
         this.copyToolStripMenuItem.Text = "Copy";
         this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
         // 
         // lblExitPoint
         // 
         this.lblExitPoint.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.lblExitPoint.AutoSize = true;
         this.lblExitPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblExitPoint.ForeColor = System.Drawing.SystemColors.Highlight;
         this.lblExitPoint.Location = new System.Drawing.Point(179, 6);
         this.lblExitPoint.Name = "lblExitPoint";
         this.lblExitPoint.Size = new System.Drawing.Size(223, 29);
         this.lblExitPoint.TabIndex = 3;
         this.lblExitPoint.Text = "At ...exit point... now";
         // 
         // ExplorerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(584, 356);
         this.ControlBox = false;
         this.Controls.Add(this.lblExitPoint);
         this.Controls.Add(this.conTreeAndContents);
         this.Controls.Add(this.btnSetAndClose);
         this.Controls.Add(this.btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimumSize = new System.Drawing.Size(265, 230);
         this.Name = "ExplorerForm";
         this.Text = "FacetsData Explorer Form";
         this.toolTip1.SetToolTip(this, "Viewer and Editor of XML data, such as FacetsData exposed by Facets extensions.\r\n" +
        "Copyright © 2018 Mavidian Technologies Limited Liability Company. All Rights Res" +
        "erved.");
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExplorerForm_FormClosed);
         this.Load += new System.EventHandler(this.ExplorerForm_Load);
         this.conTreeAndContents.Panel1.ResumeLayout(false);
         this.conTreeAndContents.Panel2.ResumeLayout(false);
         this.conTreeAndContents.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.conTreeAndContents)).EndInit();
         this.conTreeAndContents.ResumeLayout(false);
         this.mnuNodeContents.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnClose;
      private System.Windows.Forms.Button btnSetAndClose;
      private System.Windows.Forms.SplitContainer conTreeAndContents;
      private System.Windows.Forms.Label lblExitPoint;
      private System.Windows.Forms.TreeView treDataNodes;
      private System.Windows.Forms.TextBox txtNodeContents;
      private System.Windows.Forms.ContextMenuStrip mnuNodeContents;
      private System.Windows.Forms.ToolStripMenuItem updateNodeToolStripMenuItem;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
   }
}