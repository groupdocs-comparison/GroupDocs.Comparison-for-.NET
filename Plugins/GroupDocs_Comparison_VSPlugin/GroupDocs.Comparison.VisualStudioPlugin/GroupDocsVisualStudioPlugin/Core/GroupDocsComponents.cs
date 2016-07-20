// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsComparisonVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsComparison = new GroupDocsComponent();
            groupdocsComparison.set_downloadUrl("");
            groupdocsComparison.set_downloadFileName("groupdocs.Comparison.zip");
            groupdocsComparison.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsComparison.set_remoteExamplesRepository("https://github.com/groupdocs-Comparison/GroupDocs.Comparison-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsComparison);
        }
    }
}
