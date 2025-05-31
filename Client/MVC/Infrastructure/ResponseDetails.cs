namespace BookStore.Blazor.Infrastructure.Utilities;
public class ResponseDetails
{
    public bool IsSuccessed { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }

}