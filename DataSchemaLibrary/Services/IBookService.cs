using System.Collections.Generic;
using System.Threading.Tasks;
using DataSchemaLibrary.Models;
using DataSchemaLibrary.Dtos;

namespace DataSchemaLibrary.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(CreateBookRequestDto bookDto);
        Task UpdateBook(int id, UpdateBookRequestDto bookDto);
        Task DeleteBook(int id);

    }
}
