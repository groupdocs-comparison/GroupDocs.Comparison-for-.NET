---
id: how-to-compare-price-lists
url: comparison/net/how-to-compare-price-lists
title: How to Compare Price Lists
weight: 5
description: "This article describes how to compare files using Microsoft Excel feature and GroupDocs.Comparison API for .NET. You will also learn how to compare two or more tables and get the difference in files"
keywords: Compare Excel files, compare spreedsheet, how to compare Excel files
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
Let's say you have two Excel workbooks, or maybe two versions of the same workbook, that you want to compare. Or maybe you want to find potential problems, like manually-entered (instead of calculated) totals, or broken formulas. If you have Microsoft Office Professional Plus 2013, you can use Microsoft Spreadsheet Compare to run a report on the differences and problems it finds.

{{< alert style="info" >}}Important:  Spreadsheet Compare is only available with Office Professional Plus 2013 or Office 365 ProPlus.{{< /alert >}}

To compare two Excel workbooks with Office Professional Plus 2013 you should:

*   Click **Home > Compare Files**. The Compare Files dialog box appears.  
![](comparison/net/images/how-to-compare-price-lists.jpg)
*   Click the blue folder icon next to the **Compare** box to browse to the location of the earlier version of your workbook.  
      
![](comparison/net/images/how-to-compare-price-lists_1.jpg)
      
    
*   Click the green folder icon next to the **To** box to browse to the location of the workbook that you want to compare to the earlier version, and then click **OK**.
*   In the left pane, choose the options you want to see in the results of the workbook comparison by checking or unchecking the options, such as **Formulas**, **Macros**, or **Cell Format**. Or, just **Select All**.  
      
![](comparison/net/images/how-to-compare-price-lists_2.png)
*   Click **OK** to run the comparison.

## How to compare Excel files using GroupDocs.Comparison

Microsoft Office Professional Plus 2013 offers spreadsheet comparisons, but **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provides a possibility to compare worksheet programmatically and you can compare not only two different files, but several at once. Let's say, there are three or more price list for few years (For example: "2018", "2019", "2020") in the XLSX format or other [supported file formats]({{< ref "comparison/net/getting-started/supported-document-formats.md" >}}). other and you need to compare their contents. Here is an example of how to compare three price lists using GroupDocs.Comparsion API. Usually you just have to follow these steps:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream. Repeat this step for every target document;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method.  
      
    

|   | Files |
| --- | --- |
| Price List for 2018 | ![](comparison/net/images/how-to-compare-price-lists_3.png) |
| Price List for 2019 | ![](comparison/net/images/how-to-compare-price-lists_4.png) |
| Price List for 2020 | ![](comparison/net/images/how-to-compare-price-lists_5.png) |

Here is the code that is used to compare three price lists.

```csharp
string sourceDocumentPath = @"Source Price List.xlsx"; // NOTE: Put here actual path to source document
string targetOneDocumentPath = @"Target Price List 1.xlsx"; // NOTE: Put here actual path to target one document
string targetTwoDocumentPath = @"Target Price List 2.xlsx"; // NOTE: Put here actual path to target two document
string outputPath = @"Result Price List.xlsx"; // NOTE: Put here actual path to result document
             
using (Comparer comparer = new Comparer(sourceDocumentPath))
{
     comparer.Add(targetOneDocumentPath);
     comparer.Add(targetTwoDocumentPath);
     comparer.Compare(outputPath);
}
```

As a result, we get a XSLX file where the deleted elements are marked in <font color="red">**red**</font>, the added – in <font color="blue">**blue**</font>, and the modified – in <font color="green">**green**</font>


| Result Price List |
| --- |
| ![](comparison/net/images/how-to-compare-price-lists_6.png) | 

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
