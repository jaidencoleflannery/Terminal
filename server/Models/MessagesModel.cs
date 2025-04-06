namespace Models.MessagesModel;
    public class Messages {
        public int Id { get; set; }
        public int conversationId { get; set; }
        public required string Value { get; set; }
    }