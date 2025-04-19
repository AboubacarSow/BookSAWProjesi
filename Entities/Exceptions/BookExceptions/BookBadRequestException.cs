namespace Entities.Exceptions.ProductExceptions
{
    public class BookBadRequestException : BadRequestException
    {
        public BookBadRequestException(string message) : base(message)
        {
        }
    }
}
