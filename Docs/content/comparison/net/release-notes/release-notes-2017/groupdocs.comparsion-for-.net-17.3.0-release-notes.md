---
id: groupdocs-comparsion-for-net-17-3-0-release-notes
url: comparison/net/groupdocs-comparsion-for-net-17-3-0-release-notes
title: GroupDocs.Comparsion for .NET 17.3.0 Release Notes
weight: 9
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 17.3.0{{< /alert >}}

## Major Features

There are 3 new features and 4 improvements and 1 fix in this regular monthly release. The most notable are:

*   Add ability of comparing DICOM documents by Comparison.Imaging
*   Simplified and improved public API across all supported formats
*   Introduced the process absorbing of tables with merged cells for GroupDocs.Comparison.PDF
*   Fixed comparing filled tables for GroupDocs.Comparison.PDF

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-1156 | Add ability of comparing DICOM documents by Comparison.Imaging | New Feature |
| COMPARISONNET-1163 | Apply/Discard changes for DICOM format | New Feature |
| OMPARISONNET-1165 | Add summary page to images streams | New Feature |
| COMPARISONNET-778 | Implement the process absorbing of tables with merged cells | Improvement |
| COMPARISONNET-1148 | Improved public API | Improvement |
| COMPARISONNET-1161 | Add ability for comparison of result and original files in Imaging.Tests | Improvement |
| COMPARISONNET-1157 | Add localize exceptions for wrong passwords while opening documents in Cells, Words, Slides and PDF | Improvement |
| COMPARISONNET-1160 | PDF Comparison - PDF files with tables and footer lines generating unexpected output | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 17.3.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Default licensing

1\. Create license object and use method SetLicense() that takes path to license or license stream as argument

```csharp
License license = new License();
license.SetLicense("path to license");

//or
License license = new License();
license.SetLicense("license stream");
```

### Metered licensing

2\. Create metered object and use method SetMeteredKey()

```csharp
// Set metered key
Metered metered = new Metered();
metered.SetMeteredKey("****", "****");
```

To check current consumption quantity use GetConsumptionQuantity() method

```csharp
// Get consumption quantity from metered
decimal amountBefor = Metered.GetConsumptionQuantity();
// Call comparison
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";
Comparer comparer = new Comparer();
comparer.Compare(sourcePath, targetPath, new ComparisonSettings());
comparer.Compare(sourcePath, targetPath, new ComparisonSettings());
// Get consumption quantity from metered after several calls of comparison
decimal amountAfter = Metered.GetConsumptionQuantity();
```

### Compare two documents from files:

```csharp
string source = "source.docx";
string target = "target.docx";
Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, target, new ComparisonSettings());
```

### Compare two documents from streams:

```csharp
Stream source = Assembly.GetExecutingAssembly().GetManifestResourceStream("source.docx");
Stream target = Assembly.GetExecutingAssembly().GetManifestResourceStream("target.docx");

Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, target, new ComparisonSettings());
Compare two documents with passwords from files:
string source = "source.docx";
string target = "target.docx";
string sourcePassword = "password";
string targetPassword = "password";
Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, sourcePassword, target, targetPassword, new ComparisonSettings());
Compare two documents with passwords from streams:
Stream source = Assembly.GetExecutingAssembly().GetManifestResourceStream("source.docx");
Stream target = Assembly.GetExecutingAssembly().GetManifestResourceStream("target.docx");

string sourcePassword = "password";
string targetPassword = "password";

Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, sourcePassword, target, targetPassword, new ComparisonSettings());
```
