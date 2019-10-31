# FacetsDataExplorer

There are two projects located in this repository: FacetsDataExplorer and ExplorerLauncher.

## FacetsDataExplorer

A class library that exposes ExplorerForm class, which displays a given XML string and allows easy manipulation
of its contents. It is a handy component of a Facets XCOM extension intended to explore data exposed by Facets.
Facets is a proprietary platform owned by TriZetto, a Cognizant Company.

Members of the ExplorerForm class:

**AssignExitPoint**

``` cs
bool AssignExitPoint(string nameOfCurrentExitPointToDisplay)
```

Accept name of the exit point to be displayed on the ExplorerForm.
Return true if parameter data was accepted, i.e. contained non-whitespace text.

**AssignFacetsData**

``` cs
bool AssignFacetsData(string currentFacetsDataToExplore)
```

Accept XML data to be displayed on the form, explored and updated.
Return true if parameter data was accepted, i.e. contained a valid XML.

**ShowDialog**

``` cs
DialogResult ShowDialog()
```

Display the form as a modal dialog. Return values:
* `No ` - The form was dismissed using the "Close" button.
* `Yes` - The form was dismissed using the "SetData and Close" button.

**RetrieveFacetsData**

``` cs
string RetrieveFacetsData()
```
Return updated XML data after the form was dismissed using the "SetData and Close" button (`DialogResult.Yes`).
Return null otherwise, e.g. if the form was dismissed using the "Close" button (`DialogResult.No`).


### Sample C# code snippet to use ExplorerForm

``` cs
using FacetsDataExplorer;
using System.Windows.Forms;

...

   string currentExitPoint = "EXIT POINT";      //obtain actual value from current context
   string currentFacetsData = "<FacetsData/>";  //obtain actual value from Facets
   string updatedFacetsData = null;
   
   using (var explorerForm = new ExplorerForm())
   {
      explorerForm.AssignExitPoint(currentExitPoint);
      if (explorerForm.AssignFacetsData(currentFacetsData))
      {  //XML was valid and accepted by the form
         if (explorerForm.ShowDialog() == DialogResult.Yes)
         {  //form dismissed using the "SetData and Close" button 
            updatedFacetsData = explorerForm.RetrieveFacetsData();
            //take additional actions, such as set updatedFacetsData to Facets
         }
          else
          {  //form dismissed using the "SetData and Close" button 
             //updatedFacetsData will be null in this case.
          }
      }
   }
```

### Sample FacetsDataExplorer screenshot

![Sample FacetsDataExplorer screenshot](https://mavidian.com/files/FacetsDataExplorer_screenshot.png)

## ExplorerLauncher

This project simulates the behavior of a Facets XCOM extension. It is a startup project of the solution and can be used to
test the behavior of FacetsDataExplorer. Usage:

1. Run the ExplorerLauncher (e.g. F5 in Visual Studio); a form titled "Entry Form for FacetsDataExplorer" will appear.
2. Fill in Exit Point and Facets Data textboxes. There is a file with sample Facets Data in the Data folder of this repo.
3. Click "Launch Explorer Dialog" button; a form titled "FacetsDataExplorer Form" similar to the above screenshot will apear.
4. Explore the XML data displayed. Some of the things you can do:
	* Expand/colapse nodes using the left pane.
	* Navigate to individual nodes.
	* Copy the node contents to clipboard by R-clicking on the right pane and selecting "Copy".
	* Update the node contents using the right pane; after update you must R-click "Update Node Contents" to persist update.
5. Dismiss the form using either "Close" or "SetData and Close" button.
6. Click "Exit" to exit application.
