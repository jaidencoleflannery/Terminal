using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace Controllers.ConversationController {
    [ApiController]
    [Route("/conversation")]
    public class ConversationController : ControllerBase
    {
        public static List<Message> Messages = new List<Message>();

        private readonly ILogger<ConversationController> _logger;

        public ConversationController(ILogger<ConversationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/get", Name = "GetMessages")]
        public List<Message> Get()
        {
            return Messages;
        }

        [HttpPost("/value", Name = "PostMessage")]
        public List<Message> Post([FromBody] Message message)
        {
            Messages.Add(message);
            Console.WriteLine(message);
            return Messages;
        }
    }
}
