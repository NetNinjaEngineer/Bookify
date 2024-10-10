using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class BookPictureUrlValueResolver :
	BaseUrlValueResolver,
	IValueResolver<Book, BookForListVM, string?>
{
	private readonly IConfiguration _configuration;

	public BookPictureUrlValueResolver(
		IHttpContextAccessor contextAccessor,
		IConfiguration configuration) : base(contextAccessor)
		=> _configuration = configuration;

	public string Resolve(Book source, BookForListVM destination, string? destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.ImageName))
			return string.Empty;

		if (_contextAccessor.HttpContext!.Request.IsHttps)
			return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.ImageName)}";

		return $"{_configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(source.ImageName)}";
	}
}
