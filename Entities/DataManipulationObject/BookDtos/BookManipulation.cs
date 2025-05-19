using System.ComponentModel.DataAnnotations;

namespace Entities.DataManipulationObject.ProductDtos
{
    public record BookManipulation
    {
        [Required(ErrorMessage ="Produt Name is required")]
        [MinLength(5,ErrorMessage ="Product Name must contain at least five 5 characters")]
        public required string Name { get; init; }
        [Range(100,50000,ErrorMessage ="Product's Price must be in the range of 100 and 50000")]
        [Required(ErrorMessage ="Price must be defined")]
        public decimal Price { get; init; }
        [Required(ErrorMessage ="Product Stock must be provided")]
        public int Stock { get; init; }
        public string ImageUrl { get; set; }
    }
}
