using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI_POC.Models;
using WebAPI_POC.Repositories;

namespace WebAPI_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var booksEntities = await bookRepository.GetBooksAsync();

            var booksModel = _mapper.Map(booksEntities, new List<Models.Book>());

            return Ok(booksEntities);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bookEntity = await bookRepository.GetBookAsync(id);

            var bookModel = _mapper.Map(bookEntity, new Models.Book());

            return Ok(bookModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookForCreation bookToAdd)
        {
            var bookEntity = _mapper.Map<Entities.Book>(bookToAdd);

            bookRepository.AddBook(bookEntity);

            await bookRepository.SaveChangesAsync();

            return CreatedAtRoute("Get", new { id = bookEntity.Id }, bookEntity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
