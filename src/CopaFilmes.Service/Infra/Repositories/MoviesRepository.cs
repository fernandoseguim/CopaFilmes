using System;
using System.Collections.Generic;
using CopaFilmes.Service.Domain.Queries;

namespace CopaFilmes.Service.Infra.Repositories
{
	public class MoviesRepository : IMoviesRepository
	{
		private readonly IHttpWrapper httpWrapper;
		private readonly MoviesApiContext moviesApiContext;

		public MoviesRepository(IHttpWrapper httpWrapper, MoviesApiContext moviesApiContext)
		{
			this.httpWrapper = httpWrapper;
			this.moviesApiContext = moviesApiContext;
		}

		public IEnumerable<MovieQueryResult> GetMovies()
		{
			var movies = this.httpWrapper.Get<List<MovieQueryResult>>(new Uri(this.moviesApiContext.Endpoint));
			return movies;
		}
	}
}
