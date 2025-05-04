using System.ComponentModel.DataAnnotations;

namespace DTOs.BookDtos;

public class UpdateBookDto
 {
    public int Id { get; set; }
    [Required(ErrorMessage = "Kitap adı gereklidir")]
    [MinLength(5, ErrorMessage = "Kitap adı en az 5 karakter içermelidir")]
    public string Name { get; set; } = string.Empty;

    [Range(100, 50000, ErrorMessage = "Kitap fiyatı 100 ile 50000 arasında olmalıdır")]
    [Required(ErrorMessage = "Fiyat belirtilmelidir")]

    public decimal Price { get; set; }
    [Required(ErrorMessage = "Kitap stoğu belirtilmelidir")]
    [Range(1, int.MaxValue, ErrorMessage = "Stok miktarı 1'den büyük olmalıdır")]

    public int Stock { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
    public int CategoryId { get; set; }
}
   

