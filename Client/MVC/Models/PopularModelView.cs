using DTOs.BookDtos;
using DTOs.CategoryDtos;

namespace MVC.Models
{
    public class PopularModelView
    {
        public List<ResultBookDto> Books { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}
