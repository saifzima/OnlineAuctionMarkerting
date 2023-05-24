using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Enums;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.DTO.Bidder;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
    public class BidderController : Controller
    {
        private readonly IBidderService _bidderService;

        public BidderController(IBidderService bidderService)
        {
            _bidderService= bidderService;
        }
        public IActionResult Index()
        {
            var bidders = _bidderService.GetAll();
            return View(bidders);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateBidder(CreateBidderRequestModel bidderRequestModel)
        {
            var bidder = _bidderService.Create(bidderRequestModel);
            TempData["Massage"] = bidder.Massage;
            return RedirectToAction("DisplayAuctions", "Auction");
        }
        public IActionResult DeleteBidder(int id)
        {
            _bidderService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var get = _bidderService.GetById(id);
            return View(get);
        }
        public IActionResult Edit(int id)
        {
            var get = _bidderService.GetById(id);
            return View(get);
        }

        [HttpPost]
        public IActionResult Edit(BidderResponseModel bidderUpdateRequestModel, int id)
        {
            _bidderService.Update(bidderUpdateRequestModel, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var get = _bidderService.GetById(id);
            return View(get);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult GetAllBidder()
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole != UserRole.Admin.ToString())
            {
                return RedirectToAction("Create", "Auctioneer");
            }
            var list = _bidderService.GetAll();
            return View(list);
        }
        [Authorize(Roles ="Bidder")]
        public IActionResult GetById(int id)
        {
            var bidder = _bidderService.GetById(id);
            return View(bidder);
        }
        public IActionResult DashBoard() 
        {
            return View();
        }

    }
}
