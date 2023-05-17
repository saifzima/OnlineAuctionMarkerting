using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Users;
using System.Security.Claims;

namespace OlineAuctionMarketing.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        public IActionResult UserLogin(UserLoginRequestModel userLoginReqestModel)
        {
            var userLogin = _userService.Login(userLoginReqestModel);
            if (userLogin.Status == false)
            {
                TempData["Failed"] = userLogin.Massage;
                return View("Login");
            }
            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Role,userLogin.Data.Role.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,userLogin.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,userLoginReqestModel.Email)
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
            if (userLogin.Data.Role == Enums.UserRole.Admin)
            {

                return RedirectToAction("DashBoard", "Admin");
            }
            if (userLogin.Data.Role == Enums.UserRole.Auctioneer)
            {
                return RedirectToAction("Create", "Auction");
            }
            if (userLogin.Data.Role == Enums.UserRole.Bidder)
            {
                return RedirectToAction("DisplayAuctions", "Auction");

            }
            return RedirectToAction("Index", "home");


        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
