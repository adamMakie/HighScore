using Highscore.Data.Models;

namespace Highscore.Models;

public class ScoreViewModel
{
	public IEnumerable<Game> Games { get; set; }
	public IEnumerable<Score> Scores { get; set; }
	public List<ScoreViewModel> TopScore { get; set; }

	public int Id { get; set; }
	public string Title { get; set; }
	public string Player { get; set; }
	public int Point { get; set; }
	public DateTime CreateDateTime { get; set; }
	public Game Game { get; set; }

	public string UrlSlug { get; set; }
}