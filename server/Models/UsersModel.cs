namespace Models;

    public class Users {
        public required string Username { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
    }