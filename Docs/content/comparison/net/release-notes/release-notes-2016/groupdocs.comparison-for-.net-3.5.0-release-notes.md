---
id: groupdocs-comparison-for-net-3-5-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-3-5-0-release-notes
title: GroupDocs.Comparison For .NET 3.5.0 Release Notes
weight: 4
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 3.5.0{{< /alert >}}

## Major Features

There are 9 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced multiple comparison support for Comparison.Words
*   Introduced apply/discart support for multiple comparison for Comparison.Words
*   Introduced page header and foooter text absorbers for Comparison.PDF
*   Improved  paragraph absorber for Comparison.PDF

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-877 | GroupDocs.Comparison.Words: Add option to compose multiple result list from result lists of each document | New Feature |
| COMPARISONNET-876 | GroupDocs.Comparison.Words: Support comparing multiple documents with track changes | New Feature |
| COMPARISONNET-909 | GroupDocs.Comparison.PDF: Add support of absorption of the Page Footer | New Feature |
| COMPARISONNET-910 | GroupDocs.Comparison.PDF: Add support of absorption of the Page Header | New Feature |
| COMPARISONNET-880 | GroupDocs.Comparison.Words: Add apply/discard changes support for multiple result changes list | New Feature |
| COMPARISONNET-880 | GroupDocs.Comparison.Words: Document processing performance improvement | Improvement |
| COMPARISONNET-886 | GroupDocs.Comparison.PDF: Divide text into paragraphs by checking if the text fragments are contained in different parent objects | Improvement |
| COMPARISONNET-904 | GroupDocs.Comparison.PDF: Improved Comparison paragraph absorber for cases with plain text | Improvement |
| COMPARISONNET-873 | GroupDocs.Comparison.PDF: Improved text comparison support for all Adobe Acrobat formats | Improvement |

  

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 3.5.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

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
