using Highscore.Data;
using Highscore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Highscore.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationContext context;

		// Dependency injection
		public HomeController(ApplicationContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			var games = context.Game.ToList();
			var scores = context.Scores.ToList();


			var topScores = scores.GroupBy(g => g.GameId)
										 .Select(g => g.OrderByDescending(x => x.Point).FirstOrDefault())
										 .Join(games, s => s.GameId, g => g.Id, (s, g) => new { Score = s, Game = g })
										 .ToList();

			var viewModel = new ScoreViewModel
			{
				TopScore = topScores.Select(s => new ScoreViewModel
				{
					Title = s.Game.Title,
					Player = s.Score.Player,
					Point = s.Score.Point,
					CreateDateTime = s.Score.CreateDateTime,
					UrlSlug = s.Game.UrlSlug
				}).ToList(),
			};

			return View(viewModel);
		}


	}
}