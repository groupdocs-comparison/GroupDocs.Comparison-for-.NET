# AGENTS.md — GroupDocs.Comparison for .NET Examples

## What is this repo

This is the official examples repository for GroupDocs.Comparison for .NET, containing runnable C# sample projects, demo web apps, and Visual Studio plugins.

GroupDocs.Comparison for .NET is a document comparison API that programmatically compares 50+ document formats (Word, PDF, Excel, PowerPoint and more), detects changes, and produces a result document with highlighted differences.

## Install

```powershell
Install-Package GroupDocs.Comparison
```

or with the .NET CLI:

```bash
dotnet add package GroupDocs.Comparison
```

NuGet package: [GroupDocs.Comparison](https://www.nuget.org/packages/GroupDocs.Comparison) (examples in this repo reference version 26.5.0).

## Minimal working example

Compare two documents and save the result with highlighted differences (from `Examples/GroupDocs.Comparison.Examples.CSharp/QuickStart/HelloWorld.cs`):

```csharp
using System;
using System.IO;
using GroupDocs.Comparison;

class Program
{
    static void Main()
    {
        string sourceDocumentPath = "source.docx";
        string targetDocumentPath = "target.docx";
        string outputFileName = Path.Combine("output", "result.docx");

        using (Comparer comparer = new Comparer(sourceDocumentPath))
        {
            comparer.Add(targetDocumentPath);
            comparer.Compare(outputFileName);
        }

        Console.WriteLine($"Documents compared successfully. Check output in {outputFileName}.");
    }
}
```

Key API surface:
- `Comparer` — main class; constructor takes the source document path (or stream).
- `comparer.Add(target)` — adds the target document to compare against.
- `comparer.Compare(outputPath)` — runs the comparison and writes the result document.

## License setup

Without a license the API runs in trial mode (limited pages / watermarks). Set a license before any comparison (from `Examples/GroupDocs.Comparison.Examples.CSharp/QuickStart/SetLicenseFromFile.cs`):

```csharp
using GroupDocs.Comparison;

License license = new License();
license.SetLicense("path/to/GroupDocs.Comparison.lic");
```

- `License.SetLicense` also has a stream overload (useful for embedded resources) — see `QuickStart/SetLicenseFromStream.cs`.
- Metered licensing is supported — see `QuickStart/SetMeteredLicense.cs`.
- Get a free 30-day temporary license: https://purchase.groupdocs.com/temporary-license/

## Common pitfalls

- **Target frameworks:** the `GroupDocs.Comparison` 26.5.0 package ships assemblies for `net10.0`, `net8.0`, `net6.0`, and `net462` (see the `lib/` folders in `resources/Packages/`). The modern example runner project (`Examples/GroupDocs.Comparison.Examples.CSharp.Net`) targets `net10.0`; a separate `.Framework` runner targets .NET Framework.
- **Result document format** follows the source document format; pass an output path with the matching extension.
- **Trial mode limitations:** without a license, output is watermarked and page count is limited — set a license (or temporary license) for full results.
- **Cross-platform:** works on Windows, Linux, and macOS; the `Examples/` folder includes a `Dockerfile` for running examples in a container.

## Do NOT confuse

- **This repo = the on-premise/local SDK** (`GroupDocs.Comparison` NuGet package). Documents are processed locally; no network calls needed.
- **GroupDocs.Comparison Cloud** is a separate product — a REST API with different SDK packages (e.g. `GroupDocs.Comparison-Cloud`). Do not mix its classes or endpoints with this SDK.
- **MCP server** for document comparison is a separate project: https://github.com/groupdocs-comparison/GroupDocs.Comparison.Mcp

## Links

- Documentation: https://docs.groupdocs.com/comparison/net/
- API reference: https://reference.groupdocs.com/comparison/net/
- Supported formats: https://docs.groupdocs.com/comparison/net/supported-document-formats/
- Releases: https://releases.groupdocs.com/comparison/net/
- NuGet package: https://www.nuget.org/packages/GroupDocs.Comparison
- Free support forum: https://forum.groupdocs.com/c/comparison/12
- Temporary license: https://purchase.groupdocs.com/temporary-license/

## Repo map

- `Examples/` — C# example projects and sample files.
  - `GroupDocs.Comparison.Examples.CSharp/` — shared example sources: `QuickStart/` (HelloWorld, license setup), `BasicUsage/` (compare documents/images, document info), `AdvancedUsage/`, `Resources/` (sample input files).
  - `GroupDocs.Comparison.Examples.CSharp.Net/` — modern .NET runner project (`net10.0`).
  - `GroupDocs.Comparison.Examples.CSharp.Framework/` — .NET Framework runner project.
  - `Dockerfile` — run the examples in a Docker container.
- `Demos/` — demo web applications (`MVC/`, `WebForms/`).
- `Plugins/` — Visual Studio plugin that downloads examples and the library.
- `Docs/` — documentation assets.
- `resources/` — local NuGet packages used by the examples.
