using Highscore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HighScore.Areas.Admin.Controllers;

[Authorize(Roles = "Administrator")]
[Area("Admin")]
public class HomeController : Controller
{

   public IActionResult Index()
   {

      return View();
   }
}
