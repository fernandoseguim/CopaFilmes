using AutoFixture;
using CopaFilmes.Service.Domain.Commands;
using CopaFilmes.Service.Domain.Engine;
using CopaFilmes.Service.Domain.Entities;
using CopaFilmes.Service.Domain.Handlers;
using FluentAssertions;
using Flunt.Notifications;
using Newtonsoft.Json;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Tests.Handlers
{
	public class MoviesHandlerTests : UnitTestBase
	{
		private readonly IMoviesHandler handler;
		private readonly Fixture fixture = new Fixture();

		public MoviesHandlerTests()
		{
			var engine = Substitute.For<ICupEngine>();
			engine.Process(Arg.Any<List<Movie>>()).Returns(this.MockMovies());
			this.handler = new MoviesHandler(engine);
		}

		[Fact(DisplayName = "Given that handle movies whan movie command is invalid then should return unsuccessful command result")]
	    public void Should_return_unsuccessful_command_result_when_movie_command_is_invalid()
	    {
		    var command = new MoviesCommand();
		    var result = this.handler.Handle(command);
		    result.Should().BeAssignableTo<UnsuccessfulCommandResult>();
	    }

		[Fact(DisplayName = "Given that handle movies whan movie command is invalid then should return unsuccessful command result")]
		public void Should_contain_any_notification_in_when_return_unsuccessful_command_result()
		{
			var command = new MoviesCommand();
			var result = this.handler.Handle(command);
			var notifications = (List<Notification>)result.Data;
			notifications.Should().HaveCountGreaterOrEqualTo(1);
		}

		[Fact(DisplayName = "Given that handle movies whan movie command is valid then should return successful command result")]
		public void Should_return_successful_command_result_when_movie_command_is_valid()
		{
			var movies = JsonConvert.DeserializeObject<List<MovieCommand>>(MoviesMock.RegularCase);
			var command = new MoviesCommand();
			
			movies.ForEach(movie => command.Movies.Add(movie));

			var result = this.handler.Handle(command);
			result.Should().BeAssignableTo<SuccessfulCommandResult>();
		}

		[Fact(DisplayName = "Given that movie command is valid whan return successful command result then should contain winners")]
		public void Should_contain_winners_in_successful_command_result()
		{
			var movies = JsonConvert.DeserializeObject<List<MovieCommand>>(MoviesMock.RegularCase);
			var command = new MoviesCommand();
			movies.ForEach(movie => command.Movies.Add(movie));
			
			var result = this.handler.Handle(command);

			var winners = (List<Movie>)result.Data;
			winners.Should().HaveCount(2);
		}

		private IEnumerable<Movie> MockMovies()
		{
			var movies = new List<Movie>();

			for (var i = 0; i < 2; i++)
			{
				movies.Add(new Movie(MockString(), MockString(), this.fixture.Create<int>(), this.fixture.Create<int>()));
			}

			return movies;
		}
	}
}
