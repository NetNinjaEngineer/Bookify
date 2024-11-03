using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class ReviewPictureUrlValueResolver :
	BaseUrlValueResolver,
	IValueResolver<Review, ReviewListViewModel, string>
{
	private readonly IConfiguration _configuration;

	public ReviewPictureUrlValueResolver(
		IHttpContextAccessor contextAccessor,
		IConfiguration configuration) : base(contextAccessor)
		=> _configuration = configuration;

	public string Resolve(Review source, ReviewListViewModel destination, string destMember, ResolutionContext context)
	{
		if (string.IsNullOrEmpty(source.ReviewerPictureName))
			return string.Empty;

		if (_contextAccessor.HttpContext!.Request.IsHttps)
			return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.ReviewerPictureName)}";

		return $"{_configuration["FullbackUrl"]}/Files/Images/{Uri.EscapeDataString(source.ReviewerPictureName)}";
	}
}
