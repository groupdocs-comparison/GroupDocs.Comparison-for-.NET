---
id: groupdocs-comparsion-for-net-17-4-0-release-notes
url: comparison/net/groupdocs-comparsion-for-net-17-4-0-release-notes
title: GroupDocs.Comparsion for .NET 17.4.0 Release Notes
weight: 8
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 17.4.0{{< /alert >}}

## Major Features

There are 3 new features and 3 improvements and 4 fix in this regular monthly release. The most notable are:

*   Introduced support of multi compare for formats to GroupDocs.Comparison public API
*   Introduced supporting of CAD formats
*   Improved comparison of Imaging formats
*   Simplify API across all supported formats
*   Fixed comparing multi-column tables for GroupDocs.Comparison.PDF
*   GroupDocs.Comparison.PDF: Fix bug when the text from the paragraphs overlaps tables

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-1143 | Add support of multi compare for formats to GroupDocs.Comparison public API | New Feature |
| COMPARISONNET-1172 | Add UpdateChanges Model for Imaging | New Feature |
| COMPARISONNET-1175 | Add supporting of comparison CAD | New Feature |
| COMPARISONNET-1188 | Improve comparison of Imaging formats | Improvement |
| COMPARISONNET-1182 | Cross-format API simplifications across all supported formats | Improvement |
| COMPARISONNET-1080 | Comparison.PDF: Improve comparison changes detection for Paragraphs | Improvement |
| COMPARISONNET-1184 | GroupDocs.Comparison.Words: Text files with html content compared by Words engine | Bug |
| COMPARISONNET-1185 | GroupDocs.Comparison.Text: Fix compare html code in .txt files using word comparer | Bug |
| COMPARISONNET-1200 | GroupDocs.Comparison.PDF: Fix bug when the text from the paragraphs overlaps tables | Bug |
| COMPARISONNET-1208 | Disposed Images in Facade | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 17.4.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Compare more than two documents from files:

```csharp
string source = "source.docx";
List<string> targets = new List<string>
{
	"target.docx",
	"target1.docx",
	"target2.docx"
};
Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, targets, new ComparisonSettings());

```

### Compare more than two documents from streams:

```csharp
Stream source = Assembly.GetExecutingAssembly().GetManifestResourceStream("source.docx");
List<Stream> targets = new List<Stream>
{
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target.docx"),
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target1.docx"),
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target2.docx")
}; 
Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, targets, new ComparisonSettings());



```

###  Compare more than two documents with passwords from files:

```csharp
string source = "source.docx";
List<string> targets = new List<string>
{
	"target.docx",
	"target1.docx",
	"target2.docx"
};
string sourcePassword = "password";
List<string> targetPasswords = new List<string>
{
	"password",
	"password",
	"password"
};
Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, sourcePassword, targets, targetPasswords, new ComparisonSettings());
```

### Compare more than two documents with passwords from streams:

```csharp
Stream sourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("source.docx");
List<Stream> targets = new List<Stream>
{
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target.docx"),
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target1.docx"),
	Assembly.GetExecutingAssembly().GetManifestResourceStream("target2.docx")
}; 

string sourcePassword = "password";
List<string> targetPasswords = new List<string>
{
	"password",
	"password",
	"password"
};

Comparer comparer = new Comparer();
ICompareResult result = comparer.Compare(source, sourcePassword, targets, targetPasswords, new ComparisonSettings());
```
