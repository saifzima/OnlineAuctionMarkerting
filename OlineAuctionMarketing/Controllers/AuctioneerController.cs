﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Enums;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Auctioneer;
using System.Data;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
    public class AuctioneerController : Controller
    {
        private readonly IAuctioneerService _auctioneerService;
        private readonly IUserService _userService;

        public AuctioneerController(IAuctioneerService auctioneerService, IUserService userService)
        {
            _auctioneerService = auctioneerService;
            _userService = userService;
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
           var delete = _auctioneerService.Delete(id);
            TempData["Message"] = delete.Massage;
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
            //var get = _auctioneerService.GetById(id);
            var get = _userService.GetById(id);
            return View(get);
        }

        [Authorize(Roles = "Admin")]//Example on replacing the userROLE WITH actioon filters
        public IActionResult GetAllAuctioneer()
        {
            //var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            //if (userRole != UserRole.Admin.ToString())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            var list = _auctioneerService.GetAll();
            return View(list);
        }

        [Authorize(Roles = "Auctioneer")]//Example on replacing the userROLE WITH actioon filters
        public IActionResult GetById(int id)
        {
            //this can be archieve using action filters
            //var userRole = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //if (userRole != UserRole.Auctioneer.ToString())
            //{
            //    return RedirectToAction("DashBoard", "Auctioneer");
            //}
            var auctioneer = _auctioneerService.GetById(id);
            return View(auctioneer);
        }
        public IActionResult DashBoard()
        {
            //var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            //if (userRole != UserRole.Auctioneer.ToString())
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return View();
        }

    }
}
