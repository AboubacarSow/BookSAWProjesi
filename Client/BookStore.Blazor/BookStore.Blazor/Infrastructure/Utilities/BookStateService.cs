using DTOs.BookDtos;

namespace BookStore.Blazor.Infrastructure.Utilities;

public class BookStateService
{
    private List<ResultBookDto> _books=[];
    public event Action? OnBooksChanged;

    public List<ResultBookDto> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnBooksChanged?.Invoke();
        }
    }
    public void SetBooks(List<ResultBookDto> books)
    {
        Books = books;
    }
    public void AddBook(ResultBookDto book)
    {
        book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1; // Assign a new ID
        _books.Add(book);
        var msg = $"Kitap {book.Name} başarıyla eklendi.";
        SetSuccessMessage(msg);
        OnBooksChanged?.Invoke();
    }
    public void RemoveBook(int id)
    {
        var item= _books.FirstOrDefault(b => b.Id == id);
        if (item == null) return;
        _books.Remove(item);
        var msg = $"Kitap {id} ID'si olan başarıyla silindi.";
        SetSuccessMessage(msg);
        OnBooksChanged?.Invoke();
    }
    public void UpdateBook(ResultBookDto book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index != -1)
        {
            _books[index] = book;
            OnBooksChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
         Task.Run( async () =>
            {
                await Task.Delay(5000);//5 seconds delay
                Reset();
            });
    }
    private void Reset()
    {
        SuccessMessage = string.Empty;
    }
}
