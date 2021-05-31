---
id: groupdocs-comparison-for-net-21-5-release-notes
url: comparison/net/groupdocs-comparison-for-net-21-5-release-notes
title: GroupDocs.Comparison for .NET 21.5 Release Notes
weight: 16
description: ""
keywords:
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 21.5{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 21.5:

*   Added new parameter to image style comparison that allows you to track the markup type in Word format
*   Fixed handling of some unsupported file signatures
*   Fixed coordinate calculation for changes in ChangeInfo list
*   Fixed creation of charts in some cases in Excel format
*   Fixed creation of resulting document in HTML format
*   Fixed change list counting in Diagram format


## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2629 | API is not tracking the position change for an image in the Word file | Feature |
| COMPARISONCLOUD-157 | Comparison API is not working | Bug |
| COMPARISONNET-2631 | Issue display some special characters in Html  | Bug |
| COMPARISONNET-2691 | Issue with comparing Charts in Cells format  | Bug |
| COMPARISONNET-2694 | Document comparison result has no/wrong box position data | Bug |
| COMPARISONNET-2715 | Issue with getting list of changes for Diagrams | Bug |

## Public API and Backward Incompatible Changes