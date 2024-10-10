using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class AppUserPictureUrlValueResolver :
	BaseUrlValueResolver,
	IValueResolver<User, UserProfileVM, string>
{
	private readonly IConfiguration _configuration;

	public AppUserPictureUrlValueResolver(
		IHttpContextAccessor contextAccessor,
		IConfiguration configuration) : base(contextAccessor)
		=> _configuration = configuration;

	public string Resolve(User source, UserProfileVM destination, string destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.Picture))
			return string.Empty;

		if (_contextAccessor.HttpContext!.Request.IsHttps)
			return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.Picture)}";

		return $"{_configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(source.Picture)}";
	}
}
