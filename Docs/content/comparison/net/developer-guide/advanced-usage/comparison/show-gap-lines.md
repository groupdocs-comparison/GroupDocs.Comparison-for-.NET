---
id: show-gap-lines
url: comparison/net/show-gap-lines
title: Show gap lines instead of changes
weight: 13
description: "This article explains how to adjust the display of the resulting document so that the changed content is replaced with empty lines in GroupDocs.Comparison for .NET."
keywords: LeaveGaps, gap lines, empty lines
productName: GroupDocs.Comparison for .NET
hideChildren: False
---

***

**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows adjusting formation of the resulting document.

By default, changes from the two input files (*source* and *target* files) are added to the resulting document and visually highlighted. This can be configured using the [ShowInsertedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showinsertedcontent) and [ShowDeletedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showdeletedcontent) properties.

You can also use the [LeaveGaps](https://apireference.groupdocs.com/error/404?path=comparison/net/groupdocs.comparison.options/compareoptions/properties/leavegaps) property to adjust the display of the resulting document, which allows to replace changed content with empty lines. To use this property, you also need to activate the following properties: [ShowInsertedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showinsertedcontent) and [ShowDeletedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showdeletedcontent).

Here are the simple steps to get the above result:

*   Instantiate [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) object with source file path or stream;
*   Call [Add](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer/methods/add/index) method and specify target file path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object sets [ShowInsertedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showinsertedcontent) and/or [ShowDeletedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showdeletedcontent) and necessarily [LeaveGaps](https://apireference.groupdocs.com/error/404?path=comparison/net/groupdocs.comparison.options/compareoptions/properties/leavegaps) properties;
*   Call [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object from previous step.

## Example code block to get the desired result

---

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
 
    CompareOptions options = new CompareOptions();
    options.ShowInsertedContent = false;
    options.ShowDeletedContent = false;
    options.LeaveGaps = true;
      
    comparer.Compare(resultPath, options);
}
```

## Example code execution

---

| Default result | Result without LeaveGaps property |
|:---:|:---:|
| ![](comparison/net/images/show-gap-lines-default-result.png) | ![](comparison/net/images/show-gap-lines-without-leavegaps.png) |

| Default result | Result with LeaveGaps property |
|:---:|:---:|
| ![](comparison/net/images/show-gap-lines-default-result.png) | ![](comparison/net/images/show-gap-lines-with-leavegaps.png) |

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