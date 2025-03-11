using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace Controllers.ConversationController {
    [ApiController]
    [Route("/conversation")]
    public class ConversationController : ControllerBase
    {
        public static List<Messages> Messages = new List<Messages>();

        private readonly ILogger<ConversationController> _logger;

        public ConversationController(ILogger<ConversationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/get", Name = "GetMessages")]
        public List<Messages> Get()
        {
            return Messages;
        }

        [HttpPost("/value", Name = "PostMessage")]
        public List<Messages> Post([FromBody] Messages message)
        {
            Messages.Add(message);
            Console.WriteLine(message);
            return Messages;
        }
    }
}
