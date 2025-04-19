namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 40;

        public int PageNumber { get; set; } = 1;


        public int PageSize { get; set; } = maxPageSize;
       
        
    }
}
