using System.Net;

namespace CopaFilmes.Service.Domain.Commands
{
	public interface ICommandResult
	{
		HttpStatusCode StatusCode { get; }
		bool Success { get; }
		object Data { get; }
	}
}
