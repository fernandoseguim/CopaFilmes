using CopaFilmes.Service.Domain.Commands;
using CopaFilmes.Service.Domain.Entities;

namespace CopaFilmes.Service.Domain.Factories
{
	public class MovieFactory
    {
	    public static Movie Create(MovieCommand command) 
		    => new Movie(command.Id, command.Title, command.Year, command.Score);
    }
}
