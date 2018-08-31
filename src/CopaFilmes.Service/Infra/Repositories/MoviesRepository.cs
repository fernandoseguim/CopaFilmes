using System;
using System.Collections.Generic;
using CopaFilmes.Api.Domain.Queries;

namespace CopaFilmes.Api.Infra.Repositories
{
	public class MoviesRepository : IMoviesRepository
	{
		private readonly IHttpWrapper httpWrapper;

		public MoviesRepository(IHttpWrapper httpWrapper) => this.httpWrapper = httpWrapper;

		public IEnumerable<MovieQueryResult> GetMovies()
		{
			var movies = this.httpWrapper.Get<List<MovieQueryResult>>(new Uri("http://copafilmes.azurewebsites.net/api/filmes"));
			return movies;
		}
	}
}
