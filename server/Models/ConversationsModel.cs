using Microsoft.AspNetCore.Components.Web;

namespace Models.ConversationsModel;
    public class Conversations {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Sources> Sources { get; set; } = new List<Sources>();
        public virtual ICollection<Sources> Messages { get; set; } = new List<Sources>();
    }