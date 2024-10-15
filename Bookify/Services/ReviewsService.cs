using AutoMapper;
using Bookify.Abstractions;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Services;

public class ReviewsService(
	IGenericRepository<Review> reviewsRepository,
	IGenericRepository<Book> bookRepository,
	UserManager<User> userManager,
	IMapper mapper) : IReviewsService
{
	public async Task<Result<string>> CreateOrUpdateReviewAsync(CreateReviewViewModel createReviewViewModel)
	{
		// validations
		var existedUser = await userManager.FindByEmailAsync(createReviewViewModel.UserEmail);
		if (existedUser is null)
			return Result<string>.Fail("User is not authenticated.");

		var existedProduct = await bookRepository.GetByIdAsync(createReviewViewModel.BookId);

		if (existedProduct is null)
			return Result<string>.Fail("Book is not found.");

		var specification = new GetExistedReviewWithUserAndProductSpecification(existedUser.Id, existedProduct.Id);

		var existedReview = await reviewsRepository.GetEntityBySpecificationAsync(specification);

		if (existedReview is not null)
		{
			// update the review
			existedReview.RatingValue = createReviewViewModel.RatingValue;
			existedReview.ReviewDescription = createReviewViewModel.ReviewDescription;
			existedReview.ReviewerName = createReviewViewModel.ReviewerName;
			existedReview.CreatedAt = DateTimeOffset.Now;
			existedReview.ReviewerPictureName = createReviewViewModel.ReviewerPictureName;

			reviewsRepository.Update(existedReview);

			return Result<string>.Ok("Review Updated successfully.");
		}
		else
		{
			// Create new review
			var review = new Review
			{
				ReviewerName = createReviewViewModel.ReviewerName,
				ReviewDescription = createReviewViewModel.ReviewDescription,
				RatingValue = createReviewViewModel.RatingValue,
				BookId = createReviewViewModel.BookId,
				UserId = existedUser.Id,
				CreatedAt = DateTimeOffset.Now,
				ReviewerPictureName = createReviewViewModel.ReviewerPictureName
			};

			reviewsRepository.Add(review);

			return Result<string>.Ok("Review Created successfully.");
		}
	}

	public async Task<Result<IEnumerable<ReviewListViewModel>>> GetAllReviewsAsync()
	{
		var allReviews = await reviewsRepository.GetAllAsync();
		var mappedReviews = mapper.Map<IEnumerable<ReviewListViewModel>>(allReviews);
		return Result<IEnumerable<ReviewListViewModel>>.Ok(mappedReviews);
	}

	public async Task<Result<double>> GetAverageRatingForBookAsync(int bookId)
	{
		var specification = new GetSingleBookWithRelatedDataSpecification(bookId);

		var book = await bookRepository.GetEntityBySpecificationAsync(specification);

		if (book == null || !book.Reviews.Any())
		{
			return Result<double>.Ok(0); // No reviews available
		}

		var averageRating = book.Reviews.Average(r => r.RatingValue);
		return Result<double>.Ok(Math.Round(averageRating, 1));
	}

	public async Task<Result<IEnumerable<ReviewListViewModel>>> GetReviewsAsync(int productId)
	{
		var Specification = new GetReviewsForExistedProductSpecification(productId);
		var productReviews = await reviewsRepository.GetAllWithSpecificationAsync(Specification);
		var mappedReviews = mapper.Map<IEnumerable<ReviewListViewModel>>(productReviews);
		return Result<IEnumerable<ReviewListViewModel>>.Ok(mappedReviews);
	}
}
