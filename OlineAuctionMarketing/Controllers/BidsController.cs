using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Bids;

namespace OlineAuctionMarketing.Controllers;
public class BidsController : Controller
{
    private readonly IBidsService _bidsService;
    private readonly IAuctionService _auctionService;

    public BidsController(IBidsService bidsService, IAuctionService auctionService)
    {
        _bidsService = bidsService;
        _auctionService = auctionService;
    }
    public IActionResult Index()
    {
        var bids = _bidsService.GetAll();
        return View(bids);
    }
    public IActionResult Create(int auctionId)
    
    {
        var auction = _auctionService.GetById(auctionId);
        return View(auction);
    }
    [HttpPost]
    public IActionResult Create(CreateBidRequestModel createBidsRequest)
    {
        _bidsService.Create(createBidsRequest);
        return RedirectToAction("Login", "User");
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
    public IActionResult GetAllBids()
    {
        var list = _bidsService.GetAll();
        return View(list);
    }
}
