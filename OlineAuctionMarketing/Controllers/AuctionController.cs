﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Product;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly ICategoryService _categoryService;
        public AuctionController(IAuctionService auctionService, ICategoryService categoryService)
        {
            _auctionService = auctionService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var auction = _auctionService.GetAll();
            return View(auction);
        }
        public IActionResult DisplayAuctions()
        {
            var auction = _auctionService.GetAll();
            return View(auction);
        }
        public IActionResult Create()
        {
            var category = _categoryService.GetAll();
            ViewData["Categories"] = new SelectList(category.Data, "Id", "Name");
            return View();

        }
        [HttpPost]
        public IActionResult CreateAuction(CreateAuctionRequestModel createAuction)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var createAuctions = _auctionService.Create(createAuction, int.Parse(user));
            if (createAuctions.Status == false)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAuction(int id)
        {
            _auctionService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var get = _auctionService.GetById(id);
            return View(get);
        }
        
        public IActionResult Edit(int id)
        {
            var get = _auctionService.GetById(id);
            return View(get);
        }

        [HttpPost]
        public IActionResult EditAuction(AuctionUpdateRequestModel productUpdateReqestModel,int id)
        {
            _auctionService.Update(productUpdateReqestModel, id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var get = _auctionService.GetById(id);
            return View(get);
        }
        public IActionResult Auction(int productId)
        {
            var get = _auctionService.GetById(productId);
            return View(get);
        }
        [HttpPost]
        public IActionResult Auction(AuctionRequestModel auctionRequestModel)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var auctionRequest = _auctionService.Auction(auctionRequestModel, int.Parse(user));
            TempData["Message"] = auctionRequest.Massage;
            return RedirectToAction("DisplayAuctions");
        }
    }
}
