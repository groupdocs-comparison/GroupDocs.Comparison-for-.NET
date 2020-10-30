---
id: accept-or-reject-detected-changes
url: comparison/net/accept-or-reject-detected-changes
title: Accept or Reject detected changes
weight: 1
description: "Following this guide you will learn how to apply or discard changes detected during document comparison process using GroupDocs.Comparison for .NET API."
keywords: Apply changes to compared document, reject comparison changes, document comparison changes
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provides an ability to apply or discard specific changes between source and target documents and save resultant document with (or without) selected changes.  
The following are the steps to apply/reject changes to resultant document.

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method  and specify path target document path or stream;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method;
*   Call [GetChanges](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/getchanges/index) method and obtain detected changes list;
*   Set [ComparisonAction](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/changeinfo/properties/comparisonaction) of needed change object to [ComparisonAction.Accept](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/comparisonaction) or [ComparisonAction.Reject](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/comparisonaction) value;
*   Call [ApplyChanges](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/applychanges/index) method and pass collection of changes to it.

[ApplyChangeOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/applychangeoptions) class:

*   [Changes](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/applychangeoptions/properties/changes) - List of changes that must be applied (or not) to the resulting document;
*   [SaveOriginalState](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/applychangeoptions/properties/saveoriginalstate) - Keep the original state of the compared result after applying changes.

The following code sample shows how to accept/reject detected changes.

## Accept or Reject changes for documents stored at local disk

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare();
    ChangeInfo[] changes = comparer.GetChanges();
    changes[0].ComparisonAction = ComparisonAction.Reject;
    comparer.ApplyChanges(File.Create("result.docx"), new SaveOptions(), new ApplyChangeOptions() { Changes = changes });
}
```

## Accept or Reject changes for documents provided as a stream

```csharp
using (Comparer comparer = new Comparer(File.OpenRead("source.docx")))
{
	comparer.Add(File.OpenRead("target.docx"));
    comparer.Compare(new SaveOptions(), new CompareOptions());
    ChangeInfo[] changes = comparer.GetChanges(new GetChangeOptions());
    changes[0].ComparisonAction = ComparisonAction.Reject;
    comparer.ApplyChanges(File.Create("result.docx"), new SaveOptions(), new ApplyChangeOptions() { Changes = changes });
}
```

## The following code sample shows how to accept/reject detected changes using SaveOriginalState option

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare();
    ChangeInfo[] changes = comparer.GetChanges();
    changes[0].ComparisonAction = ComparisonAction.Reject;
    comparer.ApplyChanges("resultWithRejectedChange.docx", new ApplyChangeOptions() { Changes = changes, SaveOriginalState = true });
    changes = comparer.GetChanges();
    changes[0].ComparisonAction = ComparisonAction.Accept;
    comparer.ApplyChanges("resultWithAcceptedChange.docx", new ApplyChangeOptions() { Changes = changes });
}
```

## More resources
### GitHub Examples
You may easily run the code above and see the feature in action in our GitHub examples:
*   [GroupDocs.Comparison for .NET examples, plugins, and showcase](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET)
*   [GroupDocs.Comparison for Java examples, plugins, and showcase](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-Java)
*   [Document Comparison for .NET MVC UI Example](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET-MVC)
*   [Document Comparison for .NET App WebForms UI Modern Example](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET-WebForms)
*   [Document Comparison for Java App Dropwizard UI Modern Example](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-Java-Dropwizard)
*   [Document Comparison for Java Spring UI Example](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-Java-Spring)
    
### Free Online App
Along with full-featured .NET library we provide simple, but powerful free Apps.  
You are welcome to compare your DOC or DOCX, XLS or XLSX, PPT or PPTX, PDF, EML, EMLX, MSG and other documents with free to use online [GroupDocs Comparison App](https://products.groupdocs.app/comparison).