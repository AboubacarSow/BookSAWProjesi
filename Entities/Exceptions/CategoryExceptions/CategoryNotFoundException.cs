namespace Entities.Exceptions.CategoryExceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(string Id) 
            : base($"Category with ID:{Id} could not found")
        {
        }
    }
}
