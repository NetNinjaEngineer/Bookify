using AutoMapper;
using Bookify.Abstractions;
using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Services;

public class WishlistService : IWishlistService
{
	private readonly IGenericRepository<Wishlist> _wishlistRepository;
	private readonly IGenericRepository<Book> _bookRepository;
	private readonly UserManager<User> _userManager;
	private readonly IGenericRepository<WishlistItem> _wishlistItemsRepository;
	private readonly IUserService _userService;
	private readonly IMapper _mapper;
	private readonly IWishlistRepository _wishlistRepo;

	public WishlistService(
		IGenericRepository<Wishlist> wishlistRepository,
		IGenericRepository<Book> bookRepository,
		UserManager<User> userManager,
		IGenericRepository<WishlistItem> wishlistItemsRepository,
		IUserService userService,
		IMapper mapper,
		IWishlistRepository wishlistRepo)
	{
		_wishlistRepository = wishlistRepository;
		_bookRepository = bookRepository;
		_userManager = userManager;
		_wishlistItemsRepository = wishlistItemsRepository;
		_userService = userService;
		_mapper = mapper;
		_wishlistRepo = wishlistRepo;
	}

	public async Task<(Result<int>, bool)> AddProductToWishlistOrRemoveItAsync(int productId)
	{
		var authenticatedUserResult = await CheckIfUserIsAuthenticatedAsync(_userService.UserEmail);

		if (authenticatedUserResult.IsFailure)
			return (Result<int>.Fail(authenticatedUserResult.Error), false);

		var productExistsResult = await CheckIfProductExistsAsync(productId);

		if (productExistsResult.IsFailure)
			return (Result<int>.Fail(productExistsResult.Error), false);

		var specification = new GetWishlistByUserIdSpecification(authenticatedUserResult.Value.Id);

		var customerWishlist = await _wishlistRepository.GetEntityBySpecificationAsync(specification);

		// get the wishlist item
		var existedWishlistItem = await _wishlistItemsRepository.GetEntityBySpecificationAsync(new GetWishlistItemByProductIdSpecification(productId));

		if (existedWishlistItem is not null)
		{
			// remove from wishList
			await RemoveProductFromWishlist(productId);

			// get removed id
			return (Result<int>.Ok(existedWishlistItem.BookId), false);
		}

		WishlistItem wishlistItem;

		if (customerWishlist != null)
		{
			wishlistItem = AddWishlistItem(productExistsResult.Value, customerWishlist);

			return (Result<int>.Ok(wishlistItem.BookId), true);
		}

		var createdWishlistIdResult = await CreateUserWishlistAsync(_userService.UserEmail);

		if (createdWishlistIdResult.IsSuccess)
		{
			// creation success
			var createdWishlist = await _wishlistRepository.GetByIdAsync(createdWishlistIdResult.Value);

			// check creation if its null

			if (createdWishlist is null)
				return (Result<int>.Fail("Error while creating wishlist."), false);

			wishlistItem = AddWishlistItem(productExistsResult.Value, createdWishlist);

			createdWishlist.WishlistItems.Add(wishlistItem);

			await _wishlistRepository.CommitAsync();

			return (Result<int>.Ok(wishlistItem.BookId), true);
		}

		return (Result<int>.Fail("Error while creating wishlist."), false);

	}

	private WishlistItem AddWishlistItem(Book product, Wishlist customerWishlist)
	{
		WishlistItem wishlistItem = new()
		{
			DateAdded = DateTimeOffset.Now,
			WishlistId = customerWishlist.Id,
			BookId = product.Id,
		};

		_wishlistItemsRepository.Add(wishlistItem);
		return wishlistItem;
	}

	public async Task<Result<int>> CreateUserWishlistAsync(string customerEmail)
	{
		var user = await _userManager.FindByEmailAsync(customerEmail);
		if (user != null)
		{
			var userWishlist = new Wishlist { UserId = user.Id };
			_wishlistRepository.Add(userWishlist);
			return Result<int>.Ok(userWishlist.Id);
		}

		return Result<int>.Fail("User is not founded !!!");
	}

	public async Task<Result> RemoveProductFromWishlist(int productId)
	{
		var wishlistItemToRemove = await _wishlistItemsRepository.GetEntityBySpecificationAsync(
			new GetWishlistItemByProductIdSpecification(productId));

		if (wishlistItemToRemove is not null)
		{
			_wishlistItemsRepository.Delete(wishlistItemToRemove);

			return Result.Ok();
		}

		return Result.Fail("Wishlist Item is not found.");
	}

	private async Task<Result<User>> CheckIfUserIsAuthenticatedAsync(string customerEmail)
	{
		var customer = await _userManager.FindByEmailAsync(customerEmail);

		if (customer is null)
			return Result<User>.Fail("User is not authenticated.");

		return Result<User>.Ok(customer);
	}

	private async Task<Result<Book>> CheckIfProductExistsAsync(int productId)
	{
		var book = await _bookRepository.GetByIdAsync(productId);

		if (book is null)
			return Result<Book>.Fail($"Book with id '{productId}' was not found.");

		return Result<Book>.Ok(book);
	}

	public async Task<Result<WishlistForListVM>> GetUserWishlistAsync()
	{
		// check if user is authenticated 
		var currentUserResult = await CheckIfUserIsAuthenticatedAsync(_userService.UserEmail);

		if (currentUserResult.IsFailure)
			return Result<WishlistForListVM>.Fail(currentUserResult.Error);

		// get userWishlist
		var userWishlist = await _wishlistRepo.GetUserWishlistAsync(currentUserResult.Value.Id);

		if (userWishlist is null)
			return Result<WishlistForListVM>.Fail("Wishlist is not found.");

		var mappedUserWishlist = _mapper.Map<WishlistForListVM>(userWishlist);

		return Result<WishlistForListVM>.Ok(mappedUserWishlist);

	}

	public async Task<Result<int>> GetUserWishlistItemsCountAsync()
	{
		if (string.IsNullOrEmpty(_userService.UserEmail))
			return Result<int>.Fail("User email is not exists (Not Authenticated)");

		var authenticatedResult = await CheckIfUserIsAuthenticatedAsync(_userService.UserEmail);

		if (authenticatedResult.IsFailure)
			return Result<int>.Fail(authenticatedResult.Error);

		// get userWishlist
		var userWishlist = await _wishlistRepo.GetUserWishlistAsync(authenticatedResult.Value.Id);

		if (userWishlist is not null)
			return Result<int>.Ok(userWishlist.WishlistItems.Count);

		return Result<int>.Fail("Current User Not Have Wishlist Yet.");

	}
}
