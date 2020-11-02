using GroupDocs.Comparison.Options;
using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Comparison.Words.Revision;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
	/// <summary>
	/// This example demonstrates how to get revisions from a document, process and save the result
	/// </summary>
	class AcceptRejectDetectedRevisionsFromPath
    {
        public static void Run()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath();
	        string outputFileNameAccepted = Path.Combine(outputDirectory, Constants.RESULT_REVISIONS_ACCEPTED);
	        string outputFileNameRejected = Path.Combine(outputDirectory, Constants.RESULT_REVISIONS_REJECTED);

	        // Example of accepting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
	        {
		        List<RevisionInfo> revisionListForAccepted = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForAccepted)
		        {
			        revision.Action = RevisionAction.Accept;
		        }

				revisionHandler.ApplyRevisionChanges(outputFileNameAccepted, new ApplyRevisionOptions() { Changes = revisionListForAccepted });
			}

			// Example of rejecting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
			{
				List<RevisionInfo> revisionListForRejected = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForRejected)
				{
					revision.Action = RevisionAction.Reject;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameRejected, new ApplyRevisionOptions() { Changes = revisionListForRejected });
	        }

			Console.WriteLine($"\nRevisions processed successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}
    }
}
