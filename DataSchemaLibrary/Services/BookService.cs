using AutoMapper;
using DataSchemaLibrary.DataAccess;
using DataSchemaLibrary.Dtos;
using DataSchemaLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataSchemaLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly DataSchemaLibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookService(DataSchemaLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<Book> CreateBook(CreateBookRequestDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task UpdateBook(int id, UpdateBookRequestDto bookDto)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _mapper.Map(bookDto, book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
