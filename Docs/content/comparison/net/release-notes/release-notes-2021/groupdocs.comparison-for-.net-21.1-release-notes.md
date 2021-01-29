---
id: groupdocs-comparison-for-net-21-1-release-notes
url: comparison/net/groupdocs-comparison-for-net-21-1-release-notes
title: GroupDocs.Comparison for .NET 21.1 Release Notes
weight: 20
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 21.1{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 21.1:

*   Improved display of elements with a border in Pdf format 
*   Improved text display in Pdf format 
*   Added comparison of footnote types in Word format 
*   Added SourceText property to ChangeInfo class and improved TargetText property for Cells, Words and Pdf formats

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2585 | Improve ability of getting source text for Words documents | Feature |
| COMPARISONNET-2586 | Improve ability of getting source text for PDF documents | Feature |
| COMPARISONNET-2587 | Improve ability of getting source text for Cells documents | Feature |
| COMPARISONNET-2563 | Footnotes are not compared | Improvement |
| COMPARISONNET-2451 | Text Box Comparison issue in PDF | Bug |
| COMPARISONNET-2454 | Part of the symbols are not displayed when comparing PDF files | Bug |


## Public API and Backward Incompatible Changes

1.  Comparison of types of footnotes refers to comparison of styles, besides, this type of change is difficult to display in the text. Therefore these changes are marked on the principle of blank lines or pictures in the document (using comments).
For clarity comparison of footnote types, you could use the following code snippet:

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
    CompareOptions options = new CompareOptions()
	{
		DetectStyleChanges = true,
		DetalisationLevel = DetalisationLevel.High
	};
    comparer.Compare(resultPath, options);
}
```

2. Updated documentation about obtaining source and target texts, which can be found [here](https://docs.groupdocs.com/comparison/net/get-source-and-target-text-from-files/).
