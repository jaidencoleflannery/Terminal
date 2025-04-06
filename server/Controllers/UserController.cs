using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Models.UsersModel;
using Models.ConversationsModel;
using Services.ConversationsService;
using Models.RegistrationsModel;
using Data;

namespace Controllers.UserController 
{
    [ApiController]
    [Route("/auth")]
    public class userController : ControllerBase {

        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<userController> _logger;
        private readonly ConversationsService _conversations;

        public userController(ILogger<userController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext dbcontext, ConversationsService conversations) {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbcontext = dbcontext;
            _logger = logger;
            _conversations = conversations;
        }

        [HttpPost("register", Name = "Register")]
        public async Task<IActionResult> Post([FromBody] Registrations dto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var userExists = await _userManager.FindByNameAsync(dto.Username);
            if (userExists != null) {
                return BadRequest("User already exists.");
            } else{
                var user = new IdentityUser { UserName = dto.Username };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded) {
                    return BadRequest(result.Errors);
                }
                return CreatedAtRoute("PostMessage", new { id = user.Id }, user);
            }
        }

        [HttpPost("login", Name = "Login")]
        public async Task<IActionResult> Post([FromBody] Users dto)
        {
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
            var userId = userInfo?.Id;
            if(userId != null) {
                var conversations = _conversations.getConversations(userId);
            } else {
                Console.WriteLine("No conversations found for user ", userInfo?.UserName);
            }

            return Ok("User logged in successfully.");
        }

        [HttpGet("check", Name = "Check")]
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