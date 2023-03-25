using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;

namespace OlineAuctionMarketing.Controllers
{
	public class AuctioneerController : Controller
	{
		private readonly IAuctioneerService _auctioneerService;

		public AuctioneerController(IAuctioneerService auctioneerService)
		{
			_auctioneerService = auctioneerService;
		}

		public IActionResult Index()
		{
			var auctioneers = _auctioneerService.GetAll();
			return View(auctioneers);
		}
		public IActionResult Create()
		{
			return View();
		}
		public IActionResult CreateAuctioneer(CreateAuctioneerRequestModel auctioneerRequestModel)
		{
			_auctioneerService.Create(auctioneerRequestModel);
			return RedirectToAction("Login", "User");
		}
		[HttpDelete]
		public IActionResult DeleteAuctioneer(int id)
		{
			_auctioneerService.Delete(id);
			return RedirectToAction("Index");
		}
		public IActionResult Delete(int id)
		{
			var get = _auctioneerService.GetById(id);
			return View(get);
		}
		public IActionResult Edit(int id)
		{
			var get = _auctioneerService.GetById(id);
			return View(get);
		}

		[HttpPost]
		public IActionResult Edit(AuctioneerResponseModel auctioneerUpdateRequestModel, int id)
		{
			_auctioneerService.Update(auctioneerUpdateRequestModel, id);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			var get = _auctioneerService.GetById(id);
			return View(get);
		}
		public IActionResult GetAllAuctioneer()
		{
			var list = _auctioneerService.GetAll();
			return View(list);
		}

	}
}
