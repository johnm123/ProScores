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
            var viewModel = GetModelWithLatestResults();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ScoresPageViewModel vm)
        {
            _resultManager.AddResult(vm.NewResult);

            var viewModel = GetModelWithLatestResults();

            return View(viewModel);
        }

        private ScoresPageViewModel GetModelWithLatestResults()
        {  
            var viewModel = new ScoresPageViewModel()
            {
                Results = _resultManager.GetAllResults()
            };

            return viewModel;
        }
    }
}