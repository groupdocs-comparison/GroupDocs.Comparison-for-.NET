---
id: migration-notes
url: comparison/net/migration-notes
title: Migration Notes
weight: 3
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
### Why To Migrate?

  
Here are the key reasons to use the new updated API provided by GroupDocs.Comparison for .NET since version 19.9:

*   **Comparer** class introduced as a **single entry point** to compare documents of any supported file format with various options and ability to accept/reject found differences in resultant document.  
*   Document **compare options** for all document types. Instead of using document related options now options are related to compare type only.
*   The overall document related classes were unified to common. 
*   Product architecture was redesigned from scratch in order to simplify passing options and classes to manipulate comparison.
*   Document information and preview generation procedures were simplified.  
      
    

### How To Migrate?

Here is a brief comparison of how to compare document with old and new API.  

**Old coding style**

```csharp
Comparer comparer = new Comparer();
ComparisonSettings settings = new ComparisonSettings() 
{ 
	StyleChangeDetection = true
};
ICompareResult result = comparer.Compare("source.docx", @"target.docx", settings);
result.SaveDocument("result.docx");
```

**New coding style**

```csharp
using (Comparer comparer = new Comparer("source.docx"))
{
    comparer.Add("target.docx");
    CompareOptions compareOptions = new CompareOptions()
    {
        DetectStyleChanges = true
    };
	comparer.Compare("result.docx", compareOptions);
}
```
