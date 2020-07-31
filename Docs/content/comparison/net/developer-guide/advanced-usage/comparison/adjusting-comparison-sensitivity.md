---
id: adjusting-comparison-sensitivity
url: comparison/net/adjusting-comparison-sensitivity
title: Adjusting comparison sensitivity
weight: 2
description: "Learn more about document comparison sensitivity and how to adjust it to achieve best performance and accuracy when compare documents with GroupDocs.Comparison for .NET."
keywords: Comparison sensitivity, comparison detalisation level, compare documents, file comparison
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to adjust comparison sensitivity to achieve the necessary balance between document comparison speed and accuracy. Possible comparison sensitivity values range is from **0** to **100**.  

*   **Minimal value** - the minimal value is **0**. Setting sensitivity to a minimal value provides the fastest comparison speed, but it may produce worst comparison quality.   
    If there is at least one common letter in two compared words then these words will not be treated as fully inserted and deleted
*   **Value by default**  - the default value is **75**. Comparison occurs when the percentage of deleted or inserted elements in relation to all elements does not exceed 75%.
*   **Maximum value** - the maximum values is **100**. Comparison occurs at any length of a common sub-sequence of two compared objects. This option provides the best quality, but slowest comparison speed.

For better understanding about how comparison algorithms work let's suppose we have two strings:

| Strings |
| --- |
| `1``. It is our equity poetry` |
| `2``. Jack is a glad calf` |

We will highlight removed text parts with <font color="red">**red**</font> and inserted parts with <font color="blue">**blue**</font> color. So, these strings have two common sub-sequences: "**is**" word and 4 space symbols.   
**  
Common sub-sequence is - " **is**   " and its length is 6 symbols (there are 4 space symbols in it).  
Length of inserted sub-sequence is 13 symbols - **Jackagladcalf**  
Removed sub-sequence length is 17 symbols - **Itourequitypoetry**  
Lets calculate percent of removed and inserted symbols: (17 + 13) / (17 + 13 + 6) * 100 = 83%

*Case 1.* If **SensitivityOfComparison = 80%** comparison of these two strings will produce the next result:  
**Jack is a glad calfIt is our equity poetry**

Because calculated percent of removed and inserted symbols equals **83%** and it is bigger than value of **SensitivityOfComparison** equals **80%** then this common sub-sequence will be not taken into account.  
The first string considered completely removed and the second string considered completely inserted. The same results will be produced for any calculated percent less than **83%**.

*Case 2.* If **SensitivityOfComparison = 85%**, comparison of these two strings will produce the next result:  
**JackIt is aour gladequity calfpoetry**

Common sub-sequence was found, because **85% > 83%**. The same results will be produced for any calculated percent bigger than **83%**.

  
Here are the steps to compare documents with specific comparison sensitivity:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object with desired [SensitivityOfComparison](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions/properties/sensitivityofcomparison) value;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.comparer/compare/methods/1) method and pass [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object to method.

The following code snippet demonstrates how compare documents with specific sensitivity:

## Compare documents with sensitivity adjustment

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    CompareOptions options = new CompareOptions() { SensitivityOfComparison = 100 };
	comparer.Compare("result.docx", options);
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