using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.ViewModels;

namespace Bookify.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<RegisterVM, User>();
		CreateMap<User, UserProfileVM>()
			.ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<AppUserPictureUrlValueResolver>());
	}
}
