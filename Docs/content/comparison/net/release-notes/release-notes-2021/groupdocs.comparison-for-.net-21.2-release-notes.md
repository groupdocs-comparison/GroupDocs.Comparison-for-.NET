---
id: groupdocs-comparison-for-net-21-2-release-notes
url: comparison/net/groupdocs-comparison-for-net-21-2-release-notes
title: GroupDocs.Comparison for .NET 21.2 Release Notes
weight: 19
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 21.2{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 21.2:

*   Fixed closing the stream after generating preview in PDF format 
*   Fixed generating previews in Diagram format
*   Fixed generating previews in HTML format
*   Fixed saving the comparison result in HTML format using the file stream
*   Improved comparison in Excel format using pictures and diagrams 
*   Added SourceText property to ChangeInfo class and improved TargetText property for Diagram, Slide, Txt and Note formats
## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2595 | Improve ability of getting source text for Diagrams documents | Improvement |
| COMPARISONNET-2594 | Improve ability of getting source text for Slides documents | Improvement |
| COMPARISONNET-2589 | Improve ability of getting source text for Text documents | Improvement |
| COMPARISONNET-2598 | Improve ability of getting source text for Notes documents | Improvement |
| COMPARISONNET-2592 | Cannot compare particular Excel sheets | Bug |
| COMPARISONNET-2599 | Preview generator closes stream for pdf | Bug |
| COMPARISONNET-2600 | Diagram preview does not insert text inside shapes | Bug |
| COMPARISONNET-2603 | Incorrect display of Excel document | Bug |
| COMPARISONNET-2602 | Charts are not displayed in Excel format | Bug |
| COMPARISONNET-2601 | HTML preview renders only one image | Bug |                                                                                                        	

## Public API and Backward Incompatible Changes

Learn more about getting source and target texts, which can be found [here](https://docs.groupdocs.com/comparison/net/get-source-and-target-text-from-files/).
