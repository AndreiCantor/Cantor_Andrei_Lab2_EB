using Microsoft.EntityFrameworkCore;
using Cantor_Andrei_Lab2.Models;


namespace Cantor_Andrei_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }


                context.Author.AddRange(
                    new Author
                    {
                        FirstName = "Mihail",
                        LastName = "Sadoveanu",
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Calinescu",
                    },
                    new Author
                    {
                        FirstName = "Mircea",
                        LastName = "Eliade",
                    }
                    );
                context.Book.AddRange(
                new Book
                {
                    Title = "Baltagul",
                  //   Author = context.Author.Find(1),
                    Price = Decimal.Parse("22")
                },
                new Book
                {
                    Title = "Enigma Otiliei",
                    //Author = context.Authors.Find(2),
                    Price = Decimal.Parse("18")
                },
                new Book
                {
                    Title = "Maytrei",
                    //Author = context.Authors.Find(3),
                    Price = Decimal.Parse("27")
                }

                );

                context.Genre.AddRange(
               new Genre { Name = "Roman" },
               new Genre { Name = "Nuvela" },
               new Genre { Name = "Poezie" }
                );
                context.Customer.AddRange(
                new Customer
                {
                    Name = "Popescu Marcela",
                    Adress = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Adress = "Str. Bucuresti, nr. 45, ap. 2",
                    BirthDate = DateTime.Parse("1969 - 07 - 08")
                }
                );

                context.SaveChanges();
            }
        }
    }
}
