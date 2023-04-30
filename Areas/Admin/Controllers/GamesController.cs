using Microsoft.EntityFrameworkCore;
using Highscore.Data;
using Highscore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using HighScore.Areas.Admin.Model;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HighScore.Areas.Admin.Controllers
{
   [Authorize(Roles = "Administrator")]
   [Area("Admin")]
   public class GamesController : Controller
   {
      private readonly ApplicationContext context;

      public GamesController(ApplicationContext context)
      {
         this.context = context;
      }

      // GET: Admin/Games
      public async Task<IActionResult> Index()
      {
         return View(await context.Game.ToListAsync());
                    
      }


      // GET: Admin/Games/Create
      public IActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(NewGameViewModel viewModel)
      {
         if (ModelState.IsValid)
         {
            var game = new Game
            {
               UrlSlug = viewModel.Title.Replace("-", "").Replace(" ", "-").ToLower(),
               Title = viewModel.Title,
               Genre = viewModel.Genre,
               ReleaseDate = viewModel.ReleaseDate,
               Description = viewModel.Description,
               ImageUrl = viewModel.ImageUrl
            };

            context.Add(game);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(viewModel);
      }

      // GET: Admin/Games/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null || context.Game == null)
         {
            return NotFound();
         }

         var game = await context.Game.FindAsync(id);
         if (game == null)
         {
            return NotFound();
         }
         return View(game);
      }

      
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null || context.Game == null)
         {
            return NotFound();
         }

         var game = await context.Game
             .FirstOrDefaultAsync(m => m.Id == id);
         if (game == null)
         {
            return NotFound();
         }

         return View(game);
      }

      // POST: Admin/Games/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
    
         var game = await context.Game.FindAsync(id);
         context.Game.Remove(game);
         await context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool GameExists(int id)
      {
         return (context.Game?.Any(e => e.Id == id)).GetValueOrDefault();
      }
   }
}
