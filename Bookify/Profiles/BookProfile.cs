using AutoMapper;
using Bookify.Entities;
using Bookify.Views.ViewModels;

namespace Bookify.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookForCreateVM, Book>();
        CreateMap<Book, BookForListVM>()
            .ForMember(dest => dest.Author, src => src.MapFrom(x => x.Author!.FullName))
            .ForMember(dest => dest.Genre, src => src.MapFrom(x => x.Genre!.GenreName));
    }
}
