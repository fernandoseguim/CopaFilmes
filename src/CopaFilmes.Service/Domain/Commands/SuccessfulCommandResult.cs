using Newtonsoft.Json;
using System.Net;

namespace CopaFilmes.Service.Domain.Commands
{
	public class SuccessfulCommandResult : ICommandResult
	{
		public SuccessfulCommandResult(object data)
		{
			this.StatusCode = HttpStatusCode.OK;
			this.Success = false;
			this.Data = data;
		}

		[JsonIgnore]
		public HttpStatusCode StatusCode { get; }
		public bool Success { get; }
		public object Data { get; }
	}
}
