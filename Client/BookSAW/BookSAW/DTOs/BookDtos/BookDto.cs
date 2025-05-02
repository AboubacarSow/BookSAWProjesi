
namespace DTOs.BookDtos
{
    public record BookDto
    {
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
    }
}
