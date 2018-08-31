using System;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Service.Domain.Entities;

namespace CopaFilmes.Service.Domain.Engine
{
	public class CupEngine : ICupEngine
	{
		private const int FINALISTS = 2;
		private IEnumerable<Movie> winners;

		public CupEngine() => this.winners = new List<Movie>();

		public IEnumerable<Movie> Process(IList<Movie> movies)
		{
			if (movies.Any() == false) { throw new ArgumentException("Movie list need contain movie items"); }

			this.winners = movies
				.OrderByDescending(movie => movie.Score)
				.ThenBy(movie => movie.Title)
				.Take(FINALISTS)
				.ToList();

			return this.winners;
		}
	}
}
