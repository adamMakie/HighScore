using Highscore.Data;
using Highscore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Highscore.Controllers
{
	public class GamesController : Controller
	{
		private readonly ApplicationContext context;

		public GamesController(ApplicationContext context)
		{
			this.context = context;
		}

		[Route("Games/{urlSlug}")]
		public IActionResult Details(string urlSlug)
		{
			var game = context.Game.FirstOrDefault(g => g.UrlSlug == urlSlug);

         if (game == null)
         {
            return NotFound();
         }

         ViewData["Title"] = game.Title;

			var scores = context.Scores
					.Where(s => s.GameId == game.Id)
					.OrderByDescending(s => s.Point)
					.Take(10)
					.ToList();

			var viewModel = new GameViewModel
			{
				UrlSlug = game.UrlSlug,
				Id = game.Id,
				Title = game.Title,
				Genre = game.Genre,
				ReleaseDate = game.ReleaseDate,
				Description = game.Description,
				ImageUrl = game.ImageUrl,
				TopScores = scores.Select(s => new ScoreViewModel
				{
					Player = s.Player,
					CreateDateTime = s.CreateDateTime,
					Point = s.Point
				}).ToList()
			};

			return View(viewModel);
		}

	}
}
