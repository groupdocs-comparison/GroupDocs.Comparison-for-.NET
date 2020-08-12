using System.Net.Http;
using System.Net.Http.Headers;
using GroupDocs.Comparison.Live.Demos.UI.Config;
using GroupDocs.Comparison.Live.Demos.UI.Models;

namespace GroupDocs.Comparison.Live.Demos.UI.Helpers
{
	public class GroupDocsComparisonApiHelper : ApiHelperBase
	{
		public static Response GetAllComparisonSupportedFormats()
		{
			Response comparisonResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsComparison/GetAllComparisonSupportedFormats").ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							comparisonResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return comparisonResponse;
		}
	}
}