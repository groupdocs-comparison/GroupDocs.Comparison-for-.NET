---
id: get-supported-document-formats
url: comparison/net/get-supported-document-formats
title: Get supported file formats
weight: 1
description: "This article explains how to obtain supported file formats list when viewing documents with GroupDocs.Comparison within your .NET applications."
keywords: Get file info, Get File Type, Page count, File size
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows to get the list of all [supported file formats]({{< ref "comparison/net/getting-started/supported-document-formats.md" >}}) by following the below steps:

*   Call [GetSupportedFileTypes](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.result/filetype/methods/getsupportedfiletypes) of [FileType](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.result/filetype) class;
*   Enumerate through the collection of [FileType](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.result/filetype) objects.

The following code sample demonstrates how to get supported file formats list.

```csharp
IEnumerable<FileType> supportedFileTypes = FileType
	.GetSupportedFileTypes()
	.OrderBy(f => f.Extension);

foreach (FileType fileType in supportedFileTypes)
	Console.WriteLine(fileType);
```

## More resources
### Advanced Usage Topics
To learn more about document comparison features, please refer to the [advanced usage section]({{< ref "comparison/net/developer-guide/advanced-usage/_index.md" >}}).

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
