---
id: groupdocs-comparison-for-net-16-10-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-16-10-0-release-notes
title: GroupDocs.Comparison For .NET 16.10.0 Release Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 16.10.0{{< /alert >}}

## Major Features

There are 10 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced  support for new components in Comparison.Slides: comments, charts
*   Introduced support for watermarks  in Comparison.PDF
*   Introduced support for new components in Comparison.PDF: media objects, image positioning
*   Improved ComparisonParagraphAbsorber for cases with tables

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-970 | GroupDocs.Comparison.PDF: add support for new components: media objects, image positioning | New Feature |
| COMPARISONNET-961 | GroupDocs.Comparison.PDF: add support of comparing watermarks | New Feature |
| COMPARISONNET-962 | GroupDocs.Comparison.Slides: Add support of comparing charts | New Feature |
| COMPARISONNET-965 | GroupDocs.Comparison.Slides: Add support of comparing comments | New Feature |
| COMPARISONNET-949 | GroupDocs.Comparison.PDF: improve compare tables | Improvement |
| COMPARISONNET-903 | GroupDocs.Comparison.PDF: improve ComparisonParagraphAbsorber for cases with tables | Improvement |
| COMPARISONNET-982 | GroupDocs.Comparison.PDF: improve document builder and page mapper | Improvement |
| COMPARISONNET-904 | GroupDocs.Comparison.PDF:Checking and improving of ComparisonParagraphAbsorber for cases with plain text | Improvement |
| COMPARISONNET-968 | GroupDocs.Comparison.Words: Identical text from neighboring paragraphs is defined as deleted and inserted | Bug |
| COMPARISONNET-964 | GroupDocs.Comparison.Slides: Files are not opened after comparison | Bug |

  

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 16.10.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

#### Compare words documents

Compare source document with two target documents method MultiCompareWith.



```csharp
// Enter documents paths
string sourcePath = @"Groupdocs.Comparison.Samples.data.Words.source.docx";
string target1Path = @"Groupdocs.Comparison.Samples.data.Words.target1.docx";
string target2Path = @"Groupdocs.Comparison.Samples.data.Words.target2.docx";

// Create list of targets documents
List<IComparisonDocument> ListOfTargetDocuments = new List<IComparisonDocument>();

// Open documents
ComparisonDocument source = new ComparisonDocument(sourcePath);
ComparisonDocument target1 = new ComparisonDocument(target1Path);
ComparisonDocument target2 = new ComparisonDocument(target2Path);

// Add target documents in list
ListOfTargetDocuments.Add(target1);
ListOfTargetDocuments.Add(target2);

// Call method MultiCompareWith.
IWordsCompareResult result = source.MultiCompareWith(ListOfTargetDocuments, new WordsComparisonSettings());

```

#### Compare source document with three target documents method MultiCompareWith.



```csharp
 // Enter documents paths
string sourcePath = @"Groupdocs.Comparison.Samples.data.Words.source.docx";
string target1Path = @"Groupdocs.Comparison.Samples.data.Words.target1.docx";
string target2Path = @"Groupdocs.Comparison.Samples.data.Words.target2.docx";
string target3Path = @"Groupdocs.Comparison.Samples.data.Words.target3.docx";

// Create list of targets documents
List<IComparisonDocument> ListOfTargetDocuments = new List<IComparisonDocument>();

// Open documents
ComparisonDocument source = new ComparisonDocument(sourcePath);
ComparisonDocument target1 = new ComparisonDocument(target1Path);
ComparisonDocument target2 = new ComparisonDocument(target2Path);
ComparisonDocument target3 = new ComparisonDocument(target3Path);

// Add target documents in list
ListOfTargetDocuments.Add(target1);
ListOfTargetDocuments.Add(target2);
ListOfTargetDocuments.Add(target3);

// Call method MultiCompareWith.
IWordsCompareResult result = source.MultiCompareWith(ListOfTargetDocuments, new WordsComparisonSettings());

```
