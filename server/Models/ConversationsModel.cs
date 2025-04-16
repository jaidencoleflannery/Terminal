using Microsoft.AspNetCore.Components.Web;
using Models.UsersModel;
using Models.MessagesModel;

namespace Models.ConversationsModel;
    public class Conversations {
        public Conversations() {}
        public Conversations(string UsersId, Messages Message) {
            this.UsersId = UsersId;
            Messages.Add(Message);
        }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Sources> Sources { get; set; } = new List<Sources>();
        public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();

        public string UsersId { get; set; }
        public Users Users { get; set; }
    }