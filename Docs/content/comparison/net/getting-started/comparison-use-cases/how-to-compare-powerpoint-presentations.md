---
id: how-to-compare-powerpoint-presentations
url: comparison/net/how-to-compare-powerpoint-presentations
title: How to Compare PowerPoint Presentations
weight: 4
description: "The article describes a possible example of using the GroupDocs.Comparison for .NET in your work practice and the possibility of a software product for finding differences in styles within PowerPoint Presentations"
keywords: Compare Presentation, compare style changes, compare pptx, How to compare PowerPoint files
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
You may need to compare two versions of a PowerPoint Presentation to see the differences between them (e.g., if a colleague has edited it directly without noting the changes). And the quickest way to do this is with PowerPoint’s built-in Compare function. To use this:

*   Open the original version of your presentation
*   Go to **Review** > **Compare**
*   Click **Compare** to open a browser window
*   Select the edited version of the presentation and click **Merge**

You will then enter Review Mode. This will open the Reviewing Pane, which shows a list of all edits in the presentation at the right of the screen.

![](comparison/net/images/how-to-compare-powerpoint-presentations.png)

## How to Compare Two Presentations using GroupDocs.Comparison

Such functionality that is provided by third-party programs is clearly not enough. **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provides many features for comparing a wide range of [supported file formats]({{< ref "comparison/net/getting-started/supported-document-formats.md" >}}), including PowerPoint Presentation format. Let's make an example, you made a presentation at different times, but the elements on the slides are not located as you originally did. To find where the slides differ, you can compare two files in PPTX format using the **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** functionality along with a built-in option that helps find changes in styles.

|   |  Presentations |
| --- | --- |
|Original | ![](comparison/net/images/how-to-compare-powerpoint-presentations_1.png)|
|Modified | ![](comparison/net/images/how-to-compare-powerpoint-presentations_2.png)|

[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) provides the ability to compare two files in PPTX format(or any other [supported file formats]({{< ref "comparison/net/getting-started/supported-document-formats.md" >}}))

The following are the steps to compare two PPTX files.

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object with desired parameters;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) method and pass [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object to method;

The following code samples demonstrate how to compare two PPTX files.

```csharp
string sourceDocumentPath = @"source_presentation.pptx"; // NOTE: Put here actual path to source document
string targetDocumentPath = @"target_presentation.pptx"; // NOTE: Put here actual path to target document
string outputPath = @"result_presentation.docx"; // NOTE: Put here actual path to result document       
            
using (Comparer comparer = new Comparer(sourceDocumentPath))
{
    comparer.Add(targetDocumentPath);
    CompareOptions compareOptions = new CompareOptions
   {
        DetectStyleChanges = true,
        DetalisationLevel = DetalisationLevel.High
   };
    comparer.Compare(outputPath, compareOptions);
}
```

As a result, we get a PPTX file where the deleted elements are marked in <font color="red">**red**</font>, the added – in <font color="blue">**blue**</font>, and the modified – in <font color="green">**green**</font>

| Result Slide |
| --- |
| ![](comparison/net/images/how-to-compare-powerpoint-presentations_3.png)) 

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
