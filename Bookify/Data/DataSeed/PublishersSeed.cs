using Bookify.Entities;

namespace Bookify.Data.DataSeed;

public static class PublishersSeed
{
    public static List<Publisher> LoadPublishers()
    {
        List<Publisher> publishers =
        [
            new Publisher { PublisherName = "O'Reilly Media" },
            new Publisher { PublisherName = "Apress" },
            new Publisher { PublisherName = "Microsoft Press" },
            new Publisher { PublisherName = "Manning Publications" },
            new Publisher { PublisherName = "Addison-Wesley" },
            new Publisher { PublisherName = "Packt Publishing" },
            new Publisher { PublisherName = "No Starch Press" },
            new Publisher { PublisherName = "Wiley" },
            new Publisher { PublisherName = "Prentice Hall" },
            new Publisher { PublisherName = "Peachpit Press" }
        ];

        return publishers;
    }
}
