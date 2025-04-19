using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
