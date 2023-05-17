using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Bids;
using OlineAuctionMarketing.Models.Entities;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers;
public class BidsController : Controller
{
    private readonly IBidsService _bidsService;
    private readonly IAuctionService _auctionService;
    private readonly IBidderService _bidderService;

    public BidsController(IBidsService bidsService, IAuctionService auctionService, IBidderService bidderService)
    {
        _bidsService = bidsService;
        _auctionService = auctionService;
        _bidderService = bidderService;
    }
    public IActionResult Index()
    {
        var bids = _bidsService.GetAll();
        return View(bids);
    }
    public IActionResult Create(int auctionId)
    {
        if (User.FindFirst(ClaimTypes.Name) == null)
        {
           return RedirectToAction("Login","User");
        }
        var auction = _auctionService.GetById(auctionId);
        return View(auction);
    }
    [HttpPost]
    public IActionResult Create(CreateBidRequestModel createBidsRequest)
    {
      var bid =  _bidsService.Create(createBidsRequest);
        if (!bid.Status)
        {
            var auction = _auctionService.GetById(createBidsRequest.AuctionId);
            TempData["Message"] = bid.Massage;
            return View(auction);
        }
        TempData["Message"] = bid.Massage;

        return RedirectToAction("Index", "Home");
    }
    public IActionResult DeleteBid(int id)
    {
        _bidsService.Delete(id);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        var get = _bidsService.GetById(id);
        return View(get);
    }
    public IActionResult Edit(int id)
    {
        var get = _bidsService.GetById(id);
        return View(get);
    }

    [HttpPost]
    public IActionResult Edit(BidResponseModel bidUpdateRequestModel, int id)
    {
        _bidsService.Update(bidUpdateRequestModel, id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Details(int id)
    {
        var get = _bidsService.GetById(id);
        return View(get);
    }
    public IActionResult GetAllAuctionBidders(int auctionId)
    {
        var list = _bidsService.GetAllAuctionBidders(auctionId);
        return View(list);
    }

}
