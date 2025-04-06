using Microsoft.AspNetCore.Components.Web;
using Models.MessagesModel;

namespace Models.ConversationsModel;
    public class Conversations {
        public Conversations() {}
        public Conversations(Messages message, int UserId) {
            Messages.Add(message);
            this.UserId = UserId;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Sources> Sources { get; set; } = new List<Sources>();
        public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();
    }