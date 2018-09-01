using System.Collections.Generic;
using CopaFilmes.Service.Domain.Queries;

namespace CopaFilmes.Service.Infra.Repositories
{
	public interface IMoviesRepository
	{
		IEnumerable<MovieQueryResult> GetMovies();
	}
}
