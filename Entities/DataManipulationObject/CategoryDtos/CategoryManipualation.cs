using System.ComponentModel.DataAnnotations;

namespace Entities.DataManipulationObject.CategoryDtos
{
    public record CategoryManipualation
    {
        [Required(ErrorMessage ="Category Name field is required")]
        public  string CategoryName { get; init; }
    }
}
