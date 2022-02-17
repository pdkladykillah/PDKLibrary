using Microsoft.EntityFrameworkCore;
using PDKLibrary.Data;

namespace PDKLibrary.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PDKLibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PDKLibraryContext>>()))
            {
                if (context == null || context.Book == null)
                {
                    throw new ArgumentNullException("Null PDKLibraryContext");
                }

                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Author = "Edogawa Ratatata",
                        Available = true,
                        ReadingRate = "R"
                    },

                    new Book
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Author = "Uchihahahaha",
                        Available = false,
                        ReadingRate = "UR"
                    },

                    new Book
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Author = "I dont even know",
                        Available = true,
                        ReadingRate = "R"
                    },

                    new Book
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Author = "Tanjiro",
                        Available = true,
                        ReadingRate = "UR"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}