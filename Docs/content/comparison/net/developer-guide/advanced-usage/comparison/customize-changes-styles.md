---
id: customize-changes-styles
url: comparison/net/customize-changes-styles
title: Customize changes styles
weight: 4
description: "Following this guide you will learn how to customize document comparison report and modify appearance of detected changes when use GroupDocs.Comparison for .NET."
keywords: Style change detection, Compare document styles, Document comparison
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) provides compare options set with some default values that provides both - appropriate comparison speed and quality. However it is possible to customize comparison options from wide range of parameters and their values to fulfill some specific needs. Example below demonstrates how to change different changes types styling.

The following are the steps to compare two documents with custom change style settings:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object with desired parameters;
*   Call Compare method and pass [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object to method.

The following code snippet demonstrates how to compare documents with specific options.

## Compare documents from local disk with custom change styles

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
	CompareOptions compareOptions = new CompareOptions()
	{
    	InsertedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Red,
            FontColor = System.Drawing.Color.Green,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        },
		DeletedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Azure,
            FontColor = System.Drawing.Color.Brown,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        },
		ChangedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Crimson,
            FontColor = System.Drawing.Color.Firebrick,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        }
	};
comparer.Compare("result.docx", compareOptions);
}
```

## Compare documents from stream with custom change styles

```csharp
using (Comparer comparer = new Comparer(File.OpenRead("source.docx")))
{
	comparer.Add(File.OpenRead("target.docx"));
	CompareOptions compareOptions = new CompareOptions()
	{
    	InsertedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Red,
            FontColor = System.Drawing.Color.Green,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        },
		DeletedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Azure,
            FontColor = System.Drawing.Color.Brown,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        },
		ChangedItemStyle = new StyleSettings()
        {
        	HighlightColor = System.Drawing.Color.Crimson,
            FontColor = System.Drawing.Color.Firebrick,
            IsUnderline = true,
			IsBold = true,
			IsStrikethrough = true,
			IsItalic = true
        }
	};
comparer.Compare(File.Create("result.docx"), compareOptions);
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