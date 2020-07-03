---
id: get-list-of-changes
url: comparison/net/get-list-of-changes
title: Get list of changes
weight: 6
description: "This article explains how to get collection of changes between compared documents when using GroupDocs.Comparison for .NET."
keywords: Get file diff, documents diff, compare documents, compare files
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to obtain list of changes between source and target documents.

The following are the steps to obtain changes list.

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare) method;
*   Call [GetChanges](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/getchanges) method.

The following code sample shows demonstrates how to get list of all changes.

## Get list of changes from local disk

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx);
    comparer.Compare();
    ChangeInfo[] changes = comparer.GetChanges();
}
```

## Get list of changes from stream

```csharp
using (Comparer comparer = new Comparer(File.OpenRead("source.docx")))
{
	comparer.Add(File.OpenRead("target.docx));
    comparer.Compare();
    ChangeInfo[] changes = comparer.GetChanges();
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
