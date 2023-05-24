using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OlineAuctionMarketing.Interface.IService;
using OlineAuctionMarketing.Models.DTO.Users;
using OlineAuctionMarketing.Models.Entities;
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
                return RedirectToAction("DashBoard", "Auctioneer");
            }
            if (userLogin.Data.Role == Enums.UserRole.Bidder)
            {
                return RedirectToAction("DashBoard", "Bidder");

            }
            return RedirectToAction();


        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
        public IActionResult UpdatePassword(int id)
        {
            var get = _userService.GetById(id);
            return View(get);
        }

        public IActionResult Update(int id)
        {
            var get = _userService.GetById(id);
            return View(get);
        }

        [HttpPost]
        public IActionResult Update(UserResponseModel userResponseModel, int id)
        { 
           var get = _userService.Update(userResponseModel, id);
            TempData["Message"] = get.Massage;
            return RedirectToAction("Update");
        }
    }
}
