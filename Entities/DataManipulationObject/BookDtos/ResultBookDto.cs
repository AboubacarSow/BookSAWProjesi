using Entities.DataManipulationObject.CategoryDtos;

namespace Entities.DataManipulationObject.ProductDtos
{
    public record ResultBookDto
    { 
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public string ImageUrl { get; init; }
        public ResultCategoryDto Category { get; init; }
    }


}
