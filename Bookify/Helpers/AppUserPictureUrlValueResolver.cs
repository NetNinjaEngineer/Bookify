using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class AppUserPictureUrlValueResolver : IValueResolver<User, UserProfileVM, string>
{
	private readonly IConfiguration _configuration;

	public AppUserPictureUrlValueResolver(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string Resolve(User source, UserProfileVM destination, string destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.Picture))
			return string.Empty;

		return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.Picture)}";
	}
}
