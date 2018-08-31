using Flunt.Notifications;
using Flunt.Validations;

namespace CopaFilmes.Api.Domain.Commands
{
	public class MovieCommand : Notifiable
    {
	    public string Id  { get; set; }
	    public string Title { get; set; }
	    public int Year { get; set; }
	    public int Score { get; set; }

	    public void Validate()
	    {
			AddNotifications(new Contract()
				.Requires()
				.IsNullOrEmpty(this.Id, nameof(this.Id), "Movie identifier can not be null or empty")
				.IsNullOrEmpty(this.Title, nameof(this.Title), "Movie title can not be null or empty")
				.IsNull(this.Year, nameof(this.Year), "Movie year can not be null")
				.IsNull(this.Score, nameof(this.Score), "Movie score can not be null"));
	    }
	}
}
