using AutoMapper;
using Bookify.Entities;
using Bookify.ViewModels;

namespace Bookify.Helpers;

public class BookPictureUrlValueResolver : IValueResolver<Book, BookForListVM, string?>
{
    private readonly IConfiguration _configuration;

    public BookPictureUrlValueResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Book source, BookForListVM destination, string? destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.ImageName))
            return string.Empty;

        return $"{_configuration["BaseUrl"]}/Files/Images/{Uri.EscapeDataString(source.ImageName)}";
    }
}
