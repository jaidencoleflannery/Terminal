using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.ConversationsService;
using Models.ConversationsModel;
using System.Security.Claims;
using Models.MessagesModel;
using Data;

namespace Controllers.ConversationController;
    [ApiController]
    [Route("/conversations")]
    [Authorize]
    public class ConversationController : ControllerBase {

        private readonly ApplicationDbContext _context;
        public static List<string> Messages = new List<string>();
        public static List<Conversations> Conversations = new List<Conversations>();
        private readonly ILogger<ConversationController> _logger;
        private readonly IConversationsService _conversationsService;
        public ConversationController(ILogger<ConversationController> logger, ApplicationDbContext context, IConversationsService conversationsService)
        {
            _logger = logger;
            _context = context;
            _conversationsService = conversationsService;
        }

        [HttpGet(Name = "GetConversations")]
        public List<Conversations> Get()
        {
            List<Conversations> conversations = _conversationsService.GetConversations(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return conversations;
        }

        [HttpPost("/reply", Name = "PostMessage")]
        public async Task<IActionResult> Post([FromBody] MessagesDto dto, [FromQuery] bool isNew = false)
        {
            if (!ModelState.IsValid) {
                _logger.LogInformation("/reply: Invalid payload.");
                return BadRequest(ModelState);
            }
            if(!isNew || dto.ConversationsId != 0) {
                 _logger.LogInformation("/reply: Adding to existing conversation.");
                var conversation = await _context.Conversations.FindAsync(dto.ConversationsId);
                if(conversation == null){
                    return NotFound($"Conversation {dto.ConversationsId} not found");
                }
                Messages message = new Messages { Value = dto.Value, ConversationsId = dto.ConversationsId };
                conversation.Messages.Add(message);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("PostMessage", new { id = message.Id }, message);
            } else {
                try{
                    _logger.LogInformation("/reply: Adding a new conversation.");
                    var conversation = await _conversationsService.CreateConversations(dto, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                    return CreatedAtRoute("PostMessage", new {id = conversation}, "conversation");
                }
                catch (Exception error) {
                    _logger.LogInformation("/reply: Error adding a new conversation.");
                    return StatusCode(500, $"Internal server error: {error.Message}");
                }
            }
        }
    }