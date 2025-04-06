using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.ConversationsModel;
using Models.MessagesModel;
using Data;
using Services.ConversationsService;

namespace Controllers.ConversationController;
    [ApiController]
    [Route("/conversation")]
    [Authorize]
    public class ConversationController : ControllerBase
    {

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

        [HttpPost("/get", Name = "GetConversation")]
        public List<string> Get()
        {
            Console.WriteLine(Messages);
            return Messages;
        }

        [HttpPost("/message", Name = "PostMessage")]
        public async Task<IActionResult> Post([FromBody] Messages message, bool isNew)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if(!isNew) {
                var conversation = await _context.Conversations.FindAsync(message.conversationId);
                if(conversation == null){
                    return NotFound($"Conversation {message.conversationId} not found");
                }
                conversation.Messages.Add(message);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("PostMessage", new { id = message.Id }, message);
            } else {
                var conversation = _conversationsService.CreateConversations(message);
                return CreatedAtRoute("PostMessage", new {id = conversation}, "conversation");
            }
        }
    }