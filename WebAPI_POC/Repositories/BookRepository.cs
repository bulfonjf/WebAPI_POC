using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_POC.Contexts;
using WebAPI_POC.Entities;

namespace WebAPI_POC.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext booksContext;

        public BookRepository(BooksContext booksContext)
        {
            this.booksContext = booksContext;
        }

        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                throw new ArgumentNullException(nameof(bookToAdd));
            }

            booksContext.Add(bookToAdd);
        }

        public Task<Book> GetBookAsync(Guid id)
        {
            var result = booksContext.Books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult<Book>(result);
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            var result = booksContext.Books;
            return Task.FromResult<IEnumerable<Book>>(result);
        }

        public Task<IEnumerable<Book>> GetBooksAsync(IEnumerable<Guid> bookIds)
        {
            return Task.FromResult(booksContext.Books.Where(b => bookIds.Contains(b.Id)));
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await booksContext.SaveChangesAsync() > 0);
        }
    }
}
