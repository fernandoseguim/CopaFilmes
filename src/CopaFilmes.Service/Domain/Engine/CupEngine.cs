using System;
using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Service.Domain.Entities;

namespace CopaFilmes.Service.Domain.Engine
{
	public class CupEngine : ICupEngine
	{
		public IReadOnlyList<Movie> Process(IList<Movie> movies)
		{
			if (movies.Any() == false) { throw new ArgumentException("Movie list need contain movie items"); }

			var moviesByScore = movies.OrderBy(movie => movie.Score).ToList().Take(2);
			var winners = moviesByScore.OrderBy(movie => movie.Title).ToList();
			
			return winners;
		}
	}
}
