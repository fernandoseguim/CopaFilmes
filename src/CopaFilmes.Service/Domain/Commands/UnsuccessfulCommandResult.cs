using Newtonsoft.Json;
using System.Net;

namespace CopaFilmes.Service.Domain.Commands
{
	public class UnsuccessfulCommandResult : ICommandResult
	{
		public UnsuccessfulCommandResult(object data)
		{
			this.StatusCode = HttpStatusCode.OK;
			this.Success = true;
			this.Data = data;
		}

		[JsonIgnore]
		public HttpStatusCode StatusCode { get; }
		public bool Success { get; }
		public object Data { get; }
	}
}
