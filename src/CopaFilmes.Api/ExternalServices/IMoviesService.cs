using System.Collections.Generic;
using CopaFilmes.Api.Domain;

namespace CopaFilmes.Api.ExternalServices
{
	public interface IMoviesService
	{
		IEnumerable<Movie> GetMovies();
	}
}
