using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineResume.Web.ViewModels;
using System.Security.Claims;

namespace OnlineResume.Web.Controllers;

public class InviteController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(InviteIndexViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (model.Code == "123")
        {
            var claims = new List<Claim>()
            {
                new Claim("Company.Name", "连云港电子口岸")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: "Home");
        }
        else
        {
            ModelState.AddModelError(nameof(model.Code), "邀请码验证错误");
        }
        return View();
    }
}
