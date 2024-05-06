using System.Text.Json.Serialization;

namespace EmailSender.API.Domain.Entities
{
    public class TaskEntity
    {
        public TaskEntity() { }
        [JsonPropertyName("userId")]    
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
