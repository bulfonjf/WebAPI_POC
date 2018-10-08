using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_POC.Repositories;

namespace WebAPI_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var booksEntities = await bookRepository.GetBooksAsync();
            return Ok(booksEntities);
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(Guid id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
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
