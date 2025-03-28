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

        public userController( ApplicationDbContext dbcontext) {
            _dbcontext = dbcontext;
        }

        //lookup usermanager and use that below

        [HttpPost("/newUser", Name = "NewUser")]
        public async Task<IActionResult> Post([FromBody] IdentityUser user)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _dbcontext.Set<IdentityUser>().AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtRoute("PostMessage", new { id = user.Id }, user);
        }
    }
}