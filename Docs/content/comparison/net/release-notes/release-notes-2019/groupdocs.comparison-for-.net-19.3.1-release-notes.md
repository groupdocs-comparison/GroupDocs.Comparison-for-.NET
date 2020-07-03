---
id: groupdocs-comparison-for-net-19-3-1-release-notes
url: comparison/net/groupdocs-comparison-for-net-19-3-1-release-notes
title: GroupDocs.Comparison for .NET 19.3.1 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 19.3.1{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 19.3.1:

*   Implemented ability to convert documents of different formats to images
*   Fixed issue with SuperScript and SubScript elements on Words documents
*   Fixed style settings for GroupDocs.Comparison.Html
*   Fixed issue with comparing large sized PDF files (another cases)
*   Fixed not working comparison of EndNote element on Words

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-1836 | Save documents as images for Words | Feature |
| COMPARISONNET-1837 | Save documents as images for Cells | Feature |
| COMPARISONNET-1838 | Save documents as images for Slides | Feature |
| COMPARISONNET-1839 | Save documents as images for PDF | Feature |
| COMPARISONNET-1840 | Save documents as images for HTML | Feature |
| COMPARISONNET-1841 | Save documents as images for Email | Feature |
| COMPARISONNET-1842 | Save documents as images for Note | Feature |
| COMPARISONNET-1843 | Save documents as images for Text | Feature |
| COMPARISONNET-1844 | Save documents as images for Diagrams | Feature |
| COMPARISONNET-1806 | Issue on SuperScript and SubScript | Bug |
| COMPARISONNET-1802 | Settings StyleSettings is not working for html | Bug |
| COMPARISONNET-1803 | Issue in comparing large sized PDF files (another cases) | Bug |
| COMPARISONNET-1804 | EndNote Comparison is not working | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 19.3.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  Getting Image representation of document pages
    
    ```csharp
    Comparer comparer = new Comparer();
    ComparisonSettings cs = new ComparisonSettings();
    cs.StyleChangeDetection = true;
     
     
    //compare document
    ICompareResult result = comparer.Compare(sourcePath, targetPath, cs);
    result.SaveDocument(resultPath);
     
     
    //get list of pages
    List<PageImage> resultImages = comparer.ConvertToImages(resultPath);
     
     
    //save them as bitmap to separate folder
    if (!Directory.Exists(savePath + @"/Result Pages")) 
       Directory.CreateDirectory(savePath + @"/Result Pages");
     
     
    foreach (PageImage image in resultImages)
    { 
         Bitmap bitmap = new Bitmap(image.PageStream); 
         bitmap.Save(savePath + @"/Result Pages/result_" + image.PageNumber + ".png"); 
         bitmap.Dispose(); 
    }
    ```
