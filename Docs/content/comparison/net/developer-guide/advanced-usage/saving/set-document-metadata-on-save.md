---
id: set-document-metadata-on-save
url: comparison/net/set-document-metadata-on-save
title: Set document metadata on save
weight: 1
description: "Follow this guide and learn how to set document metadata when saving resultant document after files comparison within your .NET applications."
keywords: Save document metadata,  Compare documents, Document comparison, File diff
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
Usually documents can contain some metadata information, such as author, organization, etc. [**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) provides an ability to select metadata source when saving resultant document.  
Possible metadata sources are:

*   **Source** document metadata;
*   **Target** document metadata;
*   **User-defined** metadata.

The following are the steps to set resultant document metadata.

*   Instantiate [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object with source document path or stream;
*   Call [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method and specify target document path or stream;
*   Instantiate [SaveOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/saveoptions) object and set [CloneMetadataType](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/saveoptions/properties/clonemetadatatype) property with desired [MetadataType](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/metadatatype) variant;
*   Call [Compare](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/compare/index) method and pass [SaveOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/saveoptions) object to method.

The following code demonstrates how to set resultant document metadata.

## Set metadata from source file

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare("result.docx", new SaveOptions() { CloneMetadataType = MetadataType.Source });
}
```

## Set metadata from target file

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare("result.docx", new SaveOptions() { CloneMetadataType = MetadataType.Target });
}
```

## Set user-defined metadata 

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    SaveOptions saveOptions = new SaveOptions()
    {
    	CloneMetadataType = MetadataType.FileAuthor,
        FileAuthorMetadata = new FileAuthorMetadata
        {
        	Author = "Tom",
            Company = "GroupDocs",
            LastSaveBy = "Jack"
        }
    };
    comparer.Compare("result.docx", saveOptions);
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
