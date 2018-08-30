using CopaFilmes.Api.Domain;
using System.Collections.Generic;
using System.Net.Http;

namespace CopaFilmes.Api.ExternalServices
{
	public class MoviesService : IMoviesService
    {
	    public IEnumerable<Movie> GetMovies()
	    {
			var client = new HttpClient();
			
		    return default(IEnumerable<Movie>);
	    }
    }
}
