using Models.ConversationsModel;
using Models.UsersModel;
using Data;
using System.Runtime.CompilerServices;
using Models.MessagesModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
    // GetConversations takes the user Id as input
    public List<Conversations> GetConversations(string Id) {
        int val; 
        Int32.TryParse( Id, out val );
        var results = _context.Conversations.Where(conversation => conversation.UsersId == val).ToList();
        Console.WriteLine(results);
        _logger.LogInformation($"Successfully grabbed conversations for user: {Id}");
        return results;
    }
    public async Task<int> CreateConversations(Messages message, int userId) {
        Conversations conversation = new Conversations(userId);
        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();
        _logger.LogInformation($"Successfully created new conversation with message: {message}");
        return conversation.Id;
    }
}