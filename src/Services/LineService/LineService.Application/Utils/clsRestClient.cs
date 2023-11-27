using RestSharp;

namespace LineService.Application.Utils
{
	public class clsRestClient
	{
        public static async Task<string> CallApiBodyAsync(string Url, string resource, string param)
        {
            var restClient = new RestClient(Url);
            var request = new RestRequest(resource);
            
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", param, ParameterType.RequestBody);

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;
            return content;
        }
    }
}

