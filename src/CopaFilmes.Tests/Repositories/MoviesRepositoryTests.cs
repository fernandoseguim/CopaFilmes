using CopaFilmes.Api.Domain.Queries;
using CopaFilmes.Api.Infra;
using CopaFilmes.Api.Infra.Repositories;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Tests
{
	public class MoviesRepositoryTests
	{
		private readonly IHttpWrapper httpWrapper;
		public MoviesRepositoryTests()
		{
			this.httpWrapper = Substitute.For<IHttpWrapper>();
			this.httpWrapper.Get<List<MovieQueryResult>>(Arg.Any<Uri>()).Returns(new List<MovieQueryResult>());
		}

        [Fact(DisplayName = "Given that I try to get movies when receiving the response then should be movies")]
        public void ResponseShouldBeMovies()
        {
	        var moviesService = new MoviesRepository(this.httpWrapper);

	        var response = moviesService.GetMovies();

	        response.Should().AllBeOfType<MovieQueryResult>();
        }
    }
}
