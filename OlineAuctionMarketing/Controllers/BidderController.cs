using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using OlineAuctionMarketing.Models.DTO.Bidder;

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
            _bidderService.Create(bidderRequestModel);
            return RedirectToAction("Login", "User");
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
        public IActionResult GetAllBidder()
        {
            var list = _bidderService.GetAll();
            return View(list);
        }
    }
}
