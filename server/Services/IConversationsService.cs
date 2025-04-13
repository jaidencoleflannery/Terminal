using Models.ConversationsModel;
using Models.MessagesModel;
using System.Collections.Generic;

namespace Services.ConversationsService;
    public interface IConversationsService
    {
        public List<Conversations> GetConversations(string userId);
        Task<int> CreateConversations(Messages message, string userId);
    }