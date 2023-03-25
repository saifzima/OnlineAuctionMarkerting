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
			/*var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Role,userLogin.Date.Role.ToString()),
					new Claim(ClaimTypes.NameIdentifier,userLogin.Date.Id.ToString()),
					new Claim(ClaimTypes.Name,userLoginReqestModel.Email)
				};

			var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var authenticationProperties = new AuthenticationProperties();
			var principal = new ClaimsPrincipal(claimIdentity);
			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
			if (userLogin.Date.Role == Enums.UserRole.Admin)
			{

				// return RedirectToAction("Index", "Product");
			}
			if (userLogin.Date.Role == Enums.UserRole.Auctioneer)
			{
				// return RedirectToAction("DisplayProducts", "Product");
			}*/
			return RedirectToAction("Create", "Product");


		}

		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction(nameof(Login));
		}
	}
}
