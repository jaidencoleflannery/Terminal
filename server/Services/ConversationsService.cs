using Models.ConversationsModel;
using Models.UsersModel;
using Data;
using System.Runtime.CompilerServices;
using Models.MessagesModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace Services.ConversationsService;
public class ConversationsService : IConversationsService {
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ConversationsService> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly HttpContextAccessor _httpContextAccessor;
    public ConversationsService(ApplicationDbContext context, ILogger<ConversationsService> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, HttpContextAccessor httpContextAccessor) {
        _context = context;
        _logger = logger;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public List<Conversations> GetConversations(string Id) {
        int val; 
        Int32.TryParse( Id, out val );
        var results = _context.Conversations.Where(conversation => conversation.UserId == val).ToList();
        Console.WriteLine(results);
        _logger.LogInformation($"Successfully grabbed conversations for user: {Id}");
        return results;
    }
    public void CreateConversations(Messages message, IdentityUser userInfo) {
        Conversations conversation = new Conversations(message, Int32.Parse(userInfo?.Id));
        _context.Users.Conversations.Add(conversation);
        _context.SaveChangesAsync();
        _logger.LogInformation($"Successfully created new conversation with message: {message}");
        // this needs to return the conversation id somehow so the frontend knows what to send on its next request
    }
}