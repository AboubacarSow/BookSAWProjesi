namespace Entities.RequestFeatures
{
    public class BookParameters : RequestParameters
    {
        public uint MinPrice { get; set; } = 50;
        public uint MaxPrice { get; set; } = 50000;
        public bool ValidPriceRang => MaxPrice > MinPrice;

    }
}
