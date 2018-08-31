namespace CopaFilmes.Service.Domain.Commands
{
	public class MoviesCommandResult
    {
	    public string Id { get; set; }
	    public string Title { get; set; }
	    public int Year { get; set; }
	    public int Score { get; set; }
	    public int RankPosition { get; set; }
	}
}
