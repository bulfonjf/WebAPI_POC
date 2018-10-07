using System;
using System.Collections.Generic;
using WebAPI_POC.Entities;

namespace WebAPI_POC.Contexts
{
    public class BooksContext
    {
        public List<Book> Books { get; private set; }

        public BooksContext()
        {
            SetInitialData();
        }

        protected void SetInitialData()
        {
            Books = new List<Book>
            {
                new Book()
                {
                    Title = "White Fang",
                    Author = new Author()
                    {
                        FirstName = "Jack",
                        LastName = "London",
                        Id = Guid.Parse("f42e2fdf-adcb-4207-9597-c7b5c28c9414")
                    },
                    AuthorId = Guid.Parse("f42e2fdf-adcb-4207-9597-c7b5c28c9414"),
                    Description = "",
                    Id = Guid.Parse("65331762-e546-4c07-8fa6-9bb9e86b8fcf")
                },
                new Book()
                {
                    Title = "Agile software development",
                    Author = new Author()
                    {
                        FirstName = "Robert C.",
                        LastName = "Martin",
                        Id = Guid.Parse("7f4a3fbf-bc40-4d47-a7d6-3440a9a6d6cf")
                    },
                    AuthorId = Guid.Parse("7f4a3fbf-bc40-4d47-a7d6-3440a9a6d6cf"),
                    Description = "",
                    Id = Guid.Parse("b8e4d2c6-5765-4af7-974c-50c799819927")
                }
            };
        }
    }
}
