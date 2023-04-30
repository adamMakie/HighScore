using Highscore.Data;
using Highscore.Data.Models;
using Highscore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Highscore.Controllers;
public class HighScoresController : Controller
{
	private readonly ApplicationContext context;

	public HighScoresController(ApplicationContext context)
	{
		this.context = context;
	}

	[Authorize]
	public IActionResult New()
	{
		var gameTitles = context.Game.Select(g => new GameViewModel { Id = g.Id, Title = g.Title }).ToList();

		ViewData["Title"] = "Register Highscore";

		return View(gameTitles);
	}

	public IActionResult RegisterHighScores(int gameId, string player, DateTime createDateTime, int point)
	{
		var game = context.Game.FirstOrDefault(g => g.Id == gameId);

		var score = new Score
		{
			Player = player,
			CreateDateTime = createDateTime,
			Point = point,
			GameId = gameId,
			Game = game
		};
		context.Scores.Add(score);
		context.SaveChanges();

		return RedirectToAction("Index", "Home", new { area = "" });
	}
};



