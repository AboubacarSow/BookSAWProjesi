using System.Text.Json;

namespace Entities.ErrorModels
{
    public class ErrorDetails
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
