---
id: how-to-compare-source-code-files
url: comparison/net/how-to-compare-source-code-files
title: How to compare Source Code Files
weight: 6
description: "This article describes how to compare files using GroupDocs.Comparison for .NET. You will also learn how to compare two or more Source Code files and how to influence their comparison."
keywords: Compare Source Code files, Source Code files, how to compare Source Code files files, ComparisonAction,  ComparisonAction.Accept, ComparisonAction.Reject
productName: GroupDocs.Comparison for .NET
hideChildren: False
---

***

There are plenty of comparison tools that allow multiple users to effectively manage, accept or reject their changes when collaborate over source code written in CSharp, Java, Python, Ruby and other programming languages. Most part of such tools are desktop applications that are free or paid, provide powerful set of features, have their pros and cons, but all of them assume you will compare files manually.

Let's review some common use case when you need to review two versions of C# (CSharp) source code file edited by two different people and chose the proper variant for each edited code block. Please check source.cs and target.cs files that we are going to compare at the image below.

![](comparison/net/images/how-to-compare-source-code-files1.png)

As we can see there are multiple differences between compared files:
*   class names are different - *CropImage* vs *ImageCropTests*;
*   *Test1* method is not present in a *target.cs* file;
*   Bitmap image path was changed in *Test2* - *input.png* vs *original.png*;
*   *Start* method was renamed to *Launch* and its content was also modified - *Test1* method call removed;
*   some empty lines removed etc.

The image below demonstrates all mentioned changes detected by some of desktop comparison tools. It works just fine, all differences detected and highlighted in a user interface.

![](comparison/net/images/how-to-compare-source-code-files2.png)

However sometimes you may need some features that existing comparison tools do not provide, or you want to implement comparison process in your own way. Then you will definitely need a possibility to compare documents programmatically and manage discovered changes via code. This is where **[GroupDocs.Comparsion](https://products.groupdocs.com/comparison/net)** features will come to the rescue, so lets see how to compare source code files with it. 

## Compare CSharp, Java, C++, JavaScript, Python and Ruby files using GroupDocs.Comparison
 
 ---

Using **[GroupDocs.Comparsion](https://products.groupdocs.com/comparison/net)** API you are able to compare two or more source code files, detect differences between them and then decide what to do with every detected change - accept or discard it before saving the resultant document, generate HTML report with comparison results etc.

In general you have to follow these steps to compare two source code files (please find other supported formats list [here](https://wiki.lisbon.dynabic.com/display/comparison/Supported+File+Formats)):

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify path target document path or stream;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) method and perform file comparison.







At this stage you is able to save comparison report in HTML form and review it. If you need to programmatically obtain collection of detected changes for further processing you have to:

*   Call [GetChanges](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/getchanges/index) method and obtain detected changes list;
*   Set desired [ComparisonAction](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/changeinfo/properties/comparisonaction) for needed change object to [ComparisonAction.Accept](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/comparisonaction) or [ComparisonAction.Reject](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.result/comparisonaction) value;
*   Instantiate [ApplyChangeOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/applychangeoptions) object that contains list of changes to be applied (or rejects) to the resultant document;
*   Call [ApplyChanges](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/applychanges/index) method and save the document.

You can learn more about the ComparisonAction property [here](https://wiki.lisbon.dynabic.com/display/comparison/How+to+merge+source+code+files).

The following code samples demonstrate how to compare two CS files and accept or reject detected changes in a specific range.

```csharp
using (Comparer comparer = new Comparer("source.cs"))
{
    comparer.Add("target.cs");
    comparer.Compare();
    ChangeInfo[] changes = comparer.GetChanges();
    changes[0].ComparisonAction = ComparisonAction.Reject; // This is how to reject first detected difference;
    changes[1].ComparisonAction = ComparisonAction.Reject; // This is how to reject second detected difference;
    changes[2].ComparisonAction = ComparisonAction.Reject; // This is how to reject third detected difference;
    comparer.ApplyChanges(File.Create("result.cs"), new ApplyChangeOptions { Changes = changes });
}     
```

As a result, we get a merged CS file where the deleted elements are marked in <font color="red">red</font>, the added – in <font color="blue">blue</font>, and the modified – in <font color="green">green</font>. 

Also, you will receive a file in HTML format with changed places in the code.

|  The result HTML file | The result HTML file using the ComparisonAction property |
| --- | --- |
| ![](comparison/net/images/how-to-compare-source-code-files_result1.PNG) | ![](comparison/net/images/how-to-compare-source-code-files_result2.PNG) |

## More resources

---

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
