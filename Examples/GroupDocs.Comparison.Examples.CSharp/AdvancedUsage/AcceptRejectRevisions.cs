using System;
using System.IO;
using System.Collections.Generic;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Words.Revision;

    /// <summary>
    /// This class demonstrates how to get revisions from a document, process and save the result
    /// </summary>
    class AcceptRejectRevisions
	{
		/// <summary>
		/// This example demonstrates how to get revisions from document path
		/// </summary>
		public static void AcceptRejectRevisionsFromPath()
		{
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AcceptRejectRevisionsFromPath : how to get revisions from document path\n");

            string outputDirectoryAccepted = Constants.GetOutputDirectoryPath(nameChildFolder: "AcceptRevisionsFromPath");
			string outputFileNameAccepted = Path.Combine(outputDirectoryAccepted, Constants.RESULT_REVISIONS);

			string outputDirectoryRejected = Constants.GetOutputDirectoryPath(nameChildFolder: "RejectRevisionsFromPath");
			string outputFileNameRejected = Path.Combine(outputDirectoryRejected, Constants.RESULT_REVISIONS);

			// Example of accepting some changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
			{
				List<RevisionInfo> revisionListForAccepted = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForAccepted)
				{
					if (revision.Type == RevisionType.Insertion) revision.Action = RevisionAction.Accept;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameAccepted,
					new ApplyRevisionOptions() {Changes = revisionListForAccepted});
			}

			// Example of rejecting some changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
			{
				List<RevisionInfo> revisionListForRejected = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForRejected)
				{
					if (revision.Type == RevisionType.Insertion) revision.Action = RevisionAction.Reject;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameRejected,
					new ApplyRevisionOptions() {Changes = revisionListForRejected});
			}

			Console.WriteLine(
				$"\nRevisions processed successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}


		/// <summary>
		/// This example demonstrates how to get revisions from document stream
		/// </summary>
		public static void AcceptRejectRevisionsFromStream()
		{
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AcceptRejectRevisionsFromStream : how to get revisions from document stream\n");

            Stream inputFileName = new FileStream(Constants.SOURCE_REVISIONS, FileMode.Open, FileAccess.ReadWrite);
			string outputDirectoryAccepted = Constants.GetOutputDirectoryPath(nameChildFolder: "AcceptRevisionsFromStream");
			Stream outputFileNameAccepted = File.Create(Path.Combine(outputDirectoryAccepted, Constants.RESULT_REVISIONS));

			// Example of accepting some changes
			using (RevisionHandler revisionHandler = new RevisionHandler(inputFileName))
			{
				List<RevisionInfo> revisionListForAccepted = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForAccepted)
				{
					if (revision.Type == RevisionType.Insertion) revision.Action = RevisionAction.Accept;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameAccepted,
					new ApplyRevisionOptions() {Changes = revisionListForAccepted});
			}

			outputFileNameAccepted.Close();

			string outputDirectoryRejected = Constants.GetOutputDirectoryPath(nameChildFolder: "RejectRevisionsFromStream");
			Stream outputFileNameRejected = File.Create(Path.Combine(outputDirectoryRejected, Constants.RESULT_REVISIONS));

			// Example of rejecting some changes
			using (RevisionHandler revisionHandler = new RevisionHandler(inputFileName))
			{
				List<RevisionInfo> revisionListForRejected = revisionHandler.GetRevisions();
				foreach (RevisionInfo revision in revisionListForRejected)
				{
					if (revision.Type == RevisionType.Insertion) revision.Action = RevisionAction.Reject;
				}

				revisionHandler.ApplyRevisionChanges(outputFileNameRejected,
					new ApplyRevisionOptions() {Changes = revisionListForRejected});
			}

			inputFileName.Close();
			outputFileNameRejected.Close();

			Console.WriteLine(
				$"\nRevisions processed successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}

		/// <summary>
		/// This example demonstrates how to optimally handle all revisions
		/// </summary>
		public static void AcceptRejectAllRevisions()
		{
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AcceptRejectAllRevisions : how to optimally handle all revisions\n");

            string outputDirectoryAccepted = Constants.GetOutputDirectoryPath(nameChildFolder: "AcceptAllRevisions");
			string outputFileNameAccepted = Path.Combine(outputDirectoryAccepted, Constants.RESULT_REVISIONS);

			string outputDirectoryRejected = Constants.GetOutputDirectoryPath(nameChildFolder: "RejectAllRevisions");
			string outputFileNameRejected = Path.Combine(outputDirectoryRejected, Constants.RESULT_REVISIONS);

			// Example of accepting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
			{
				revisionHandler.ApplyRevisionChanges(outputFileNameAccepted,
					new ApplyRevisionOptions() { CommonHandler = RevisionAction.Accept });
			}

			// Example of rejecting all changes
			using (RevisionHandler revisionHandler = new RevisionHandler(Constants.SOURCE_REVISIONS))
			{
				revisionHandler.ApplyRevisionChanges(outputFileNameRejected,
					new ApplyRevisionOptions() { CommonHandler = RevisionAction.Reject });
			}

			Console.WriteLine(
				$"\nRevisions processed successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}
	}
}

