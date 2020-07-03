---
id: compare-multiple-documents-protected-by-password
url: comparison/net/compare-multiple-documents-protected-by-password
title: Compare multiple documents protected by password
weight: 1
description: "This article describes how to compare multiple Word documents or PowerPoint presentations protected by password using GroupDocs.Comparison for .NET API."
keywords: Compare multiple password protected documents, compare multiple protected documents
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}NOTE: This feature is available only for Word documents, PowerPoint and Open Document presentations.{{< /alert >}}

[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to compare more that 2 documents (also documents that are protected with a password).

The following are the steps to compare password-protected documents.

*   Instantiate [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) object and specify source document password;
*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream and [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) object created at previous step;
*   Instantiate another [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) object and specify target document password;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream and [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) object created at previous step. Repeat this step for every target document that is password-protected;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method.

The following code sample shows how to compare password-protected documents.

## Compare multiple documents from local disk

```csharp
using (Comparer comparer = new Comparer("source.docx", new LoadOptions() { Password = "1234" }))
{
	comparer.Add("target1.docx", new LoadOptions() { Password = "5678" });
    comparer.Add("target2.docx", new LoadOptions() { Password = "5678" });
    comparer.Add("target3.docx", new LoadOptions() { Password = "5678" });
    comparer.Compare("result.docx");
}
```

## Compare multiple protected documents from stream

```csharp
using (Comparer comparer = new Comparer(File.OpenRead("source.docx"), new LoadOptions() { Password = "1234" }))
{
	comparer.Add(File.OpenRead("target1.docx"), new LoadOptions() { Password = "5678" });
    comparer.Add(File.OpenRead("target2.docx"), new LoadOptions() { Password = "5678" });
    comparer.Add(File.OpenRead("target3.docx"), new LoadOptions() { Password = "5678" });
    comparer.Compare(File.Create("result.docx"));
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
