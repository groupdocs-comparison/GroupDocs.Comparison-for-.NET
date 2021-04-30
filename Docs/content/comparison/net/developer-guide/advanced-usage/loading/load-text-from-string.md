---
id: load-text-from-string
url: comparison/net/load-text-from-string
title: Load text from string
weight: 5
description: "This article explains how to load values from variables of string type when using GroupDocs.Comparison for .NET."
keywords: Load values from variables of string type, Load text with GroupDocs.Comparison
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to compare values from variables of *string* type.
The following are the steps to compare text from variables:

*   Instantiate [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) object and set [LoadText](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/loadoptions/properties/loadtext) property to *true* (this indicates that passed string contains text to be compared, not file path);
*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) *object* with source variable of *string* type and [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) *object* created at previous step;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target variable of *string* type and [LoadOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/loadoptions) *object* created at previous step;
*   Call [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) method.
*   Call [GetResultString](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer/methods/getresultstring) method to get string with comparison result.

The following code snippet shows how to load values from variables:
```csharp
using (Comparer compare = new Comparer("source text", new LoadOptions() { LoadText = true }))
{
    compare.Add("target text", new LoadOptions() { LoadText = true });
    compare.Compare();
    string result = compare.GetResultString();
}
```
---

Can also be combined with different ways of passing documents (be it file path or stream), as shown in the following code example:
```csharp
using (Stream sourceStream = File.OpenRead("./source.docx"))
{
    using (Comparer compare = new Comparer(sourceStream))
    {
        compare.Add("target text", new LoadOptions() { LoadText = true });
        compare.Compare();
        string result = compare.GetResultString();
        Console.WriteLine(result);
    }
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
