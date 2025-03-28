using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using Data;

namespace Controllers.UserController {
    [ApiController]
    [Route("/auth")]
    public class userController : ControllerBase {

        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public userController(UserManager<IdentityUser> userManager, ApplicationDbContext dbcontext) {
            _userManager = userManager;
            _dbcontext = dbcontext;
        }


        [HttpPost("/register", Name = "Register")]
        public async Task<IActionResult> Post([FromBody] Registrations dto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var userExists = await _userManager.FindByNameAsync(dto.UserName);
            if (userExists != null) {
                return BadRequest("User already exists.");
            } else{
                var user = new IdentityUser { UserName = dto.UserName };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded) {
                    return BadRequest(result.Errors);
                }
                return CreatedAtRoute("PostMessage", new { id = user.Id }, user);
            }
        }
    }
}