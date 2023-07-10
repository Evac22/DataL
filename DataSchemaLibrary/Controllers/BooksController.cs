using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using DataSchemaLibrary.Dtos;
using DataSchemaLibrary.Models;
using DataSchemaLibrary.Services;
using DataSchemaLibrary.DataAccess;

namespace DataSchemaLibrary.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataSchemaLibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BooksController(DataSchemaLibraryDbContext context, IMapper mapper, IBookService bookService)
        {
            _context = context;
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            var books = await _context.Books.ToListAsync();
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Ok(bookDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookRequestDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var createdBookDto = _mapper.Map<BookDto>(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBookDto.Id }, createdBookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookRequestDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            _mapper.Map(bookDto, book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }

    

    
}
