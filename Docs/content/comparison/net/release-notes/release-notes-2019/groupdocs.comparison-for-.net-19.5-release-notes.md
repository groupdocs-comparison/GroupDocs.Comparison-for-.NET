---
id: groupdocs-comparison-for-net-19-5-release-notes
url: comparison/net/groupdocs-comparison-for-net-19-5-release-notes
title: GroupDocs.Comparison for .NET 19.5 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 19.5{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 19.5:

*   Implemented calculation of changes for Diagrams, Slides and PDF formats
*   Implemented getting document information method
*   Improved exceptions and error handling all around the projects for all supported formats
*   Fixed issue with getting images for HTML files
*   Fixed issue with Fonts detection
*   Fixed incorrect different in PDF
*   Improved changes detection in tables on Words documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-1847 | Calculate correct coordinates of changes for Slides | Feature |
| COMPARISONNET-1849  | Calculate correct coordinates of changes for PDF | Feature |
| COMPARISONNET-1852  | Calculate correct coordinates of changes for Diagrams | Feature |
| COMPARISONNET-1895  | Implement Get document info method | Feature |
| COMPARISONNET-1773  | Error handling improvements for all formats | Improvement |
| COMPARISONNET-1799  | Improve change detection in tables on Words | Improvement |
| COMPARISONNET-1808  | Comparison is not working on Footnote | Bug |
| COMPARISONNET-1774  | Can't get images for HTML files | Bug |
| COMPARISONNET-1805  | Deleted items in comparison output is not as expected | Bug |
| COMPARISONNET-1892  | Incorrect difference info in PDF | Bug |
| COMPARISONNET-1899  | Html MarkDeletedInsertedContentDeep Bug | Bug |
| COMPARISONNET-1903  | License issue in GroupDocs.Comparison for .NET application | Bug |
| COMPARISONNET-1906  | Font detection exception | Bug |
| COMPARISONNET-1909  | Word separation exception | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 19.5. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  **Extended PageImage properties**  
    For now PageImage class was extended by adding 2 public properties *Width* and *Height*
    
    ```csharp
    Comparer comparer = new Comparer();
     
    // get the list of pages as images
    List<PageImage> sourceImages = comparer.ConvertToImages(sourcePath);
    // getting sizes of first page
    int h = sourceImages[0].Height;
    int w = sourceImages[0].Width;
    ```
    
2.  **Getting coordinates of changes**  
    
    Getting coordinates of specific changes in Result document is working for **Slides, PDF** and **Diagrams** documents
    
    To use this feature you should specify in *ComparisonSettings CalculateComponentCoordinates* property
    
    ```csharp
    ComparisonSetting settings = new ComparisonSetting
    {
       ...
       CalculateComponentCoordinates = true;
       ...
    }
    ```
    
    The coordinates of changes will be stored in *Box* property of *ChangeInfo* class
    
    ```csharp
    List<ChangeInfo> changes = new List<ChangeInfo>(result.GetChanges());
    chages[0].Box // coordinates of first change
    ```
    
    Example of further using this option:
    
    ```csharp
    ComparisonSettings comparisonsettings = new ComparisonSettings();
    comparisonSettings.StyleChangeDetection = true;
    //this setting specify that we want to have change coordinates
    comparisonSettings.CalculateComponentCoordinates = true;
    comparisonSettings.DetailLevel = DetailLevel.High;
    string sourcePath = "source.pdf";
    string targetPath = "target.pdf";
    string resultPath = "result.pdf;
    Comparer comparer = new Comparer();
    ICompareResult result = comparer.Compare(sourcePath, targetPath, comparisonSettings);
    result.SaveDocument(resultPath);
     
    List<PageImage> resultImages = comparer.ConvertToImages(resultPath);
    List<ChangeInfo> changes = new List<ChangeInfo>(result.GetChanges());
     
    //below the one of cases how we could use changes coordinates.
    //we are passing through pages object and draw a rectangle in the coordinates of changes
    foreach (PageImage image in resultImages)
    {
    	Bitmap bitmap = new Bitmap(image.PageStream);
    	using (Graphics graphics = Graphics.FromImage(bitmap))
    	{
    		foreach (ChangeInfo changeInfo in changes)
    		{
    			//if something was Inserted draw a Blue rectange
    			if (changeInfo.Type == TypeChanged.Inserted)
    				graphics.DrawRectangle(new Pen(Color.Blue), changeInfo.Box.X, changeInfo.Box.Y, changeInfo.Box.Width, changeInfo.Box.Height);
    			//if something was Deleted draw a Red rectange
    			if (changeInfo.Type == TypeChanged.Deleted)
    				graphics.DrawRectangle(new Pen(Color.Red), changeInfo.Box.X, changeInfo.Box.Y, changeInfo.Box.Width, changeInfo.Box.Height);
    			//if something was Changes draw a Green rectange
    			if (changeInfo.Type == TypeChanged.StyleChanged)
    				graphics.DrawRectangle(new Pen(Color.Green), changeInfo.Box.X, changeInfo.Box.Y, changeInfo.Box.Width, changeInfo.Box.Height);
    		}
    	}
    	bitmap.Save(savePath + @"/Result_Pages/result_" + image.PageNumber + ".png");
    	bitmap.Dispose();
    }
    ```
    
3.  **New DocumentInfo class**  
    
    New DocumentInfo class was added. This class contains following properties:
    
    NumberOfPages (read only) - the count of document pages  
    PagesData (read only) - the list of PageInfo classes
    
    PageInfo class contains following properties:  
    Width - the width of page  
    Height - the height of page
    
    ```csharp
    Informer informer = new Informer();
    //get information about document from filePath
    DocumentInfo documentInfo = informer.GetDocumentInfo(filePath);
    ```
