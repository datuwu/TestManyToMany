using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManyToMany.Models;
using TestManyToMany.Service;

namespace TestManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Book book)
        {
            await _bookService.AddAsync(book);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _bookService.GetAsync());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Book book)
        {
            await _bookService.UpdateAsync(book);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _bookService.GetByIdAsync(id));
        }
    }
}
