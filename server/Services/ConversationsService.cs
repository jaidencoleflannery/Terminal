using Models.ConversationsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Models.MessagesModel;
using Data;

namespace Services.ConversationsService;
public class ConversationsService : IConversationsService {
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ConversationsService> _logger;
    public ConversationsService(ApplicationDbContext context, ILogger<ConversationsService> logger) {
        _context = context;
        _logger = logger;
    }
    public List<Conversations> GetConversations(string userId) {
        List<Conversations> results = _context.Conversations
            .Include(conversation => conversation.Messages)
            .Where(conversation => conversation.UsersId == userId)
            .ToList();
        _logger.LogInformation($"Successfully grabbed conversations for user: {userId}");
        return results;
    }
    public async Task<int> CreateConversations(MessagesDto dto, string userId) {
        Messages message = new Messages { Value = dto.Value };
        Conversations conversation = new Conversations(userId, message);
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Successfully created new conversation with message: {message}");
        return conversation.Id;
    }
}