using DTOs.CategoryDtos;
namespace DTOs.BookDtos
{
    public record ResultBookDto
    { 
        public int Id { get; set; }
        public string Name { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public string Description { get; init; }
        public string Author { get; set; }
        public int Stock { get; init; }
        public ResultCategoryDto Category { get; init; }
    }


}
