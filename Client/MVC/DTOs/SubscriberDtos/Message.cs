using System.Text.Json.Serialization;

namespace MVC.DTOs.SubscriberDtos;

public class Message
{
    [JsonPropertyName("Body")]
    public string Body { get; set;}
    [JsonPropertyName("Subject")]
    public string Subject { get; set;}
    [JsonPropertyName("Email")]
    public string Email {  get; set;}   
}
