using Bookify.Entities;
using Bookify.Repository.Contracts;
using Bookify.Services.Contracts;
using Bookify.Specifications;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Services;

public class WishlistService : IWishlistService
{
	private readonly IGenericRepository<Wishlist> _wishlistRepository;
	private readonly IGenericRepository<Book> _bookRepository;
	private readonly UserManager<User> _userManager;
	private readonly IGenericRepository<WishlistItem> _wishlistItemsRepository;

	public WishlistService(
		IGenericRepository<Wishlist> wishlistRepository,
		IGenericRepository<Book> bookRepository,
		UserManager<User> userManager,
		IGenericRepository<WishlistItem> wishlistItemsRepository)
	{
		_wishlistRepository = wishlistRepository;
		_bookRepository = bookRepository;
		_userManager = userManager;
		_wishlistItemsRepository = wishlistItemsRepository;
	}

	public async Task<int> AddProductToWishlistOrRemoveItAsync(int productId, string customerEmail)
	{
		var customer = await _userManager.FindByEmailAsync(customerEmail)
			?? throw new ArgumentNullException(nameof(customerEmail));

		var product = await _bookRepository.GetByIdAsync(productId)
			?? throw new ArgumentNullException(nameof(productId));

		var specification = new GetWishlistByUserIdSpecification(customer.Id);

		var customerWishlist = await _wishlistRepository.GetEntityBySpecificationAsync(specification);

		// get the wishlist item
		var existedWishlistItem = await _wishlistItemsRepository.GetEntityBySpecificationAsync(new GetWishlistItemByProductIdSpecification(productId));

		if (existedWishlistItem is not null)
		{
			// remove from wishList
			await RemoveProductFromWishlist(productId);
			return productId;
		}

		WishlistItem wishlistItem;

		if (customerWishlist != null)
		{
			wishlistItem = new WishlistItem
			{
				DateAdded = DateTimeOffset.Now,
				WishlistId = customerWishlist.Id,
				BookId = product.Id,
			};


			_wishlistItemsRepository.Add(wishlistItem);

			return wishlistItem.Id;
		}

		var createdWishlist = await _wishlistRepository.GetByIdAsync(await CreateUserWishlistAsync(customerEmail));

		wishlistItem = new WishlistItem
		{
			DateAdded = DateTime.UtcNow,
			WishlistId = createdWishlist!.Id,
			BookId = product.Id,
		};

		createdWishlist!.WishlistItems.Add(wishlistItem);

		await _wishlistRepository.CommitAsync();

		return wishlistItem.BookId;
	}

	public async Task<int> CreateUserWishlistAsync(string customerEmail)
	{
		var user = await _userManager.FindByEmailAsync(customerEmail);
		if (user != null)
		{
			var userWishlist = new Wishlist { UserId = user.Id };
			_wishlistRepository.Add(userWishlist);
			return userWishlist.Id;
		}

		throw new ArgumentNullException("User is not founded !!!");
	}

	public async Task RemoveProductFromWishlist(int productId)
	{
		var wishlistItemToRemove = await _wishlistItemsRepository.GetEntityBySpecificationAsync(
			new GetWishlistItemByProductIdSpecification(productId));

		if (wishlistItemToRemove is not null)
			_wishlistItemsRepository.Delete(wishlistItemToRemove);
	}
}
