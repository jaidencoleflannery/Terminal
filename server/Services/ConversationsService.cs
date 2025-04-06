using Models.ConversationsModel;
using Data;
using System.Runtime.CompilerServices;

namespace Services.ConversationsService;
public class ConversationsService : IConversationsService {
    private readonly ApplicationDbContext _context;
    public ConversationsService(ApplicationDbContext context) {
        _context = context;
    }
    public List<Conversations> getConversations(string Id) {
        int val; 
        Int32.TryParse( Id, out val );
        var results = _context.Conversations.Where(conversation => conversation.UserId == val).ToList();
        Console.WriteLine(results);
        return results;
    }
}