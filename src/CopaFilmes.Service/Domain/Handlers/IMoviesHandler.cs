using CopaFilmes.Service.Domain.Commands;

namespace CopaFilmes.Service.Domain.Handlers
{
	public interface IMoviesHandler
    {
	    ICommandResult Handle(MoviesCommand command);
    }
}
