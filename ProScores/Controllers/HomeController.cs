using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ProScores.Models;
using ProScores.Logic;
using ProScores.Objects;

namespace ProScores.Controllers
{
    public class HomeController : Controller
    {
        private IResultManager _resultManager;

        public HomeController(IResultManager resultManager)
        {
            _resultManager = resultManager;
        }

        public ActionResult Index()
        {
            return View(new ScoresPageViewModel() { Results = GetTestResults() });
        }

        [HttpPost]
        public ActionResult Index(ScoresPageViewModel vm)
        {
            return View(new ScoresPageViewModel() { Results = GetTestResults() });
        }

        private static IEnumerable<ProEvoResult> GetTestResults()
        {
            var results = new List<ProEvoResult>()
            {
                new ProEvoResult()
                {
                    PlayerHome = "John",
                    PlayerAway = "Phillip",
                    GoalsHome = 5,
                    GoalsAway = 1,
                    Date = DateTime.Now
                },
                new ProEvoResult()
                {
                    PlayerHome = "Jacob",
                    PlayerAway = "Peter",
                    GoalsHome = 3,
                    GoalsAway = 5,
                    Date = DateTime.Now
                },
                new ProEvoResult()
                {
                    PlayerHome = "Sam",
                    PlayerAway = "Jason",
                    GoalsHome = 2,
                    GoalsAway = 0,
                    Date = DateTime.Now
                }
            };
            return results;
        }
    }
}