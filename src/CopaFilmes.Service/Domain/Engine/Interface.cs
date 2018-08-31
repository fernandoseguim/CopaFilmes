using System.Collections.Generic;
using CopaFilmes.Service.Domain.Entities;

namespace CopaFilmes.Service.Domain.Engine
{
	public interface ICupEngine
	{
		IReadOnlyList<Movie> Process(IList<Movie> movies);
	}
}
