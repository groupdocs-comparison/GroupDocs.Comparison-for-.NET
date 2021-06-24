# .NET Document Comparison API

On-premise library to [compare documents](https://products.groupdocs.com/comparison/net) in applications based on .NET platform. Retrieve list of changes in desired format with line-by-line comparison of content, paragraphs, characters, styles, shapes and position.

<p align="center">
  <a title="Download complete GroupDocs.Comparison for .NET source code" href="https://codeload.github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/zip/master">
	<img src="https://raw.github.com/AsposeExamples/java-examples-dashboard/master/images/downloadZip-Button-Large.png" />
  </a>
</p>

Directory | Description
--------- | -----------
[Demos](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/tree/master/Demos)  | Contains demo projects that demonstrate product features.
[Examples](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/tree/master/Examples)  | C# based source code examples and sample files to quickly get started.
[Showcases](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/tree/master/Showcases)  | Frontend examples to helps in implementing different product features in a Web-UI based application.
[Plugins](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/tree/master/Plugins)  | Visual Studio Plugins which will download examples and GroupDocs.Comparison Library without any efforts.

## Document Comparison Features

- [Compare and detect differences](https://docs.groupdocs.com/comparison/net/compare-documents/) among similar documents.
- Support for [55+ popular document formats](https://docs.groupdocs.com/comparison/net/supported-document-formats/) from various categories.
- Visual separation of detected changes with the ability to [accept or reject modifications](https://docs.groupdocs.com/comparison/net/accept-or-reject-detected-changes/).
- [Generate document preview](https://docs.groupdocs.com/comparison/net/generate-document-pages-preview/).
- Compare paragraph, word as well as the characters.
- Identify content styling and formatting changes.
- Set metadata from the source, target files or keep it user-defined.
- Make the resultant document password protected.

## Supported Microsoft Office Formats

**Microsoft Word:** DOC, DOCM, DOCX, DOT, DOTM, DOTX, RTX\
**Microsoft Excel:** XLS, XLT, XLSX, XLTM, XLSB, XLSM, XLSX\
**Microsoft PowerPoint:** POT, POTX, PPS, PPSX, PPTX, PPT\
**Microsoft OneNote:** ONE\
**Microsoft Visio:** VSDX, VSD, VSS, VST, VDX

## Other Supported Formats

**OpenDocument:** ODT, ODP, OTP, ODS, OTT\
**Portable:** PDF\
**AutoCAD:** DWG, DXF\
**Email:** EML, EMLX, MSG\
**Images:** BMP, GIF, JPG, JPEG, PNG, DICOM\
**Web:** HTM, HTML, MHT, MHTML\
**Text:** TXT, CSV\
**eBook:** MOBI, DJVU

## Develop & Deploy GroupDocs.Comparison Anywhere

**Microsoft Windows:** Windows Azure, Microsoft Windows Desktop (x86, x64), Microsoft Windows Server (x86, x64)\
**macOS:** Mac OS X\
**Linux:** Ubuntu, OpenSUSE, CentOS, and others\
**Development Environments:** Microsoft Visual Studio (2010 & up), Xamarin.Android, Xamarin.IOS, Xamarin.Mac, MonoDevelop 2.4 and later\
**Supported Frameworks:** .NET Standard 2.0, .NET Framework 2.0 or higher, .NET Core 2.0 or higher, Mono Framework 1.2 or higher

## Getting Started with GroupDocs.Comparison for .NET

Are you ready to give GroupDocs.Comparison for .NET a try? Simply execute `Install-Package GroupDocs.Comparison` from Package Manager Console in Visual Studio to fetch & reference GroupDocs.Comparison assembly in your project. If you already have GroupDocs.Comparison for .NET and want to upgrade it, please execute `Update-Package GroupDocs.Comparison` to get the latest version.

## Compare Microsoft Word Documents

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
   comparer.Add("target.docx");
   comparer.Compare("result.docx");
}
```

[Home](https://www.groupdocs.com/) | [Product Page](https://products.groupdocs.com/comparison/net) | [Documentation](https://docs.groupdocs.com/comparison/net/) | [Demo](https://products.groupdocs.app/comparison/family) | [API Reference](https://apireference.groupdocs.com/comparison/java) | [Examples](https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET/tree/master/Examples) | [Blog](https://blog.groupdocs.com/category/comparison/) | [Search](https://search.groupdocs.com/) | [Free Support](https://blog.groupdocs.com/category/comparison/) | [Temporary License](https://purchase.groupdocs.com/temporary-license)
