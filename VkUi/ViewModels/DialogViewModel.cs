using ReactiveUI;
using VkApi.Messages.GetConversations;

namespace VkUi.ViewModels
{
    public class DialogViewModel:ReactiveObject
    {
        public DialogViewModel(Conversation conversation)
        {
            Id = conversation.ConversationData.PeerData.Id;
            Type = conversation.ConversationData.PeerData.Type;
            LastMessage = conversation.LastMessage.Text;
        }

        public string Id { get; }
        public string Type { get; }
        public string LastMessage { get; }
    }
}