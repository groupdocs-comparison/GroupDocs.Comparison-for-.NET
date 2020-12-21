---
id: show-revisions
url: comparison/net/show-revisions
title: Show Revisions
weight: 12
description: "This article explains how to customize the display of revisions in the resulting document in GroupDocs.Comparison for .NET."
keywords: ShowRevisions, revision
productName: GroupDocs.Comparison for .NET
hideChildren: False
---

***

**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provides the ability to compare and customize the display of revisions in the resulting document.

**Revision** - changes received when comparing documents using built-in Word tools.

By default, the display of revisions is *enabled*. Below are the steps to turn off the display of revisions:

*   Instantiate [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) object with source file path or stream;
*   Call [Add](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer/methods/add/index) method and specify target file path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object and set [ShowRevisions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showrevisions) property to *false*;
*   Call [Comparer](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) object from previous step.

## Example code block to disable the display of revisions

---

```csharp
using (Comparer comparer = new Comparer(sourcePath))
{
    comparer.Add(targetPath);
    CompareOptions options = new CompareOptions() {ShowRevisions = false};
    comparer.Compare(resultPath, options);
}
```

## Example of a result with the Revision display enabled

---

| Closed state | Open state |
|:---:|:---:|
| ![](comparison/net/images/show-revisions-true-close-revisions.png) | ![](comparison/net/images/show-revisions-true-open-revisions.png) |

## Example of a result with the Revision display disabled

---

| Disable display Revisions |
|:---:|
| ![](comparison/net/images/show-revisions-false.png) |

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