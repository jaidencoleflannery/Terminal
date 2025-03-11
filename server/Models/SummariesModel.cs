using System;
using Models;
using Data;

namespace Models {
    public class Summaries {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Sources> Source_Id { get; set; } = new List<Sources>();
        public virtual ICollection<Messages> Conversation_Id { get; set; } = new List<Messages>();
    }
}