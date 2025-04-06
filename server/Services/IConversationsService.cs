using Models.ConversationsModel;
using System.Collections.Generic;

namespace Services.ConversationsService;
    public interface IConversationsService
    {
        public List<Conversations> getConversations(string id);
    }