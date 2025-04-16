using Models.ConversationsModel;
using Models.MessagesModel;

namespace Services.ConversationsService;
    public interface IConversationsService
    {
        public List<Conversations> GetConversations(string userId);
        public Task<int> CreateConversations(MessagesDto message, string userId);
    }