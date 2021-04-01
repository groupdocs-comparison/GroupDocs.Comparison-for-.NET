---
id: groupdocs-comparison-for-net-21-3-release-notes
url: comparison/net/groupdocs-comparison-for-net-21-3-release-notes
title: GroupDocs.Comparison for .NET 21.3 Release Notes
weight: 18
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 21.3{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 21.3:

*   Implemented replacement for empty lines, instead of displaying changes in result document for paragraphs in Word format
*   Improved image comparison in Cells format
*   Improved creating charts in Cells format
*   Improved display of components with styles changes for Word format
*   Fixed issue with closing streams while comparing text documents

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2560 | Word Document comparison output is not as expected | Bug |
| COMPARISONNET-2597 | Excel files comparison issue | Bug |
| COMPARISONNET-2624 | Incomplete creating charts | Bug |
| COMPARISONNET-2626 | Cannot get the line difference and how to show style changes details in output | Bug |
| COMPARISONNET-2627 | Prevent situation when during comparing text file stream is empty | Bug |


## Public API and Backward Incompatible Changes

1.  To see changes in the display of information about components with style changes , you can use the following code:

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
 
    CompareOptions options = new CompareOptions();
    options.DetectStyleChanges = true;
    options.DetalisationLevel = DetalisationLevel.High;
      
    comparer.Compare(resultPath, options);
}
```

2. Learn more about getting result document with changed content replaced with empty lines can be found [here](https://docs.groupdocs.com/comparison/net/show-gap-lines/).
