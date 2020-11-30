---
id: get-extended-information-on-the-summary-page
url: comparison/net/get-extended-information-on-the-summary-page
title: Get extended information on the summary page
weight: 10
description: "This article explains how to get extended information about comparison of documents on the summary page with GroupDocs.Comparison for .NET."
keywords: Compare documents, summary page, SummaryPage, extended information, ExtendedSummaryPage
productName: GroupDocs.Comparison for .NET 

hideChildren: False
---

***

**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows you to detect changes between source and target files and display changes on the separate page - [SummaryPage](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/generatesummarypage).
Аlso you can get extended information about comparison of documents, which will be display in the [SummaryPage](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/generatesummarypage).

The following are the steps to get extended information:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object and set [ExtendedSummaryPage](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/extendedsummarypage) property to *true*;
*   Call [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object from previous step.

The following code sample shows how to get extended information about comparison of documents.

## Example code block to get extended information

---

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
	comparer.Add(targetPath);
	CompareOptions options = new CompareOptions() {ExtendedSummaryPage = true};
    comparer.Compare(resultPath, options);
}
```

## Example of displaying the summary page with extended information

---

![](comparison/net/images/how-to-get-extended-information-image.png)

## More resources

---

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