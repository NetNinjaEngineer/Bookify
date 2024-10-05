using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterVM, User>();
    }
}
