using System;

namespace Models.conversation;

class Conversation {
    int id { get; set; }
    string instructions { get; set; }
    List<string> messages { get; set; }

    }