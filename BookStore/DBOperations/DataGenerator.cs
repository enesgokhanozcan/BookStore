using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {  
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Brave New World",
                        GenreId = 1,
                        PageCount = 250,
                        PublisDate = new DateTime(2021, 01, 01)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Homo Deus: A Brief History of Tomorrow",
                        GenreId = 2,
                        PageCount = 300,
                        PublisDate = new DateTime(2021, 01, 01)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 700,
                        PublisDate = new DateTime(2021, 01, 01)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
