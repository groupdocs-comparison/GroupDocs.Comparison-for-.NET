---
id: compare-multiple-documents-with-specific-compare-settings
url: comparison/net/compare-multiple-documents-with-specific-compare-settings
title: Compare multiple documents with specific compare settings
weight: 2
description: "Following this guide you will learn how to compare multiple documents with different customisations - style detection, change comparison detalisation level and more."
keywords: Compare multiple documents, style change detection, Multi-compare files
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}NOTE: This feature available only for Microsoft Word documents, Microsoft PowerPoint and Open Document presentations.{{< /alert >}}

[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to compare more that 2 documents and specify some specific comparison options like styling for detected changes, comparison detalisation level etc.

The following are the steps to compare multiple documents with specific options.

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream. Repeat this step for every target document;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object and specify desired options;
*   Call [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object from previous step.

The following code sample shows how to compare multiple documents with specific options.

## Compare multiple documents with specific compare settings from local disk

```csharp
using (Comparer comparer = new Comparer("source.docx")
{
	comparer.Add("target1.docx");
    comparer.Add("target2.docx");
    comparer.Add("target3.docx");
	CompareOptions compareOptions = new CompareOptions()
    {
    	InsertedItemStyle = new StyleSettings()
        {
        	FontColor = System.Drawing.Color.Yellow
        }
    };
    comparer.Compare("result.docx", compareOptions);
}
```

## Compare multiple documents with specific compare settings from stream

```csharp
using (Comparer comparer = new Comparer(File.OpenRead("source.docx"))
{
	comparer.Add(File.OpenRead("target1.docx"));
    comparer.Add(File.OpenRead("target2.docx"));
    comparer.Add(File.OpenRead("target3.docx"));
    CompareOptions compareOptions = new CompareOptions()
    {
    	InsertedItemStyle = new StyleSettings()
        {
        	FontColor = System.Drawing.Color.Yellow
        }
    };
    comparer.Compare(File.Create("result.docx"), compareOptions);
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
