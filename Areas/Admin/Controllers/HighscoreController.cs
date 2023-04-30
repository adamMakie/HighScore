using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Highscore.Data;
using Highscore.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HighScore.Areas.Admin.Controllers
{
   [Authorize(Roles = "Administrator")]
   [Area("Admin")]
   public class HighscoreController : Controller
   {
      private readonly ApplicationContext context;

      public HighscoreController(ApplicationContext context)
      {
         this.context = context;
      }

		// GET: Admin/Highscore
		public async Task<IActionResult> Index()
		{
			var scores = await context.Scores
				 .Include(s => s.Game)
				 .Select(s => new ScoreViewModel
				 {
                Id= s.Id,
					 Player = s.Player,
					 CreateDateTime = s.CreateDateTime,
					 Point = s.Point,
					 Title = s.Game.Title
				 })
				 .ToListAsync();

			return View(scores);
		}



		// GET: Admin/Highscore/Delete/5
		public async Task<IActionResult> Delete(int? id)
      {
         if (id == null || context.Scores == null)
         {
            return NotFound();
         }

         var score = await context.Scores
             .Include(s => s.Game)
             .FirstOrDefaultAsync(m => m.Id == id);
         if (score == null)
         {
            return NotFound();
         }

         return View(score);
      }

      // POST: Admin/Highscore/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         if (context.Scores == null)
         {
            return Problem("Entity set 'ApplicationContext.Scores'  is null.");
         }
         var score = await context.Scores.FindAsync(id);
         if (score != null)
         {
            context.Scores.Remove(score);
         }

         await context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool ScoreExists(int id)
      {
         return (context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
      }
   }
}
