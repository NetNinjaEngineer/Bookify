using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.Services.Contracts;
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
	private readonly ILogger<AccountController> _logger;
	private readonly INotyfService _notyfService;
	private readonly IUserService _userService;

	public AccountController(
		UserManager<User>
		userManager, SignInManager<User> signManager,
		IMapper mapper, ILogger<AccountController> logger, INotyfService notyfService, IUserService userService)
	{
		_userManager = userManager;
		_signManager = signManager;
		_mapper = mapper;
		_logger = logger;
		_notyfService = notyfService;
		_userService = userService;
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
		{
			_notyfService.Error("Please correct the highlighted errors and try again.");
			return View(registerModel);
		}

		var userForRegistration = _mapper.Map<User>(registerModel);
		string? pictureName = default;

		if (registerModel.Picture?.Length > 0)
		{
			pictureName = Utility.UploadFile(registerModel.Picture, "Images");
		}

		userForRegistration.Picture = pictureName;

		var registerResult = await _userManager.CreateAsync(userForRegistration, registerModel.Password!);

		if (registerResult.Succeeded)
		{
			var claims = new List<Claim>
			{
				new (ClaimTypes.Email, userForRegistration.Email!),
				new (ClaimTypes.Name, registerModel.UserName!),
				new ("FullName", $"{registerModel.FirstName!} {registerModel.LastName!}"),
			};

			foreach (var claim in claims)
			{
				await _userManager.AddClaimAsync(userForRegistration, claim);
			}

			_notyfService.Success("Registration successful! You can now log in.");
			return RedirectToAction("Login");
		}

		foreach (var error in registerResult.Errors)
		{
			ModelState.AddModelError(string.Empty, error.Description);
		}

		_notyfService.Error("Registration failed. Please check the errors and try again.");
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
		{
			_notyfService.Error("Please correct the highlighted errors and try again.");
			return View(loginModel);
		}

		var userForAuthenticate = await _userManager.FindByEmailAsync(loginModel.Email);

		if (userForAuthenticate == null)
		{
			_notyfService.Error("Invalid credentials! Please try again.");
			return View(loginModel);
		}

		var loginResult = await _signManager.PasswordSignInAsync(
			user: userForAuthenticate,
			password: loginModel.Password,
			isPersistent: true,
			lockoutOnFailure: false);

		if (!loginResult.Succeeded)
		{
			_notyfService.Error("Login failed! Please check your credentials.");
			return View(loginModel);
		}

		var userClaims = await _userManager.GetClaimsAsync(userForAuthenticate);

		if (userClaims?.Count > 0)
		{
			var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				claimsPrincipal,
				new AuthenticationProperties
				{
					IsPersistent = true,
					ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
				});

			_notyfService.Success("Successfully logged in.");
			return RedirectToAction("Index", "Home");
		}

		return View(loginModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		foreach (var cookie in Request.Cookies.Keys)
		{
			Response.Cookies.Delete(cookie);
		}
		return RedirectToAction("Login");
	}

	[HttpGet]
	[Authorize]
	public async Task<IActionResult> Profile()
	{
		var loggedInUser = await _userManager.FindByEmailAsync(_userService.UserEmail);
		var mappedUserProfile = _mapper.Map<UserProfileVM>(loggedInUser);
		return View(mappedUserProfile);
	}


	[Authorize]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> SaveSettings(UserProfileVM userProfileVM)
	{
		if (!ModelState.IsValid)
		{
			return View(ModelState);
		}

		var currentUser = await _userManager.FindByEmailAsync(_userService.UserEmail);

		_mapper.Map(userProfileVM, currentUser);

		if (userProfileVM.ProfilePicture != null && userProfileVM.ProfilePicture.Length > 0)
		{
			Utility.DeleteFile(currentUser!.Picture!, "Images");
			currentUser.Picture = Utility.UploadFile(userProfileVM.ProfilePicture, "Images");
		}

		var updateResult = await _userManager.UpdateAsync(currentUser!);

		if (updateResult.Succeeded)
		{
			_notyfService.Success("Successfully updated.");
			return RedirectToAction(nameof(Profile));
		}

		foreach (var error in updateResult.Errors)
		{
			ModelState.AddModelError(string.Empty, error.Description);
		}

		_notyfService.Error("Please correct the highlighted errors and try again.");

		return View(userProfileVM);
	}
}
