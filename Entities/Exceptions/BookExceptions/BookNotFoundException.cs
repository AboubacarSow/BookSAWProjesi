namespace Entities.Exceptions.ProductExceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(string id) :
            base($"Book with Id: {id} is not found")
        {
        }
    }
}
