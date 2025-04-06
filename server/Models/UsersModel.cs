using Models.ConversationsModel;

namespace Models.UsersModel;

    public class Users {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
        public virtual ICollection<Conversations> Conversations { get; set; } 
        = new List<Conversations>();
    }

    // YOU NEED TO WRAP THIS INTO IDENTITY USER FOR LITERALLY ANYTHING TO WORK