using Newtonsoft.Json;

namespace CopaFilmes.Api.Domain.Queries
{
	public class MovieQueryResult
    {
		public string Id { get; set; }
	    public string Title => this.Titulo;
	    public int Year => this.Ano;
	    public int Score => this.Nota;

		[JsonIgnore]
		public string Titulo { get; set; }
	    [JsonIgnore]
		public int Ano { get; set; }
	    [JsonIgnore]
		public int Nota { get; set; }
	}
}
