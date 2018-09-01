using AutoFixture;
using CopaFilmes.Service.Domain.Engine;
using CopaFilmes.Service.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace CopaFilmes.Tests.Engines
{
	public class CupEngineTests : UnitTestBase
	{
	    private readonly Fixture fixture = new Fixture();

		[Fact(DisplayName = "Given that received a valid movie list when process that should return a list of winners")]
	    public void Should_return_a_list_of_winners_when_received_a_valid_movie_list()
	    {
		    var movies = JsonConvert.DeserializeObject<List<Movie>>(MoviesMock.RegularCase);

			var engine = new CupEngine();
		    var winners = engine.Process(movies).ToList();

		    winners.Should().BeInDescendingOrder(movie => movie.Score, "The movie with the major score is the winner");
		}

		[Fact(DisplayName = "Given that the list of winners movies then the first score should be greater than the last score")]
		public void First_score_should_be_greater_than_the_last_score()
		{
			var movies = JsonConvert.DeserializeObject<List<Movie>>(MoviesMock.RegularCase);

			var engine = new CupEngine();
			var winners = engine.Process(movies).ToList();

			var result = winners.First().Score >= winners.Last().Score;
			result.Should().BeTrue("The movie with the major score is the winner");
		}

		[Fact(DisplayName = "Given that return the list of winners movies when to be a tie then the winner should be the first movie in ascending order by title")]
		public void Should_be_the_first_movie_in_ascending_order_by_title()
		{
			var movies = JsonConvert.DeserializeObject<List<Movie>>(MoviesMock.CaseOfATie);

			var engine = new CupEngine();
			var winners = engine.Process(movies).ToList();

			var result = string.Compare(winners.First().Title, winners.Last().Title, StringComparison.InvariantCulture) <= 0;
			result.Should().BeTrue("In case of a tie, the winner should be the first movie in ascending order by title");
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
