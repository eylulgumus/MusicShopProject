using Microsoft.AspNetCore.Mvc;
using MusicShop.DataAccess.Interfaces;
using MusicShop.DataAccess.ViewModels;
using MusicShop.Models;
using System.Diagnostics;

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitofWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitofWork)
        {
            _logger = logger;
            _unitofWork = unitofWork;
        }
        public ActionResult Index()
        {
			NstrumentVM nstrumentVM = new()
			{
				instruments = _unitofWork.Nstrument.GetAll()
			};
			return View(nstrumentVM);
        }

		[HttpGet]
		public IActionResult Details(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			NstrumentVM nstrumentVM = new()
			{
				Instrument = _unitofWork.Nstrument.GetT(x => x.Id == id)
			};
			if (nstrumentVM == null)
			{
				return NotFound();
			}
			return View(nstrumentVM);
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}