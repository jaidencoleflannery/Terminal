using System;
using Models;
using Data;

namespace Models {
    public class Summaries {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Instructions { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Sources> Sources { get; set; } = new List<Sources>();
        public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();
    }
}