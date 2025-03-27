namespace Services;

public interface IUserService {
    public void GetUser();
}

public class UserService : IUserService {
    public void GetUser() {
        Console.WriteLine("Getting user");
    }
}