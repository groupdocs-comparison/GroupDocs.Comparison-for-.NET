---
id: groupdocs-comparison-for-net-20-12-release-notes
url: comparison/net/groupdocs-comparison-for-net-20-12-release-notes
title: GroupDocs.Comparison for .NET 20.12 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 20.12{{< /alert >}}

## Major Features

Below the list of changes in release of GroupDocs.Comparison for .NET 20.12:
*   Improve Revisions handling in Words documents
*   Fixed issue with text duplication in Words
*   Fixed issue with incorrect display of tables without displaying added or deleted cells
*   Fixed GroupDocs.Comparison to work properly within GroupDocs.Total solution


		
| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2557 | Improve Revisions handling in Words documents | Improvement |
| COMPARISONNET-2537 | Comparison of DOCX files Text is duplicated after comparison, rather than being recognized as replaced in the output | Bug |
| COMPARISONNET-2533 | Comparison issue in Word documents with tables (Incorrect document creation with disabled display of changes in tables in Word format) | Bug |
| COMPARISONNET-2536 | Fix Comparison issue on GroupDocs total solution | Bug |

## Public API and Backward Incompatible Changes

1. The problem with redisplaying changed content in a document occurred when there were already other *Revisions* in the documents being compared.

    **Revision** - changes received when comparing documents using built-in Word tools.

    To solve this problem, new *ShowRevisions* property was created that allows you to disable the display of these *Revisions* in the resulting document. An example of the code for using the new property is presented below.

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
    CompareOptions options = new CompareOptions() {ShowRevisions = false};
    comparer.Compare(resultPath, options);
}
```
More information about the new property can be [here](https://docs.groupdocs.com/comparison/net/show-revisions/).

2. [Improved Accept\Reject Revisions functionality for Words documents](https://docs.groupdocs.com/comparison/net/accept-or-reject-revisions/)

