using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Data;

namespace ScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournalContext>>()))
            {
                if (context == null || context.Scripture == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = 3,
                        Verse = 7,
                        Note = "The Lord will provide a way",
                        AddDate = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "Moses",
                        Chapter = 1,
                        Verse = 39,
                        Note = "God's purpose",
                        AddDate = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "John",
                        Chapter = 3,
                        Verse = 5,
                        Note = "Everybody must be baptized",
                        AddDate = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "D&C",
                        Chapter = 88,
                        Verse = 124,
                        Note = "Word of wisdom regarding to work",
                        AddDate = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
