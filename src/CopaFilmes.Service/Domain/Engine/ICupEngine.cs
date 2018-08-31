using System.Collections.Generic;
using CopaFilmes.Service.Domain.Entities;

namespace CopaFilmes.Service.Domain.Engine
{
	public interface ICupEngine
	{
		IEnumerable<Movie> Process(IList<Movie> movies);
	}
}
