---
id: groupdocs-comparison-for-net-3-1-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-3-1-0-release-notes
title: GroupDocs.Comparison For .NET 3.1.0 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 3.1.0{{< /alert >}}

## Major Features

There are 13 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced support of encrypted files
*   Introduced automatic detection of file types
*   Introduced improved Words comparison performance up to 8 times
*   Introduced improved Words comparison quality for text and tables
*   Introduced improved PDF comparison quality for text, tables and images

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-700 | Extend PDF Comparison functionality to get changes or confirm that documents are identical | New Feature |
| COMPARISONNET-663 | Add support of password protected files for Words, Cells, Slides and PDF | New Feature |
| COMPARISONNET-605 | Add support of File Type Detection from Stream | New Feature |
| COMPARISONNET-638 | If content of slide is unique then slide should be marked as Inserted or Deleted | Improvement |
| COMPARISONNET-722 | Update comparison differs according to performance improvement for Words. | Improvement |
| COMPARISONNET-684 | Change differ in CommonAligner to improve comparison performance | Improvement |
| COMPARISONNET-664 | Implement comparison Words with alignment by identical and formation result-document using target-doc and insertion deleted components from source-doc | Improvement |
| COMPARISONNET-588 | Implement localization for exceptions handling | Improvement |
| COMPARISONNET-683 | Modify Comparison Settings in order to support culture information | Improvement |
| COMPARISONNET-682 | Add resetting of stream positions in documents constructors | Improvement |
| COMPARISONNET-681 | Add checker for result document after merging comparison results | Improvement |
| COMPARISONNET-719 | Comparison Results creating Blank page and Extra Spaces for DOCX/PDF | Bug |
| COMPARISONNET-697 | Client Response - comparing attached documents runs between 8-13 minutes depending on hardware, then ends with 0-byte result. | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 3.1.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Common operations with automatic file format detection
#### Compare documents from strings

NOTE: Assuming there are files in source.docx, source.xlsx, source.pdf, source.pptx, source.txt are in the same folder as executing assembly.

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath);
```

#### Compare documents from strings with result path

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath);
```

#### Compare documents from strings with result path and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, FileType.Docx);
```

#### Compare documents from strings with result path and settings

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, new WordsComparisonSettings());
```

#### Compare documents from strings with result path and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, new WordsComparisonSettings(), FileType.Docx);
```

#### Compare documents from strings with result path and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, ComparisonType.Words);
```

#### Compare documents from strings with result path type and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, ComparisonType.Words, FileType.Docx);
```

#### Compare documents from strings with settings

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, new WordsComparisonSettings());
```

#### Compare documents from strings with settings and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, ComparisonType.Words, new WordsComparisonSettings());
```

#### Compare documents from strings with type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, ComparisonType.Words);
```

#### Compare documents from strings with result path settings and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, ComparisonType.Words, new WordsComparisonSettings());
```

#### Compare documents from strings with result path settings type and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, targetPath, resultPath, ComparisonType.Words, new WordsComparisonSettings(), FileType.Docx);
```

### Common operations with encrypted files
#### Compare encrypted documents from strings

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword);
```

#### Compare encrypted documents from strings with result path

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath);
```

#### Compare encrypted documents from strings with result path and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, FileType.Docx);
```

#### Compare encrypted documents from strings with result path and settings

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, new WordsComparisonSettings());
```

#### Compare encrypted documents from strings with result path settings and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, new WordsComparisonSettings(), FileType.Docx);
```

#### Compare encrypted documents from strings with result path and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, ComparisonType.Words);
```

#### Compare encrypted documents from strings with result path type and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, ComparisonType.Words, FileType.Docx);
```

#### Compare encrypted documents from strings with settings

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, new WordsComparisonSettings());
```

#### Compare encrypted documents from strings with settings and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, ComparisonType.Words, new WordsComparisonSettings());
```

#### Compare encrypted documents from strings with type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, ComparisonType.Words);
```

#### Compare encrypted documents from strings with result path settings and type

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, ComparisonType.Words, new WordsComparisonSettings());
```

#### Compare encrypted documents from strings with result path settings type and target extension

```csharp
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";

string sourcePassword = "pass";
string targetPassword = "pass";

Comparison comparison = new Comparison();
Stream result = comparison.Compare(sourcePath, sourcePassword, targetPath, targetPassword, resultPath, ComparisonType.Words, new WordsComparisonSettings(), FileType.Docx);
```
