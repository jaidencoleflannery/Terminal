namespace Models.RegistrationsModel;

public class Registrations {
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
}