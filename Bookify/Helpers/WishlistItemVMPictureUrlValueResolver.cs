using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class WishlistItemVMPictureUrlValueResolver : BaseUrlValueResolver, IValueResolver<WishlistItem, WishlistItemVM, string>
{
	private readonly IConfiguration _configuration;
	public WishlistItemVMPictureUrlValueResolver(
		IHttpContextAccessor contextAccessor, IConfiguration configuration) : base(contextAccessor)
	{
		_configuration = configuration;
	}

	public string Resolve(WishlistItem source, WishlistItemVM destination, string destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.Book.ImageName))
			return string.Empty;

		if (_contextAccessor.HttpContext!.Request.IsHttps)
			return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.Book.ImageName)}";

		return $"{_configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(source.Book.ImageName)}";
	}
}
