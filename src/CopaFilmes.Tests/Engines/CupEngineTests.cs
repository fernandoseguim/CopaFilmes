using AutoFixture;
using CopaFilmes.Service.Domain.Commands;
using CopaFilmes.Service.Domain.Engine;
using CopaFilmes.Service.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Tests.Engines
{
	public class CupEngineTests : UnitTestBase
	{
	    private readonly Fixture fixture = new Fixture();

		[Fact(DisplayName = "Given that received a valid movie list when process that should return a list of winners")]
	    public void Should_return_a_list_of_winners_when_received_a_valid_movie_list()
	    {
		    var movies = new List<Movie>();

		    for (var i = 0; i < MoviesCommand.REQUIRED_QUANTITY_MOVIES; i++)
		    {
			    movies.Add(new Movie(MockString(), MockString(), this.fixture.Create<int>(), this.fixture.Create<int>()));
		    }
			
			var engine = new CupEngine();
		    var winners = engine.Process(movies);

		    winners.Should().BeInDescendingOrder(movie => movie.Score, "The movie with the major score is the winner");
	    }

		[Fact(DisplayName = "Given that received a empty movie list when process that should throw argument exception")]
		public void Should_throw_argument_exception_when_received_a_empty_movie_list()
		{
			var movies = new List<Movie>();
			var engine = new CupEngine();

			Assert.Throws<ArgumentException>(() => engine.Process(movies));
		}

		[Fact(DisplayName = "Given that received a empty movie list when process that should throw argument exception")]
		public void Should_throw_argument_exception_when_received_a_null_movie_list()
		{
			var movies = new List<Movie>();
			var engine = new CupEngine();

			Assert.Throws<ArgumentException>(() => engine.Process(movies));
		}
	}
}
