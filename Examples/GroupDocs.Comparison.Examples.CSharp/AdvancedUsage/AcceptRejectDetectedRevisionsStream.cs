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
	class AcceptRejectDetectedRevisionsFromStream
    {
        public static void Run()
        {
	        Stream inputFileName = new FileStream(Constants.SOURCE_REVISIONS, FileMode.Open, FileAccess.ReadWrite);
			string outputDirectory = Constants.GetOutputDirectoryPath();
	        Stream outputFileNameAccepted = File.Create(Path.Combine(outputDirectory, Constants.RESULT_REVISIONS_ACCEPTED));

			// Example of accepting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(inputFileName))
			{
				List<RevisionInfo> revisionListForAccepted = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForAccepted)
				{
					revision.Action = RevisionAction.Accept;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameAccepted, new ApplyRevisionOptions() { Changes = revisionListForAccepted });
			}

	        outputFileNameAccepted.Close();

			Stream outputFileNameRejected = File.Create(Path.Combine(outputDirectory, Constants.RESULT_REVISIONS_REJECTED));

			// Example of rejecting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(inputFileName))
			{
				List<RevisionInfo> revisionListForRejected = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForRejected)
				{
					revision.Action = RevisionAction.Reject;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameRejected, new ApplyRevisionOptions() { Changes = revisionListForRejected });
			}

			inputFileName.Close();
			outputFileNameRejected.Close();

			Console.WriteLine($"\nRevisions processed successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}
    }
}
