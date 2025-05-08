using DTOs.CategoryDtos;
namespace DTOs.BookDtos
{
    public record ResultBookDto
    { 
        public int Id { get; set; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public ResultCategoryDto Category { get; init; }
    }


}
