---
id: load-file-from-local-disk
url: comparison/net/load-file-from-local-disk
title: Load file from local disk
weight: 1
description: "This article explains how to load PDF, Word, Excel, PowerPoint documents from local disk when using GroupDocs.Comparison for .NET."
keywords: Load document from local disk, Load document from file path, Load document with GroupDocs.Comparison
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
When the source file is located on the local disk **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows you to load it via [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) class constructor specifying absolute or relative path to it. For loading target file located on the local disk you should use [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method that accepts absolute or relative path as parameter.  

Following code snippet shows how to load files from local disk.

```csharp
string sourcePath = "source.docx";
using (Comparer comparer = new Comparer(sourcePath))
{
	string targetPath = "target.docx";
    comparer.Add("targetPath");
    comparer.Compare("result.docx");
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