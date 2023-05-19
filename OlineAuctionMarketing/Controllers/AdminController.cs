using Microsoft.AspNetCore.Mvc;

namespace OlineAuctionMarketing.Controllers;

public class AdminController : Controller
{
    public IActionResult DashBoard()
    {
        return View();
    }
}
