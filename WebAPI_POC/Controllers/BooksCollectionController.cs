using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI_POC.Binders;
using WebAPI_POC.Models;
using WebAPI_POC.Repositories;

namespace WebAPI_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksCollectionController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper _mapper;

        public BooksCollectionController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({bookIds})", Name = "GetBookCollection")]
        public async Task<IActionResult> Get([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> bookIds)
        {
            var bookEntities = await bookRepository.GetBooksAsync(bookIds);

            if (bookIds.Count() != bookEntities.Count())
            {
                return NotFound();
            }

            var booksModel = _mapper.Map<IEnumerable<Models.Book>>(bookEntities);

            return Ok(bookEntities);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<BookForCreation> bookCollection)
        {
            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var book in bookEntities)
            {
                bookRepository.AddBook(book);
            }

            await bookRepository.SaveChangesAsync();

            var booksToreturn = await bookRepository.GetBooksAsync(bookEntities.Select(b => b.Id));

            var bookIds = string.Join(",", booksToreturn.Select(a => a.Id));

            return CreatedAtRoute("GetBookCollection", new { bookIds }, booksToreturn);
        }
    }
}