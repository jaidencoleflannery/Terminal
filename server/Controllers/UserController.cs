using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.UserController {
    [ApiController]
    [Route("/user")]
    public class userController : ControllerBase {

        private readonly IUserService _userService;

        public userController( IUserService userService ) {
            _userService = userService;
        }

        [HttpPost("/getUser", Name = "GetUser")]
        public string GetUser() {
            Console.WriteLine("Getting user");
            string user = _userService.GetUser();
            return user;
        }
    }


}