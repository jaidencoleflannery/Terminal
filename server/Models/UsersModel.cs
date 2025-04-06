namespace Models.UsersModel;

    public class Users {
        public int? Id { get; set; }
        public required string Username { get; set; }
        public string? Email { get; set; }
        public required string Password { get; set; }
    }