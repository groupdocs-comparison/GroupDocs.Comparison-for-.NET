---
id: groupdocs-comparison-for-net-19-6-release-notes
url: comparison/net/groupdocs-comparison-for-net-19-6-release-notes
title: GroupDocs.Comparison for .NET 19.6 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 19.6{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 19.6:

*   Fixed problem when sections moved to the new page
*   Fixed typos in API reference
*   Implemented sensitivity option
*   Implemented calculation coordinates of changes for Words documents
*   Fixed content overlapping in resultant PDF documents
*   Fixed problem when sections moved to the new page
*   Integrated credit based billing system using latest version of Metered

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-1846 | Calculate correct coordinates of changes for Words | Improvement |
| COMPARISONNET-1929 | Implement sensitivity option | Improvement |
| COMPARISONNET-1901 | Integrate latest version of Dynabic.Metered into products | Improvement |
| COMPARISONNET-1815 | Ignore comments (for code files mostly) | Improvement |
| COMPARISONNET-1816 | Ignore White Space - All, Leading, Trailing, Changes in amount | Improvement |
| COMPARISONNET-1813 | Ignore Case - Ignore character case differences | Improvement |
| COMPARISONNET-1927 | Merged Document and then document Comparison failed | Bug |
| COMPARISONNET-1891 | Text got overlapped with other text or images | Bug |
| COMPARISONNET-1930 | Duplicate Images in Result file in PDF | Bug |
| COMPARISONNET-1772 | PDF comparison has overlapping and mangled output | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 19.6. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  ### **Setting Comparison Detail level**
    
    1.  If we set *DetailLevel = Middle*, we don't  add comment in some document formats (Words, Slides, Cells) if element was added\\deleted\\modified 
        
          
        
    2.  If we set *DetailLevel = Middle*, we don't make case insensitive comparison. i.e. M = m.
        
          
        
    3.  Was added sensitivity property. This option defined limit in percents, when element is detected as deleted or inserted. 
        
    
    Minimal value - 0, comparison process not occurs for any length of sequences of two compared objects. 
    
    Value by default - 75 comparison occurs when the percentage of deleted or inserted elements in relation to all elements does not exceed 75%
    
    Maximum value - 100. Comparison occurs at any length of a common subsequence of two compared objects..  
    
    **For instance, we have two words**
    
    ```csharp
    1)oneSource
     
    2)twoTarget
    ```
    
    This two words have very small a common subsequence.Therefore, when comparing them at 70% accuracy, it is not taken into account and we get a completely removed and inserted word:  
    
    ```csharp
    (twoTarget)[oneSource]
    ```
    
    But at 100% accuracy, we take into account this subsequence, despite the fact that it consists of two letters
    
    ```csharp
    (tw)o[n](Targ)e[Source](t)
    ```
    
    Code snippet:
    
    ```csharp
    string source = "source.txt";
    string target = "target.txt";
    ComparisonSettings settings = new ComparisonSettings();
    settings.SensitivityOfComparison = 100;
    Comparer compare = new Comparer();
    ICompareResult result = compare.Compare(source, target, settings);
    ```
