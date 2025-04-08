using Models.ConversationsModel;
using Models.MessagesModel;
using System.Collections.Generic;

namespace Services.ConversationsService;
    public interface IConversationsService
    {
        public List<Conversations> GetConversations(string id);
        public Task<int> CreateConversations(Messages message, int userId);
    }