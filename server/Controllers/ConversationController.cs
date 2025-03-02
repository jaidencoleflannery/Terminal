using Microsoft.AspNetCore.Mvc;

namespace Controllers.ConversationController;

[ApiController]
[Route("/conversation")]
public class ConversationController : ControllerBase
{
    private static string[] Messages = new[];

    private readonly ILogger<ConversationController> _logger;

    public ConversationController(ILogger<ConversationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "GetConversation")]
    public IEnumerable<Messages> Get()
    {
        return Messages;
    }

    [HttpPost(Name = "GetConversation")]
    public IEnumerable<Messages> Get()
    {
        return Messages;
    }
}
