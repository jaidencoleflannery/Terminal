using System;
using Models.Source;
using Models.Conversation;

namespace Models.Summmaries;

class Summary {
    public int id { get; set; };
    public string title { get; set; };
    public DateTime date { get; set; };
    public virtual ICollection<Source> source_id { get; set; } = new List<Source>();
    public virtual ICollection<Conversation> conversation_id { get; set; } = new List<Source>();
}