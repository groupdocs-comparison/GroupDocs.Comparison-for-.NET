---
id: set-password-for-resultant-document
url: comparison/net/set-password-for-resultant-document
title: Set password for resultant document
weight: 2
description: "This article explains how to set document password after files comparison within your .NET applications using GroupDocs.Comparison for .NET."
keywords: Compare document and protect with password
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
**[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows to protect resultant document with password.

The following are the steps to protect resultant document:

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Instantiate [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions) object with [PasswordSaveOption](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions/properties/passwordsaveoption) = [PasswordSaveOption](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/passwordsaveoption).User;
*   Instantiate [SaveOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/saveoptions) object and set to [Password](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/saveoptions/properties/password) property desired password for resultant document;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method and pass [SaveOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/saveoptions) and [CompareOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/compareoptions)  objects to a method.

The following code snippet demonstrates how to compare documents and protect resultant document with password.

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    CompareOptions cOptions = new CompareOptions
    {
     	PasswordSaveOption = PasswordSaveOption.User
    };
    SaveOptions sOptions = new SaveOptions()
    {
     	Password = "3333"
    };
    comparer.Compare("result.docx", sOptions, cOptions);
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
