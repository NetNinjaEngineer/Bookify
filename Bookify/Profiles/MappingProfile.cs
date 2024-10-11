﻿using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.ViewModels;

namespace Bookify.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<BookForCreateVM, Book>();

		CreateMap<Book, BookForListVM>()
			.ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author!.FullName))
			.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre!.GenreName))
			.ForMember(dest => dest.PictureUrl, src => src.MapFrom<BookPictureUrlValueResolver>());

		CreateMap<Genre, GenreForListVM>();

		CreateMap<RegisterVM, User>();

		CreateMap<User, UserProfileVM>()
			.ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<AppUserPictureUrlValueResolver>());

		CreateMap<WishlistItem, WishlistItemVM>()
			.ForMember(dest => dest.ProductId, options => options.MapFrom(src => src.BookId))
			.ForMember(dest => dest.ProductName, options => options.MapFrom(src => src.Book.Title))
			.ForMember(dest => dest.ProductImageUrl, options => options.MapFrom<WishlistItemVMPictureUrlValueResolver>());

		CreateMap<Wishlist, WishlistForListVM>()
			.ForMember(dest => dest.WishlistId, options => options.MapFrom(src => src.Id))
			.ForMember(dest => dest.WishlistItemVMs, options => options.MapFrom(src => src.WishlistItems));

	}
}