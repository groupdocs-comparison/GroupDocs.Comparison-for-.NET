---
id: groupdocs-comparison-for-net-17-1-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-17-1-0-release-notes
title: GroupDocs.Comparison For .NET 17.1.0 Release Notes
weight: 11
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 17.1.0{{< /alert >}}

## Major Features

There are 7 new features and 7 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced support of support for Apply/Discard changes in Comparison.Cells
*   Introduced support of support for Apply/Discard changes in Comparison.PDF
*   Introduced support of support for Watermarks, Hyperlinks, Comments, Text Box, Shapes in Comparison.Cells
*   Improved GroupDocs.Comparison.PDF comparison efficiency 

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-1053 | GroupDocs.Comparison.PDF: Add support for Apply/Discard changes | New Feature |
| COMPARISONNET-975 | GroupDocs.Comparison.PDF: Add support for Watermarks | New Feature |
| COMPARISONNET-1065 | GroupDocs.Comparison.Cells: Add support for Hyperlinks | New Feature |
| COMPARISONNET-1069 | GroupDocs.Comparison.Cells: Add support for Comments | New Feature |
| COMPARISONNET-1072 | GroupDocs.Comparison.Cells: Add support for Text Box | New Feature |
| COMPARISONNET-1063 | GroupDocs.Comparison.Cells: Add support of Apply/Discard changes | New Feature |
| COMPARISONNET-1073 | GroupDocs.Comparison.Cells: Add support for Shapes | New Feature |
| COMPARISONNET-1075 | GroupDocs.Comparison.Cells: Add borders for deleted and inserted cells and Range of cells | Improvement |
| COMPARISONNET-679 | Fix problem when moving modified table into new page and not deleting previous version of added table | Improvement |
| COMPARISONNET-1055 | Improve Trim paragraphs by pages after some change in absorbing paragraphs | Improvement |
| COMPARISONNET-1080 | GroupDocs.Comparison.PDF: Improve comparison changes detection for Paragraphs | Improvement |
| COMPARISONNET-1056 | Improve GroupDocs.Comparison.PDF comparison quality for images in header, footer, setting coordinates for components and paragraphs by pages | Improvement |
| COMPARISONNET-1074 | GroupDocs.Comparison: PDF: Set type change for paragraph runs after page break | Bug |
| COMPARISONNET-1077 | Comparison.Cells: Fix cells appearance after critical update for Aligner comparer and Document builder | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 17.1.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Compare Spreadsheet file formats with Settings

Update way to use Comparison Settings for Spreadsheet file formats



```csharp
// Enter presentations paths
string sourcePath = "./source.otp";
string targetPath = "./target.otp";

// Create two streams of presentations

Stream sourceStream = File.Open(sourcePath, FileMode.Open, FileAccess.Read);
Stream targetStream = File.Open(targetPath, FileMode.Open, FileAccess.Read)

// Create instance of *GroupDocs.Comparison.Comparison* and call method *Compare*.
GroupDocs.Comparison.Comparison comparison = new GroupDocs.Comparison.Comparison();
CellsComparisonSettings settings = new CellsComparisonSettings();
settings.ShowDeletedContent = false;
settings.GenerateSummaryPage = true;

Stream result = comparison.Compare(sourceStream, targetStream, settings);


```

#### Compare Words file formats with Settings

Update way to use Comparison Settings for Words file formats



```csharp
// Enter Words document paths
string sourcePath = "./source.odt";
string targetPath = "./target.odt";

// Create two streams of Words docuemnt

Stream sourceStream = File.Open(sourcePath, FileMode.Open, FileAccess.Read);
Stream targetStream = File.Open(targetPath, FileMode.Open, FileAccess.Read)

// Create instance of *GroupDocs.Comparison.Comparison* and call method *Compare*.
GroupDocs.Comparison.Comparison comparison = new GroupDocs.Comparison.Comparison();
WordsComparisonSettings settings = new WordsComparisonSettings();
Settings.ProcessHyperLinksAsAText = true;

Stream result = comparison.Compare(sourceStream, targetStream, settings);


```

#### Comparison example for Open Documents file formats



```csharp
// Enter presentations paths
string sourcePath = "./source.otp";
string targetPath = "./target.otp";

// Create two streams of presentations

Stream sourceStream = File.Open(sourcePath, FileMode.Open, FileAccess.Read);
Stream targetStream = File.Open(targetPath, FileMode.Open, FileAccess.Read)

// Create instance of *GroupDocs.Comparison.Comparison* and call method *Compare*.
GroupDocs.Comparison.Comparison comparison = new GroupDocs.Comparison.Comparison();
Stream result = comparison.Compare(sourceStream, targetStream, settings);


```

#### COMPARISONNET-1080 Compare two paragraphs with method CompareWith.



```csharp
// Creating Paragraphs
ComparisonParagraphBase sourceParagraph = new ComparisonParagraph();
sourceParagraph.Text = "This is source Paragraph.";
 
ComparisonParagraphBase targetParagraph = new ComparisonParagraph();
targetParagraph.Text = "This is target Paragraph.";
 
// Creating settings for comparison of Paragraphs
SlidesComparisonSettings settings = new SlidesComparisonSettings();
// Comparing Paragraphs
ISlidesCompareResult compareResult = sourceParagraph.CompareWith(targetParagraph, settings);


```

#### Save presentation to image via image folder



```csharp
/using GroupDocs.Comparison.Slides;
using GroupDocs.Comparison.Slides.Contracts;
using GroupDocs.Comparison.Slides.Contracts.Comparison;
using GroupDocs.Comparison.Slides.Contracts.Enums;
using GroupDocs.Comparison.Common.Images;

//path to file
string filePath = "./presentation.pptx";
  
//path to image folder
string imageFolderPath = "./FolderForImage/";
  
//Open  document
ComparisonPresentationBase presentation = new ComparisonPresentationBase(filePath);
  
//Set settings
var settings = new ComparsionSlidesImageSettings();
  
//Save as Image
presentation.SaveAsImages(imageFolderPath, settings);



```
