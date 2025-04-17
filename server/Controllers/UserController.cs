using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Services.ConversationsService;
using Models.RegistrationsModel;
using Models.UsersModel;

using Data;

namespace Controllers.UserController 
{
    [ApiController]
    [Route("/auth")]
    public class UserController : ControllerBase {

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IConversationsService _conversations;

        public UserController(ILogger<UserController> logger, UserManager<Users> userManager, SignInManager<Users> signInManager, ApplicationDbContext dbcontext, IConversationsService conversations) {
            _userManager = userManager;
            _signInManager = signInManager;
            _conversations = conversations;
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Post([FromBody] Registrations dto, bool registering) {
            if (!registering) {
                var result = await _signInManager.PasswordSignInAsync(
                    dto.Username,
                    dto.Password,
                    isPersistent: false,
                    lockoutOnFailure: false
                );
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(dto.Username);
                    var principal = await _signInManager.CreateUserPrincipalAsync(user);
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);
                } else {
                    return Unauthorized();
                }

                var userInfo = await _userManager.GetUserAsync(User);
                if(userInfo != null) {
                    var conversations = _conversations.GetConversations(userInfo.Id);
                } else {
                    Console.WriteLine("User Id not found");
                }

                return Ok("User logged in successfully.");
            } else {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }
                var userExists = await _userManager.FindByNameAsync(dto.Username);
                if (userExists != null) {
                    return BadRequest("User already exists.");
                } else{
                    var user = new Users { UserName = dto.Username };
                    var result = await _userManager.CreateAsync(user, dto.Password);
                    if (!result.Succeeded) {
                        return BadRequest(result.Errors);
                    }
                    return CreatedAtRoute("PostMessage", new { id = user.Id }, user);
                }
            }
        }

        [HttpGet(Name = "Check")]
        public async Task<IActionResult> Get()
        {
            if(HttpContext.User.Identity.IsAuthenticated == false) {
                return Unauthorized();
            } else {
                return Ok("Authenticated");
            }
        }
    }
}