using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using TCCESTOQUE.Models;

namespace TCCESTOQUE.Controllers
{
    public class HomeController : ControllerPai
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticar();
            var label = new List<string>
            {
                "janaina","fevereiro","marcio","abril","mauro","junho",
                "julhu","agosto","steve","outubro","natalina","dezembro"

            };
            ViewData["labels"] = label;
            return View();
        }

        public IActionResult Manual()
        {
            Autenticar();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
