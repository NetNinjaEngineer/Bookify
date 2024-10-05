using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookify.Controllers;

[AllowAnonymous]
public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signManager;
    private readonly IMapper _mapper;

    public AccountController(
        UserManager<User>
        userManager, SignInManager<User> signManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _signManager = signManager;
        _mapper = mapper;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM registerModel)
    {
        if (!ModelState.IsValid)
            return View(registerModel);

        var userForRegisteration = _mapper.Map<User>(registerModel);

        var registerResult = await _userManager.CreateAsync(userForRegisteration, registerModel.Password!);

        if (registerResult.Succeeded)
            return RedirectToAction("Login");

        foreach (var error in registerResult.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(registerModel);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM loginModel)
    {
        if (!ModelState.IsValid)
            return View(loginModel);

        var userForAuthenticate = await _userManager.FindByEmailAsync(loginModel.Email);

        if (userForAuthenticate == null)
            return NotFound();

        var loginResult = await _signManager.PasswordSignInAsync(
            user: userForAuthenticate,
            password: loginModel.Password,
            isPersistent: true,
            lockoutOnFailure: false);

        if (!loginResult.Succeeded)
            return View(loginModel);

        var userClaims = new List<Claim>
        {
            new(ClaimTypes.GivenName, loginModel.Email),
            new(ClaimTypes.Role, "User")
        };

        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            claimsPrinciple,
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
            });

        return RedirectToAction("Index", "Home");

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }


}
