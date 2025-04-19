namespace Entities.Exceptions.ProductExceptions
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException(string message) : base(message)
        {
        }
    }
}
