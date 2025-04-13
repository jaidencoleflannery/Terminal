using Models.ConversationsModel;

namespace Models.MessagesModel;
    public class Messages {
        public int Id { get; set; }
        public required string Value { get; set; }
        public int ConversationsId { get; set; }
    }