using System;

namespace CopaFilmes.Service.Domain.Entities
{
	public class Movie
    {
		public Movie(string id, string title, int year, double score)
		{
			this.Id = id ?? throw new ArgumentNullException(nameof(id));
			this.Title = title ?? throw new ArgumentNullException(nameof(title));

			this.Year = year;
			if (this.Year == default(int)) { throw new ArgumentException(nameof(this.Year)); }

			this.Score = score;
				if (Math.Abs(this.Score - default(double)) < 0) { throw new ArgumentException(nameof(this.Score)); }
		}

		public string Id { get; }
	    public string Title { get; }
	    public int Year { get; }
	    public double Score { get; }
	}
}
