namespace Entities.Exceptions.CategoryExceptions
{
    public sealed class CategoryBadRequestException : BadRequestException
    {
        public CategoryBadRequestException(string message) : base(message)
        {
        }
    }
}
