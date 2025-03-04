using System;
using Models;
using Data;

namespace Models {
    public class Summary {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Source> Source_Id { get; set; } = new List<Source>();
        public virtual ICollection<Message> Conversation_Id { get; set; } = new List<Message>();
    }
}