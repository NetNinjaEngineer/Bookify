using AutoMapper;
using Bookify.Entities;
using Bookify.Helpers;
using Bookify.ViewModels;

namespace Bookify.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookForCreateVM, Book>();
        CreateMap<Book, BookForListVM>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author!.FullName))
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre!.GenreName))
            .ForMember(dest => dest.PictureUrl, src => src.MapFrom<BookPictureUrlValueResolver>());
    }
}
