using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;

namespace CopaFilmes.Api.Domain.Commands
{
	public class MoviesCommand : Notifiable
	{
		public const int REQUIRED_QUANTITY_MOVIES = 8;

	    public IEnumerable<MovieCommand> Movies { get; set; }

	    public void Validate()
		{
			AddNotifications(new Contract()
				.Requires()
				.IsTrue(this.Movies?.Count() == REQUIRED_QUANTITY_MOVIES, nameof(this.Movies),
					$"The movies list should contians just {REQUIRED_QUANTITY_MOVIES} items")
			);

			if(this.Invalid) { return; }

			this.ValidateMoviesItem();
		}

		private void ValidateMoviesItem()
		{
			this.Movies?.ToList().ForEach(filme =>
			{
				filme.Validate();
			});
		}
	}
}
