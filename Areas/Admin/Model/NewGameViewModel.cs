namespace HighScore.Areas.Admin.Model;

public class NewGameViewModel
{
   public string Title { get; set; }

   public string Genre { get; set; }

   public DateTime ReleaseDate { get; set; }

   public string Description { get; set; }
   public Uri ImageUrl { get; set; }
}
