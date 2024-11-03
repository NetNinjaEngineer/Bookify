using AspNetCoreHero.ToastNotification.Abstractions;
using Bookify.Services.Contracts;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;
[Authorize]
public class ReviewsController : Controller
{
	private readonly IUserService _userService;
	private readonly IReviewsService _reviewsService;
	private readonly INotyfService _notyfService;
	public ReviewsController(IUserService userService, IReviewsService reviewsService, INotyfService notyfService)
	{
		_userService = userService;
		_reviewsService = reviewsService;
		_notyfService = notyfService;
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> CreateOrUpdateReview([FromForm] CreateReviewViewModel createReviewViewModel)
	{
		var createOrUpdateReviewResult = await _reviewsService.CreateOrUpdateReviewAsync(createReviewViewModel);

		if (createOrUpdateReviewResult.IsSuccess)
		{
			_notyfService.Success(createOrUpdateReviewResult.Value);

			return RedirectToAction("Details", "Books", new { id = createReviewViewModel.BookId });
		}

		_notyfService.Error("Failed to submit the review.");

		return RedirectToAction("Details", "Books", new { id = createReviewViewModel.BookId });
	}
}
