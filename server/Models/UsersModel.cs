using Models.ConversationsModel;
using Microsoft.AspNetCore.Identity;

namespace Models.UsersModel;

    public class Users : IdentityUser {
        public string Password { get; set; } // Used only during login
        public virtual ICollection<Conversations> Conversations { get; set; } 
        = new List<Conversations>();
    }