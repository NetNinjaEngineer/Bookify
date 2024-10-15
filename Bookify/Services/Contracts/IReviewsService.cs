using Bookify.Abstractions;
using Bookify.ViewModels;

namespace Bookify.Services.Contracts;

public interface IReviewsService
{
	Task<Result<string>> CreateOrUpdateReviewAsync(CreateReviewViewModel createReviewViewModel);

	Task<Result<IEnumerable<ReviewListViewModel>>> GetReviewsAsync(int productId);

	Task<Result<double>> GetAverageRatingForBookAsync(int bookId);

	Task<Result<IEnumerable<ReviewListViewModel>>> GetAllReviewsAsync();

}
