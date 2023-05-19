using EasyLearn.GateWays.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OlineAuctionMarketing.Gateways.Email;
using OlineAuctionMarketing.Inplementation.Service;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models;
using OlineAuctionMarketing.Models.Entities;
using System.Diagnostics;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IAuctionService _auctionService;
        private readonly ICategoryService _categoryService;
        private readonly ISendInBlueEmailService _sendInBlueEmailService;

        public HomeController(ILogger<HomeController> logger, IAuctionService auctionService, ICategoryService categoryService, ISendInBlueEmailService sendInBlueEmailService)
        {
            _logger = logger;
            _auctionService = auctionService;
            _categoryService = categoryService;
            _sendInBlueEmailService = sendInBlueEmailService;
        }


        public async Task<IActionResult> Index(EmailSenderDTO model)
		{

            var emailContent = new EmailSenderDTO
            {
                ReceiverEmail = "treehays90@gmail.com",
                Subject = "Welcome message",
                Body = "just to notify you about your bid"
            };
            var send = await _sendInBlueEmailService.SendEmail(emailContent);
			
            var category = _categoryService.GetAll();
            ViewData["Categories"] = new SelectList(category.Data, "Id", "Name");
            var auction = _auctionService.GetAll();
            return View(auction);
		}
		public IActionResult Privacy()
		{
			return View();

		}
		public IActionResult Create()
        {
            var category = _categoryService.GetAll();
            ViewData["Categories"] = new SelectList(category.Data, "Id", "Name");
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}