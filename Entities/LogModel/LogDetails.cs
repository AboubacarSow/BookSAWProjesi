using System.Text.Json;

namespace Entities.LogModel
{
    public class LogDetails
    {
        public string? ModelName { get; set; }
        public object? Action { get; set; }
        public object? Controller { get; set; }
        public object? CreateAt { get; set; } = DateTimeOffset.UtcNow;
        public object? Id { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
