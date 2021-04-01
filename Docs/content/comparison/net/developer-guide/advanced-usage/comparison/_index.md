---
id: comparison
url: comparison/net/comparison
title: Comparison
weight: 2
description: "Learn more about advanced document comparison use cases - how to adjust comparison detalisation level, get changed elements coordinates, detect style detection and many more using GroupDocs.Comparison for .NET"
keywords: Compare document with detalisation, Compare documents with password
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
[**GroupDocs.Comparison**](https://products.groupdocs.com/comparison/net) provides many ways to customize changes detection algorithm logic and produced results via changing [CompareOptions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions) class properties.   
Here are the list of settings that can be customized during comparison process:

*   [CalculateCoordinates](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/calculatecoordinates) - Indicates whether to calculate coordinates for changed components;
*   [ChangedItemStyle](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/changeditemstyle) - Describes style for changed components;
*   [DeletedItemStyle](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/deleteditemstyle) - Describes style for deleted components;
*   [DetalisationLevel](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/detalisationlevel) - Gets of sets the comparison detalisation level;
*   [DetectStyleChanges](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/detectstylechanges) - Indicates whether to detect style changes or not;
*   [DiagramMasterSetting](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/diagrammastersetting) - Gets or sets the path value for master or use compare without path of master (this option only for Diagram);
*   [GenerateSummaryPage](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/generatesummarypage) - Indicates whether to add summary page with detected changes statistics to resultant document or not;
*   [InsertedItemStyle](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/inserteditemstyle) - Describes style for inserted components;
*   [MarkChangedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/markchangedcontent) - Indicates whether to use frames for shapes in Word Processing and for rectangles in Image documents;
*   [MarkNestedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/marknestedcontent) - Indicates whether to accept inserted/deleted styles for all children of inserted/deleted components;
*   [OriginalSize](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/originalsize) - Get or sets the original sizes of comparing documents;
*   [PasswordSaveOption](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/passwordsaveoption) - Gets or sets the password save option. More details [here]({{< ref "comparison/net/developer-guide/advanced-usage/saving/set-password-for-resultant-document.md" >}});
*   [SensitivityOfComparison](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/sensitivityofcomparison) - Gets or sets the comparison sensitivity. More details [here]({{< ref "comparison/net/developer-guide/advanced-usage/comparison/adjusting-comparison-sensitivity.md" >}});
*   [ShowDeletedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showdeletedcontent) - Indicates whether to show deleted components in resultant document or not;
*   [ShowInsertedContent](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showinsertedcontent "ShowInsertedContent Property ") - Indicates whether to show inserted components in resultant document or not;
*   [WordsSeparatorChars](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/wordsseparatorchars) - Sets an array of delimiters to split text into words;
*   [CompareBookmarks](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparebookmarks) - Activate the comparison of bookmarks;
*   [CompareVariableProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparevariableproperty) - Activate the comparison of variable properties;
*   [CompareDocumentProperty](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/comparedocumentproperty) - Activate the comparison of built and custom properties;
*   [ShowRevisions](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/showrevisions) - Show others revisions in the resultant document;
*   [LeaveGaps](https://apireference.groupdocs.com/comparison/net/groupdocs.comparison.options/compareoptions/properties/leavegaps) - Show empty lines instead of inserted / deleted components in the final document.

For more details about described options please refer to the following guides:
