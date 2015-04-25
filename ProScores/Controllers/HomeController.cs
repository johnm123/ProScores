using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProScores.Models;
using ProScores.Logic;
using ProScores.Objects;

namespace ProScores.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResultManager _resultManager;

        public HomeController(IResultManager resultManager)
        {
            _resultManager = resultManager;
        }

        public ActionResult Index()
        {
            var viewModel = GetModelWithLatestResultsAndStats();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddResult(ScoresPageViewModel vm)
        {
            _resultManager.AddResult(vm.NewResult);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteResult(int id)
        {
            _resultManager.RemoveResult(id);

            return RedirectToAction("Index");
        }

        private ScoresPageViewModel GetModelWithLatestResultsAndStats()
        {
            var viewModel = new ScoresPageViewModel()
            {
                Results = _resultManager.GetAllResults(),
                Stats = _resultManager.GetOrderedPlayerStats(),
            };

            if (viewModel.Results.Any())
            {
                viewModel.LastResultId = viewModel.Results.Last().Id;
            }

            return viewModel;
        }
    }
}