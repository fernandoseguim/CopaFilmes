using System;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Service.Domain.Commands;
using CopaFilmes.Service.Domain.Engine;
using CopaFilmes.Service.Domain.Entities;
using CopaFilmes.Service.Domain.Factories;

namespace CopaFilmes.Service.Domain.Handlers
{
	public class MoviesHandler : IMoviesHandler
	{
		private readonly ICupEngine engine;

		public MoviesHandler(ICupEngine engine) => this.engine = engine;

		public ICommandResult Handle(MoviesCommand command)
		{
			try
			{
				command.Validate();
				if (command.Invalid)
				{
					return new UnsuccessfulCommandResult(command.Notifications);
				}

				var winners = this.GetWinners(command);

				return new SuccessfulCommandResult(winners);
			}
			catch (Exception ex)
			{
				return new UnsuccessfulCommandResult(ex.Message);
			}
		}

		private IEnumerable<Movie> GetWinners(MoviesCommand command)
		{
			var movies = new List<Movie>();
			command.Movies.ToList().ForEach(item =>
			{
				var movie = MovieFactory.Create(item);
				movies.Add(movie);
			});

			var winners = this.engine.Process(movies);
			return winners;
		}
	}
}
