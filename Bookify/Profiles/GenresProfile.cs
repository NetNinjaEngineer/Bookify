using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Profiles;

public class GenresProfile : Profile
{
    public GenresProfile()
    {
        CreateMap<Genre, GenreForListVM>();
    }
}