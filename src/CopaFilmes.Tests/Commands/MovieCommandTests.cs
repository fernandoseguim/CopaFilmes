using CopaFilmes.Service.Domain.Commands;
using FluentAssertions;
using Flunt.Notifications;
using Xunit;

namespace CopaFilmes.Tests.Commands
{
	public class MovieCommandTests
	{
	    [Fact(DisplayName = "Given that create a movie when properties movie is invalid than should contain notifications")]
	    public void Should_contain_a_notification_when_properties_movie_is_invalid()
	    {
		    var movie = new MovieCommand();
			
		    movie.Validate();

		    movie.Notifications.Should().ContainItemsAssignableTo<Notification>();
	    }
	}
}
