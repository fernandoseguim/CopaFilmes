using System;
using RestSharp;

namespace CopaFilmes.Service.Infra
{
	public class HttpWrapper : IHttpWrapper
	{
		private RestClient restClient;
		private RestRequest restRequest;

		public T Get<T>(Uri uri) where T : new()
		{
			this.CreateResquest(uri, Method.GET);
			var response = this.SendRequest<T>();
			return response.Data;
		}

		private void CreateResquest(Uri uri, Method method)
		{
			this.restClient = new RestClient { BaseUrl = uri };
			this.restRequest = new RestRequest(method) { RequestFormat = DataFormat.Json };
		}

		private IRestResponse<T> SendRequest<T>() where T : new()
		{
			var response = this.restClient.Execute<T>(this.restRequest);
			return response;
		}
	}
}
