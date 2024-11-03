using Bookify.Entities;
using Bookify.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Bookify.Services;

public class UserService : IUserService
{
	private readonly IHttpContextAccessor _contextAccessor;
	private readonly UserManager<User> _userManager;
	private readonly IConfiguration _configuration;

	public UserService(IHttpContextAccessor contextAccessor,
					UserManager<User> userManager,
					IConfiguration configuration)
	{
		_contextAccessor = contextAccessor;
		_userManager = userManager;
		_configuration = configuration;
	}

	public string UserEmail => _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;

	public async Task<string> GetLoggedInUserPictureName()
	{
		var loggedInUser = await _userManager.FindByEmailAsync(UserEmail);
		return loggedInUser?.Picture!;
	}

	public async Task<string> GetUserProfilePath()
	{
		var loggedInUser = await _userManager.FindByEmailAsync(UserEmail);
		string profileImagePath = string.Empty;

		if (_contextAccessor.HttpContext!.Request.IsHttps)
			profileImagePath = $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(loggedInUser!.Picture)}";
		else
			profileImagePath = $"{_configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(loggedInUser!.Picture)}";

		return profileImagePath;

	}
}
