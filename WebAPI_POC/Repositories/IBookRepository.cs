using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI_POC.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Entities.Book>> GetBooksAsync();
        Task<Entities.Book> GetBookAsync(Guid id);
    }
}
