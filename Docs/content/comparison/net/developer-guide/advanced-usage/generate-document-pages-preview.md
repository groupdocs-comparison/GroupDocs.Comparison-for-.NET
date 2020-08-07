---
id: generate-document-pages-preview
url: comparison/net/generate-document-pages-preview
title: Generate document pages preview
weight: 4
description: "Following this guide you will learn how to generate PDF, Word, Excel, PowerPoint documents thumbnails and preview document pages using GroupDocs.Comparison for .NET API."
keywords: Document preview, Preview document pages, Document pages as PNG, document pages as JPG
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) allows to generate page previews for source, target and resultant document(s) using [GeneratePreview](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/document/methods/generatepreview) method of a [Document](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/document) class.

[PreviewOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions) class is used to manage preview generation process - specify desired page numbers, image format etc.

The following are the steps to generate document preview with GroupDocs.Comparison API:
*   Create new instance of [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) class and pass source document path as a constructor parameter;
*   Add target document(s) to comparison using [Add](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/methods/add/index) method;
*   [Source](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/properties/source) and [Targets](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/properties/targets) properties of [Comparer](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer) object allows to access source and target documents and provides [GeneratePreview](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/document/methods/generatepreview) method;
*   Instantiate the [PreviewOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions) object with:
    *   delegate for each page stream creation (see event handler CreatePageStream);
    *   image preview format - PNG / JPG / BMP;
    *   page numbers to process;
    *   custom size of preview images (if needed).
    {{< alert style="info" >}}Stream that were created by [CreatePageStream](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/fields/createpagestream) delegate will be disposed automatically once after generation of preview image. If you need to implement custom image preview stream disposing you have to pass additional argument [ReleasePageStream](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/fields/releasepagestream) to clean up resources.{{< /alert >}}
*   Call [GeneratePreview](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/document/methods/generatepreview) method of [Source](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/properties/source) and [Targets](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison/comparer/properties/targets)document and pass [PreviewOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions) to it.

Here a [PreviewOptions](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions) class main properties:
*   [CreatePageStream](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/fields/createpagestream) - Delegate which defines method to create output page preview stream;
*   [ReleasePageStream](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/fields/releasepagestream) - Delegate which defines method to remove output page preview stream. This is can be used when need advanced control for resources handling.
*   [Width](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/properties/width) - Preview image width. This property used when need customize output image width;
*   [Height](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/properties/height) - Preview image height. This property used when need customize output image height;
*   [PageNumbers](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/properties/pagenumbers) - Page numbers that will be previewed;
*   [PreviewFormat](https://apireference.groupdocs.com/net/comparison/groupdocs.comparison.options/previewoptions/properties/previewformat) - Gets or sets the preview image format which provides ability to choose between image quality and size. **BMP** format should be used for the best image quality. **JPG** format will be useful in case of strict requirements to image size - it produces smallest image size (and faster loading image previews), but with lower quality than **BMP**. By default **PNG** format is selected - which is a golden mean between image quality and size.

The following code snippet demonstrates how to generate document previews.

## Get page previews for source document

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
    PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
    {
    	var pagePath = Path.Combine("C:\", $"result_{pageNumber}.png");
        return File.Create(pagePath);
    });
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    previewOptions.PageNumbers = new int[] { 1, 2 };
    comparer.Source.GeneratePreview(previewOptions);
}

```

## Get page previews for target document

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
    {
    	var pagePath = Path.Combine("C:\", $"result_{pageNumber}.png");
        return File.Create(pagePath);
    });
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    previewOptions.PageNumbers = new int[] { 1, 2 };
    comparer.Targets[0].GeneratePreview(previewOptions);
}
```

## Get page previews for resultant document

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare("result.docx");
    Document document = new Document(File.OpenRead("result.docx"));
    PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
    {
    	var pagePath = Path.Combine("C:\", $"result_{pageNumber}.png");
        return File.Create(pagePath);
    });
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    previewOptions.PageNumbers = new int[] { 1, 2 };
    document.GeneratePreview(previewOptions);
}
```

## Set specific size for preview images

In some cases it may be useful to set specific image size during document pages preview generation. For example, to generate document pages thumbnails - small images that is a compressed preview image of the original image that is used as a placeholder. The main advantage of such thumbnail images is their reduced file size compared to the original page image.

The following code snippet demonstrates how to set specific size for preview images.

```csharp
using (Comparer comparer = new Comparer("source.pptx"))
{
	comparer.Add("target.pptx");
    comparer.Compare("result.pptx");
    Document document = new Document(File.OpenRead("result.pptx"));
    PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
    {
    	var pagePath = Path.Combine("C:\", $"result_{pageNumber}.png");
        return File.Create(pagePath);
    });
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    previewOptions.PageNumbers = new int[] { 1, 2 };
    previewOptions.Height = 1000;
    previewOptions.Width = 1000;
    document.GeneratePreview(previewOptions);
}
```

{{< alert style="info" >}}NOTE: This feature is not supported for WordProcessing documents yet.{{< /alert >}}

## Get page previews with manual resource cleaning

By default, after generating and rendering document page preview  image stream will be immediately disposed. However there is an ability to implement custom method for handling this operation.

```csharp
// Method should match with ReleasePageStream delegate signature
private void UserReleaseStreamMethod(int pageNumber, Stream stream)
{
	Console.WriteLine($"Releasing memory for page: {pageNumber}");
    stream.Close();
}
 
using (Comparer comparer = new Comparer("source.docx"))
{
	comparer.Add("target.docx");
    comparer.Compare("result.docx");
    Document document = new Document(File.OpenRead("result.docx"));
    PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
    {
    	var pagePath = Path.Combine("C:\", $"result_{pageNumber}.png");
        return File.Create(pagePath);
    });
    previewOptions.PreviewFormat = PreviewFormats.PNG;
    previewOptions.PageNumbers = new int[] { 1, 2 };
    // here we set delegate target method
    previewOptions.ReleasePageStream = UserReleaseStreamMethod;
    document.GeneratePreview(previewOptions);
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
