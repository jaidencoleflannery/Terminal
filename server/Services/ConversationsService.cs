using Models.ConversationsModel;
using Data;
using Models.MessagesModel;
using Microsoft.AspNetCore.Identity;

namespace Services.ConversationsService;
public class ConversationsService : IConversationsService {
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ConversationsService> _logger;
    public ConversationsService(ApplicationDbContext context, ILogger<ConversationsService> logger) {
        _context = context;
        _logger = logger;
    }
    public List<Conversations> GetConversations(string userId) {
        var results = _context.Conversations.Where(conversation => conversation.UsersId == userId).ToList();
        Console.WriteLine(results);
        _logger.LogInformation($"Successfully grabbed conversations for user: {userId}");
        return results;
    }
    public async Task<int> CreateConversations(Messages message, string userId) {
        Conversations conversation = new Conversations(userId);
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Successfully created new conversation with message: {message}");
        return conversation.Id;
    }
}