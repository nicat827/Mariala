using Mariala.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mariala.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}