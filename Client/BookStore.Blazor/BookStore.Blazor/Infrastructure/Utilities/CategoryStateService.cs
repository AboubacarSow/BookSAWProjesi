using DTOs.CategoryDtos;

namespace BookStore.Blazor.Infrastructure.Utilities;

public class CategoryStateService
{
    private List<ResultCategoryDto> _categories = [];
    public event Action? OnCategoriesChanged;

    public List<ResultCategoryDto> Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnCategoriesChanged?.Invoke();
        }
    }
    public void SetCategories(List<ResultCategoryDto> categories)
    {
        Categories = categories;
    }
    public void AddCategory(ResultCategoryDto category)
    {
        category.CategoryId = _categories.Count > 0 ? _categories.Max(b => b.CategoryId) + 1 : 1; // Assign a new ID
        _categories.Add(category);
        var msg = $"{category.CategoryName} Kategorisi Başarıyla Eklenmiştir.";
        SetSuccessMessage(msg);
        OnCategoriesChanged?.Invoke();
    }
    public void RemoveCategory(int id)
    {
        var item = _categories.FirstOrDefault(b => b.CategoryId == id);
        if (item == null) return;
        _categories.Remove(item);
        var msg = $"Kategori ID {id} olan Başarıyla Silinmiştir.";
        SetSuccessMessage(msg);
        OnCategoriesChanged?.Invoke();
    }
    public void UpdateCategory(ResultCategoryDto category)
    {
        var index = _categories.FindIndex(b => b.CategoryId == category.CategoryId);
        if (index != -1)
        {
            _categories[index] = category;
            var msg = $"Kategori ID {index} olan Başarıyla Güncellenmiştir.";
            SetSuccessMessage(msg);
            OnCategoriesChanged?.Invoke();
        }
    }
    public string SuccessMessage { get; set; } = string.Empty;
    private void SetSuccessMessage(string message)
    {
        SuccessMessage = message;
        Task.Run(async () =>
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
