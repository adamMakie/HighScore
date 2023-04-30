using Highscore.Data.Models;
using HighScore.Models;
using System.Diagnostics;

namespace Highscore.Models;

public class GameViewModel
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Genre { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string Description { get; set; }
	public Uri ImageUrl { get; set; }
	public List<ScoreViewModel> TopScores { get; set; }

	public string UrlSlug { get; set; }
}
