using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace Highscore.Data.Models;

public class Game
{
	[Key]
	public int Id { get; set; }

	public string UrlSlug { get; set; }

	public string Title { get; set; }

	public string Genre { get; set; }

   public DateTime ReleaseDate { get; set; }

	public string Description { get; set; }
	public Uri ImageUrl { get; set; }

	public List<Score> Scores { get; set; }
}
