using System.Collections.Generic;
using AutoFixture;
using CopaFilmes.Api.Domain.Commands;
using FluentAssertions;
using Xunit;

namespace CopaFilmes.Tests.Commands
{
	public class MoviesCommandTests
	{
		private readonly Fixture fixture = new Fixture();
		
	    [Fact(DisplayName = "Given that received a movies list when movies list is null than should contains a notification")]
	    public void Should_contains_a_notification_when_movie_list_is_null()
	    {
		    var command = new MoviesCommand();
			command.Validate();

		    command.Notifications.Should().ContainSingle();
	    }

	    [Fact(DisplayName = "Given that received a movies list when movies list contain less of quantity required items than should contains a notification")]
	    public void Should_contain_a_notification_when_movie_list_contain_less_of_quantity_required_items()
	    {
		    var command = new MoviesCommand() { Movies = new List<MovieCommand>() };
		    command.Validate();

		    command.Notifications.Should().ContainSingle();
	    }

	    [Fact(DisplayName = "Given that received a movies list when movies list contains more of quantity required items than should contain a notification")]
	    public void Should_contain_a_notification_when_movie_list_contain_more_of_quantity_required_items()
	    {
		    var movies = new List<MovieCommand>();

			for (var i = 0; i < MoviesCommand.REQUIRED_QUANTITY_MOVIES + 1; i++)
		    {
			    movies.Add(new MovieCommand()
			    {
				    Id = this.fixture.Create<string>(),
					Title = this.fixture.Create<string>(),
					Year = this.fixture.Create<int>(),
				    Score = this.fixture.Create<int>(),
				});
		    }

		    var command = new MoviesCommand() { Movies = movies };
		    command.Validate();

		    command.Notifications.Should().ContainSingle();
	    }

		[Fact(DisplayName = "Given that received a movies list when movies list is valid than should not contain any notification")]
		public void Should_not_contain_a_notification_when_movie_list_is_valid()
		{
			var movies = new List<MovieCommand>();

			for (var i = 0; i < MoviesCommand.REQUIRED_QUANTITY_MOVIES; i++)
			{
				movies.Add(new MovieCommand()
				{
					Id = this.fixture.Create<string>(),
					Title = this.fixture.Create<string>(),
					Year = this.fixture.Create<int>(),
					Score = this.fixture.Create<int>(),
				});
			}

			var command = new MoviesCommand() { Movies = movies };
			command.Validate();

			command.Notifications.Should().BeEmpty();
		}
	}
}
