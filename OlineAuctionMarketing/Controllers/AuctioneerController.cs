using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Enums;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using System.Security.Claims;

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
			var auction = _auctioneerService.Create(auctioneerRequestModel);
            TempData["Message"] = auction.Massage;
            return RedirectToAction("Login", "User");
		}
		
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
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Index", "Home");
            }
            var list = _auctioneerService.GetAll();
			return View(list);
		}

		public IActionResult GetById(int id)
		{
            //var userRole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userRole != UserRole.Auctioneer.ToString())
            //{
            //    return RedirectToAction("DashBoard", "Auctioneer");
            //}
            var auctioneer = _auctioneerService.GetById(id);
			return View(auctioneer);	
		}
		[Authorize(Roles ="Auctioneer")]
        public IActionResult DashBoard()
        {
           /* var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole != UserRole.Auctioneer.ToString())
            {
				return RedirectToAction("Index", "Home");
			}*/
			return View();
        }

    }
}
