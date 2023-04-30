using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Highscore.Data.Models;

public class Score
{
	[Key]
	public int Id { get; set; }

	[MaxLength(50)]
	public string Player { get; set; }

	public DateTime CreateDateTime { get; set; }

	[Column(TypeName = "decimal(18,2)")]
	public int Point { get; set; }

	public int GameId { get; set; }

	public Game Game { get; set; }
}
