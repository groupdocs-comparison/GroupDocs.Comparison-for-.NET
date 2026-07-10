# GitHub Copilot instructions — GroupDocs.Comparison for .NET

This repository holds the official C# examples for **GroupDocs.Comparison for .NET**, the on-premise document comparison SDK.

GroupDocs.Comparison for .NET is a document comparison API that programmatically compares 50+ document formats (Word, PDF, Excel, PowerPoint and more), detects changes, and produces a result document with highlighted differences.

## Install

```powershell
Install-Package GroupDocs.Comparison
```

NuGet package: `GroupDocs.Comparison` (examples reference version 26.5.0).

## Minimal working example

Compare two documents and save the result (from `Examples/GroupDocs.Comparison.Examples.CSharp/QuickStart/HelloWorld.cs`):

```csharp
using System;
using System.IO;
using GroupDocs.Comparison;

using (Comparer comparer = new Comparer("source.docx"))
{
    comparer.Add("target.docx");
    comparer.Compare(Path.Combine("output", "result.docx"));
}
```

- `Comparer` — main class; constructor takes the source document path (or stream).
- `comparer.Add(target)` — adds the target document to compare against.
- `comparer.Compare(outputPath)` — runs the comparison and writes the result document.

Set a license before comparing (optional; trial mode otherwise):

```csharp
License license = new License();
license.SetLicense("path/to/GroupDocs.Comparison.lic");
```

## Common pitfalls

- The `GroupDocs.Comparison` 26.5.0 package ships assemblies for `net10.0`, `net8.0`, `net6.0`, and `net462`; the modern example project targets `net10.0`.
- The result document format follows the source format — give the output path a matching extension.
- Without a license, output is watermarked and page count is limited. Free temporary license: https://purchase.groupdocs.com/temporary-license/

## SDK, not Cloud or MCP

- This is the **local/on-premise SDK** (`GroupDocs.Comparison` NuGet package) — documents are processed locally.
- **GroupDocs.Comparison Cloud** is a separate REST API product with different SDK packages — do not mix its classes with this SDK.
- The **MCP server** is a separate project: https://github.com/groupdocs-comparison/GroupDocs.Comparison.Mcp

## Links

- Docs: https://docs.groupdocs.com/comparison/net/
- API reference: https://reference.groupdocs.com/comparison/net/
- Supported formats: https://docs.groupdocs.com/comparison/net/supported-document-formats/
