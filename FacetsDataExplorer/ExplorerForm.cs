//ExplorerForm.cs
//
// Copyright © 2018-2019 Mavidian Technologies Limited Liability Company. All Rights Reserved.

using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FacetsDataExplorer
{
   /// <summary>
   /// A dialog form to view and edit XML data, such as FacetsData exposed by Facets extensions.
   /// Sample usage:
   /// <code language="c#">
   ///   using (var explorerForm = new ExplorerForm())
   ///   {
   ///      explorerForm.AssignExitPoint(..name of exit point..);
   ///      explorerForm.AssignFacetsData(..FacetsData (XML)..);
   ///      if (explorerForm.ShowDialog() == DialogResult.Yes)
   ///      {
   ///          var updatedFacetsData = explorerForm.RetrieveFacetsData();
   ///          //act on updatedFacetsData, e.g. ..SetData(string.Empty, updatedFacetsData);
   ///      }
   ///   }
   /// </code>
   /// </summary>
   public partial class ExplorerForm : Form
   {
      public ExplorerForm()
      {
         InitializeComponent();
      }


      private bool _formDataIsDirty;
      private bool _enableDataRetrieval;
      private string _currentData;


      /// <summary>
      /// Accept the name of current exit point to display on the form.
      /// </summary>
      /// <param name="exitPoint">The name of the exit point to display.</param>
      /// <returns>true if data sucessfully assigned, false if submitted data contains no visible text.</returns>
      public bool AssignExitPoint(string exitPoint)
      {
         if (string.IsNullOrWhiteSpace(exitPoint)) return false;
         this.lblExitPoint.Text = "At " + exitPoint + " now";
         return true;
      }


      /// <summary>
      /// Accept an XML string, parse it and populate the form with it.
      /// </summary>
      /// <param name="xmlData">The XML string to parse and display.</param>
      /// <returns>true if data sucessfully assigned, false if submitted XML is invalid.</returns>
      public bool AssignFacetsData(string xmlData)
      {
         XmlNodeData xmlNodeData;
         try { xmlNodeData = new XmlNodeData(xmlData); }
         catch (System.Xml.XmlException)
         {
            MessageBox.Show("Submitted text is not a valid XML.", "FacetsDataExplorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }
         var rootNode = CreateTreeNodeHierarchy(xmlNodeData);
         PopulateTreeView(rootNode);
         ////         this.treDataNodes.SelectedNode = rootNode;
         this.txtNodeContents.Clear();
         return true;
      }


      /// <summary>
      /// Load data into treDataNodes
      /// </summary>
      /// <param name="rootNode"></param>
      private void PopulateTreeView(TreeNode rootNode)
      {
         var treeNodes = this.treDataNodes.Nodes;
         treeNodes.Clear();
         treeNodes.Add(rootNode);
         _currentData = ((XmlNodeData)rootNode.Tag).ToString();
      }


      /// <summary>
      /// Creates a hierarchy of tree nodes for a given XmlNodeData object
      /// </summary>
      /// <param name="hierarchyRoot"></param>
      /// <returns></returns>
      private TreeNode CreateTreeNodeHierarchy(XmlNodeData hierarchyRoot)
      {
         var newTreeNode = new TreeNode(hierarchyRoot.FullName)
         {
            Tag = hierarchyRoot  // //Tag property of each tree node contains a XmlNodeData object that describes node contents
         };
         foreach (var child in hierarchyRoot.Children) newTreeNode.Nodes.Add(CreateTreeNodeHierarchy(child));
         return newTreeNode;
      }


      /// <summary>
      /// Return XML string contained on the form (only available after the form was dismissed with DialogResult=Y).
      /// </summary>
      /// <returns>An XML string (or an empty string if the form was not dismissed with DialogResult=Y).</returns>
      public string RetrieveFacetsData()
      {
         //return FacetsData kept in treDataNodes, but only after the dialog was dismissed via btnSetAndClose
         if (!_enableDataRetrieval) return string.Empty;
         return _currentData;
      }

      private void ExplorerForm_Load(object sender, EventArgs e)
      {
         var asmName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
         this.toolTip1.SetToolTip(this, $@"{asmName.Name}  v{asmName.Version}
Viewer and Editor of XML data, such as FacetsData exposed by Facets extensions.
Copyright © 2018 Mavidian Technologies Limited Liability Company. All Rights Reserved.");

         _formDataIsDirty = false;
         _enableDataRetrieval = false;

         this.treDataNodes.Select();
      }

      private void ExplorerForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         this.lblExitPoint.Text = "At ...exit point... now";
      }

      private void btnClose_Click(object sender, EventArgs e)
      {  //set DialogResult to No, but in case XML has been updated, ask user to confirm losing updates
         if (!_formDataIsDirty || MessageBox.Show("XML updates are pending. OK to close without setting data?",
                                                 "FacetsDataExplorer",
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Question,
                                                 MessageBoxDefaultButton.Button2) == DialogResult.OK)
            this.DialogResult = DialogResult.No;
      }

      private void btnSetAndClose_Click(object sender, EventArgs e)
      {  //DialogResult = Yes
         _enableDataRetrieval = true;
      }

      private void treDataNodes_AfterSelect(object sender, TreeViewEventArgs e)
      {
         //Display the contents of currently selected node
         this.txtNodeContents.Text = ((XmlNodeData)this.treDataNodes.SelectedNode.Tag).ToString();
      }


      /// <summary>
      /// Update current node with new XML data in the NodeConents text box.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void updateNodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var treeNodeToUpdate = this.treDataNodes.SelectedNode;
         if (treeNodeToUpdate == null)
         {
            MessageBox.Show("No current node, please select a node first.", "FacetsDataExplorer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         XElement replacementElement;
         try { replacementElement = XElement.Parse(this.txtNodeContents.Text); }
         catch (Exception)
         {
            MessageBox.Show("Replacement text is not a valid XML.", "FacetsDataExplorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //Verify if old and new node have the same name and attributes (attributes are converted to strings in a form of "name=value" for comparison)
         if (replacementElement.Name.LocalName != ((XmlNodeData)treeNodeToUpdate.Tag).Name ||
             !Enumerable.SequenceEqual(replacementElement.Attributes().Select(a => a.Name.LocalName + "=" + a.Value),
                                       ((XmlNodeData)(treeNodeToUpdate.Tag)).Attributes.Select(a => a.Name.LocalName + "=" + a.Value)))
         {
            MessageBox.Show("Replacement node must have the same name and attributes.", "FacetsDataExplorer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         //All good, proceed with update
         var newTreeNodes = ReplaceTreeNode(treeNodeToUpdate, replacementElement);
         PopulateTreeView(newTreeNodes.Item1);  //Item1 is the rootNode
         _formDataIsDirty = true;
         //// for some reason SelectedNode below does not work as expected; so, go back to root instead
         ////this.treDataNodes.SelectedNode = newTreeNodes.Item2;  //Item2 is the replacement node
         this.treDataNodes.Select();
      }


      /// <summary>
      /// Replace tree node anywhere in the node hierarchy
      /// </summary>
      /// <param name="treeNodeToReplace"></param>
      /// <param name="replacementElement"></param>
      /// <returns>Tuple containing 2 tree nodes: Item1 = root node (to repopulate treDataNodes) and Item2 = replacement node (to make it selected node)</returns>
      private Tuple<TreeNode, TreeNode> ReplaceTreeNode(TreeNode treeNodeToReplace, XElement replacementElement)
      {
         var oldNodeData = (XmlNodeData)treeNodeToReplace.Tag;
         var index = oldNodeData.SeqNo;  //index to replace node in the parent node
         var newNodeData = new XmlNodeData(replacementElement, oldNodeData.Level, index);

         var replacementTreeNode = CreateTreeNodeHierarchy(newNodeData);
         var parentNode = treeNodeToReplace.Parent;
         TreeNode rootNode;
         if (parentNode == null)
         {  //end of recursion, mark the new root node (to be kept as Item1 in return value)
            rootNode = replacementTreeNode;
         }
         else
         {  //update parent node (recursively)
            parentNode.Nodes.RemoveAt(index);
            parentNode.Nodes.Insert(index, replacementTreeNode);

            //newParentElement is the same as current, except for the current element
            var parentNodeData = (XmlNodeData)parentNode.Tag;
            var replacemeentParentElement = new XElement(parentNodeData.Name);
            replacemeentParentElement.Add(parentNodeData.Attributes);
            replacemeentParentElement.Add(parentNodeData.Element.Elements().Select((e, i) => i == newNodeData.SeqNo ? replacementElement : e));
            var newNodes = ReplaceTreeNode(parentNode, replacemeentParentElement);
            rootNode = newNodes.Item1;
         }
         return Tuple.Create(rootNode, replacementTreeNode);
      }

      /// <summary>
      /// Copy the "last good known" XML of current node to clipboard.
      /// "Last good known" means updated via Update Node Contents (or original XML).
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void copyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var currentNode = this.treDataNodes?.SelectedNode;
         if (currentNode == null) MessageBox.Show("No current node, please select a node first.", "FacetsDataExplorer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         else Clipboard.SetText(((XmlNodeData)currentNode.Tag).ToString());
      }
   }
}
