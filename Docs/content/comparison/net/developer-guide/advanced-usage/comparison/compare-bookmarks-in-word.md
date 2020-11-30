---
id: compare-bookmarks-in-word
url: comparison/net/compare-bookmarks-in-word
title: Compare bookmarks in Word documents
weight: 12
description: "This article explains how to activate the comparison of bookmarks for Word format in GroupDocs.Comparison for .NET."
keywords: bookmarks, Word, word, docx, doc, compare bookmarks, word bookmarks, CompareBookmarks, bookmarks comparison
productName: GroupDocs.Comparison for .NET
hideChildren: False
---

***

**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows to compare bookmarks in WORD documents.

The following are the steps to compare bookmarks of documents:

*   Instantiate [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) object with source file path or stream;
*   Call [Add](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer/methods/add/index) method and specify target file path or stream;
*   Instantiate the [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object and initialize the [CompareBookmarks](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparebookmarks) property with **true**;
*   Call [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object from previous step.

## Example code block to demonstrate how to compare bookmarks

---

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
     
    comparer.Compare(resultPath, new CompareOptions {
        CompareBookmarks = true
    });
}
```

## The result after comparing document with enabled CompareBookmarks option

---

The result of compared bookmarks is presented as inserted comments with description in document. See example below on image:

![](comparison/net/images/compared-bookmarks.png)

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