using System;
using System.Collections.Generic;
using CopaFilmes.Service.Domain.Queries;
using CopaFilmes.Service.Infra;
using CopaFilmes.Service.Infra.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CopaFilmes.Tests.Repositories
{
	public class MoviesRepositoryTests
	{
		private readonly IHttpWrapper httpWrapper;
		private readonly MoviesApiContext moviesApiContext;
		public MoviesRepositoryTests()
		{
			this.httpWrapper = Substitute.For<IHttpWrapper>();
			this.moviesApiContext = Substitute.For<MoviesApiContext>();
			this.httpWrapper.Get<List<MovieQueryResult>>(Arg.Any<Uri>()).Returns(new List<MovieQueryResult>());
			this.moviesApiContext.Endpoint = "http://localhost/mock";
		}

        [Fact(DisplayName = "Given that I try to get movies when receiving the response then should be movies")]
        public void ResponseShouldBeMovies()
        {
	        var moviesService = new MoviesRepository(this.httpWrapper, this.moviesApiContext);

	        var response = moviesService.GetMovies();

	        response.Should().AllBeOfType<MovieQueryResult>();
        }
    }
}
