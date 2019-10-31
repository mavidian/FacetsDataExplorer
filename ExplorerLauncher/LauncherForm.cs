//LauncherForm.cs
//
// Copyright © 2018-2019 Mavidian Technologies Limited Liability Company. All Rights Reserved.

using FacetsDataExplorer;
using System;
using System.Windows.Forms;

namespace ExplorerLauncher
{
   public partial class LauncherForm : Form
   {
      public LauncherForm()
      {
         InitializeComponent();
      }

      private void btnLaunch_Click(object sender, EventArgs e)
      {
         using (var explorerForm = new ExplorerForm())
         {
            explorerForm.AssignExitPoint(this.txtExitPoint.Text);
            if (explorerForm.AssignFacetsData(this.txtFacetsData.Text))
            {  //XML is valid
               if (explorerForm.ShowDialog() == DialogResult.Yes)
               {
                  this.txtFacetsData.Text = explorerForm.RetrieveFacetsData();
               }
            }
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
