using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace Controllers.ConversationController {
    [ApiController]
    [Route("/conversation")]
    public class ConversationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public static List<Messages> Messages = new List<Messages>();
        public static List<Summaries> Summaries = new List<Summaries>();

        private readonly ILogger<ConversationController> _logger;

        public ConversationController(ILogger<ConversationController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("/get", Name = "GetConversation")]
        public List<Messages> Get()
        {
            Console.WriteLine(Messages);
            return Messages;
        }

        [HttpPost("/value", Name = "PostMessage")]
        public async Task<IActionResult> Post([FromBody] Messages message)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("PostMessage", new { id = message.Id }, message);
        }

        [HttpPost("/summary", Name = "PostSummary")]
        public async Task<IActionResult> Post([FromBody] Summaries summary)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _context.Summaries.AddAsync(summary);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("PostMessage", new { id = summary.Id, userid = summary.UserId, title = summary.Title, instruction = summary.Instructions});
        }
    }
}
