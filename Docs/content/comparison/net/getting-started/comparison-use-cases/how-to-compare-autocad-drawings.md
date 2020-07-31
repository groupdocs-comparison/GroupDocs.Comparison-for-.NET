---
id: how-to-compare-autocad-drawings
url: comparison/net/how-to-compare-autocad-drawings
title: How to Compare AutoCAD drawings
weight: 1
description: "Read this article and find out how you can use the GroupDocs.Comparison for .NET to find differences in AutoCAD files and other drawings. Also, in this article you can find an option to use this product in your production"
keywords: How to compare AutoCAD files, CAD files, Comparison Use Case, Compare AutoCAD files
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
It becomes increasingly difficult to remember what has been changed from one revision to another as your design develops, especially when working in a remotely distributed team. The **DWG Compare** feature by AutoDesk provides a way to perform a visual comparison between two drawings - it identifies objects that have been modified, added, or removed from the two drawings and uses color and revision clouds to show the differences. The result displays in a new drawing called the *comparison drawing*.  

Three colors in the comparison drawing highlight the common objects and the differences. You can specify colors to identify the following:

*   Objects that exist only in the first drawing – <font color="green">**green**</font>, by default
*   Objects that exist only in the second drawing – <font color="red">**red**</font>, by default
*   Objects that are unchanged or common to both drawings – <font color="gray">**gray**</font>, by default

To compare drawings with DWG Compare you should:

1.  Do one of the following to launch the DWG Compare utility: 
    1.  Click **Collaborate** tab > **Compare** panel > **DWG Compare**.
    2.  Click **Application** menu > **Drawing Utilities** > **DWG Compare**.
2.  In the **DWG Compare** dialog box, click **Browse** to select the first drawing file.
3.  Click the color to change the default color settings for the objects that exist only in the first drawing.
4.  Browse to and select the second drawing file that you want to compare with the first drawing.
5.  Click the color to change the default color settings for the objects that exist only in the second drawing.
6.  Click **Compare**. A new drawing opens which contains the comparison results.

## How to Compare AutoCAD drawings using GroupDocs.Comparison

Despite the fact that drawings comparison feature provided by AutoDesk is quite handy and powerful it is obviously doesn't provide a way to compare drawings programatically and manipulate found differences in code. **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provide an easy and convenient API to detect differences between drawings (and many other [supported file formats]({{< ref "comparison/net/getting-started/supported-document-formats.md" >}})) and apply or discard found changes to result document. Here is an example of DWG drawings comparison

|  Source / Target Drawings |
| --- |
|![](comparison/net/images/how-to-compare-autocad-drawings.png) | 
|![](comparison/net/images/how-to-compare-autocad-drawings_1.png)|

Here are the steps to compare two DWG files:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method.

The following code sample demonstrates an approach described above.

```csharp
using (Comparer comparer = new Comparer(@"source.dwg"))
{
    comparer.Add("target.dwg");
    comparer.Compare("result.dwg");
}
```

As a result, we get a DWG file where the deleted elements are marked in <font color="red">**red**</font>, the added – in <font color="blue">**blue**</font>, and the modified – in <font color="green">**green**</font>.

![](comparison/net/images/how-to-compare-autocad-drawings_2.png)

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
