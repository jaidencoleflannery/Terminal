using Models.ConversationsModel;
using Microsoft.AspNetCore.Identity;

namespace Models.UsersModel;

    public class Users : IdentityUser {
        public required string Password { get; set; }
        public virtual ICollection<Conversations> Conversations { get; set; } 
        = new List<Conversations>();
    }