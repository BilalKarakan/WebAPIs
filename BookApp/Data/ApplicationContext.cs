using BookApp.Models;

namespace BookApp.Data
{
    public class ApplicationContext
    {
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book {Id = 1, Title = "Middlemarch", Price = 150},
                new Book {Id = 2, Title = "Jane Eyre", Price = 110},
                new Book {Id = 3, Title = "Pride and Prejudice", Price = 80}
            };

        }
    }
}
