---
id: compare-of-variables-and-document-properties
url: comparison/net/compare-of-variables-and-document-properties
title: Compare of Variables and Document properties
weight: 11
description: "This article explains how to activate the comparison of document properties in GroupDocs.Comparison for .NET."
keywords: variables properties, built properties, custom properties, compare document properties, CompareVariableProperty, CompareDocumentProperty
productName: GroupDocs.Comparison for .NET
hideChildren: False
---

***

**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows you to compare various properties of a WORD document such as *Variable*, *Built*, and *Custom* properties.

The following fields of the CompareOptions class are used to enable comparison functions for document properties:

*   [CompareVariableProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparevariableproperty) - to activate the comparison of *variable* properties;
*   [CompareDocumentProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparedocumentproperty) - to activate the comparison of *built* and *custom* properties.

Following are the steps to activate compare document properties:

*   Instantiate [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) object with source file path or stream;
*   Call [Add](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer/methods/add/index) method and specify target file path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object and set [CompareVariableProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparevariableproperty) property to *true* ([CompareDocumentProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparedocumentproperty) to *true* for *built* and *custom* properties);
*   Call [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object from previous step.

## Example code block to activate comparison of Variable, Built and Custom properties

---

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
    CompareOptions options = new CompareOptions();
    options.CompareVariableProperty = true; // to activate the comparison of variable properties
    options.CompareDocumentProperty = true; // to activate the comparison of built and custom properties
     
    comparer.Compare(resultPath, options);
}
```

## The result of comparing properties

---

The result of comparing properties is presented on a separate page - *Properties summary page*.

![](comparison/net/images/properties-summary-page.png)

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