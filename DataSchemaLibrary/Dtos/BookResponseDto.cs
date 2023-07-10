using DataSchemaLibrary.Models;

namespace DataSchemaLibrary.Dtos
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int Year { get; set; }
    }
}
