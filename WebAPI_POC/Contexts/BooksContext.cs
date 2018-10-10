using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_POC.Entities;

namespace WebAPI_POC.Contexts
{
    public class BooksContext
    {
        public List<Book> Books { get; private set; }
        public List<Author> Authors { get; private set; }

        public BooksContext()
        {
            SetInitialData();
        }

        protected void SetInitialData()
        {
            if (Authors == null || !Authors.Any())
            {
                Authors = new List<Author>()
                {
                    new Author()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Id = Guid.Parse("f42e2fdf-adcb-4207-9597-c7b5c28c9414")
                        },
                     new Author()
                        {
                            FirstName = "Robert C.",
                            LastName = "Martin",
                            Id = Guid.Parse("7f4a3fbf-bc40-4d47-a7d6-3440a9a6d6cf")
                        }
                };
            }

            if (Books == null || !Books.Any())
            {
                Books = new List<Book>
                {
                    new Book()
                    {
                        Title = "White Fang",
                        AuthorId = Guid.Parse("f42e2fdf-adcb-4207-9597-c7b5c28c9414"),
                        Description = "",
                        Id = Guid.Parse("65331762-e546-4c07-8fa6-9bb9e86b8fcf")
                    },
                    new Book()
                    {
                        Title = "Agile software development",
                        AuthorId = Guid.Parse("7f4a3fbf-bc40-4d47-a7d6-3440a9a6d6cf"),
                        Description = "",
                        Id = Guid.Parse("b8e4d2c6-5765-4af7-974c-50c799819927")
                    }
                };

                Books[0].Author = Authors.FirstOrDefault(a => a.Id == Books[0].AuthorId);
                Books[1].Author = Authors.FirstOrDefault(a => a.Id == Books[1].AuthorId);
            }
        }

        internal Task<int> SaveChangesAsync()
        {
            try
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    var book = Books[i];
                    if (book.Id == Guid.Empty)
                    {
                        book.Id = Guid.NewGuid();
                    }
                    if (book.AuthorId != Guid.Empty && book.Author == null)
                    {
                        book.Author = Authors.FirstOrDefault(a => a.Id == book.AuthorId);
                    }
                }

                return Task.FromResult(1);
            }
            catch (Exception)
            {

                return Task.FromResult(0);
            }
        }

        internal void Add(Book bookToAdd)
        {
            Books.Add(bookToAdd);
        }
    }
}
