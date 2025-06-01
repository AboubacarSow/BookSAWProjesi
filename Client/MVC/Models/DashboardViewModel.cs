using DTOs.BookDtos;
using DTOs.CategoryDtos;

namespace MVC.Models
{
    public class DashboardViewModel
    {
        public int TotalBook { get; set; }
        public int TotalCategory { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
        public List<ResultBookDto> FeaturedBook { get; set; }
    }
}
