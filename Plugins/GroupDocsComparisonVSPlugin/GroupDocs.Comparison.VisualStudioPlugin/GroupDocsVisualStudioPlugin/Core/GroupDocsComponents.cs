// Copyright (c) Aspose 2002-2014. All Rights Reserved.

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

            GroupDocsComponent groupdocsassembly = new GroupDocsComponent();
            groupdocsassembly.set_downloadUrl("");
            groupdocsassembly.set_downloadFileName("GroupDocs.Comparison.zip");
            groupdocsassembly.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsassembly.set_remoteExamplesRepository("https://github.com/groupdocs-comparison/GroupDocs.Comparison-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsassembly);
        }
    }
}
