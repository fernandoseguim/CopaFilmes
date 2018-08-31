using System.Collections.Generic;
using CopaFilmes.Api.Domain.Queries;

namespace CopaFilmes.Api.Infra.Repositories
{
	public interface IMoviesRepository
	{
		IEnumerable<MovieQueryResult> GetMovies();
	}
}
