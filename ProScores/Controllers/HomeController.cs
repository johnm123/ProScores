using System.Web.Mvc;
using ProScores.Models;
using ProScores.Logic;

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
        public ActionResult Index(ScoresPageViewModel vm)
        {
            _resultManager.AddResult(vm.NewResult);

            var viewModel = GetModelWithLatestResultsAndStats();

            return View(viewModel);
        }

        private ScoresPageViewModel GetModelWithLatestResultsAndStats()
        {  
            var viewModel = new ScoresPageViewModel()
            {
                Results = _resultManager.GetAllResults(),
                Stats = _resultManager.GetOrderedPlayerStats()
            };

            return viewModel;
        }
    }
}