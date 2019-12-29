using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class Conversation
    {
        [DataMember(Name = "conversation")] public ConversationData ConversationData { get; set; }
        [DataMember(Name = "last_message")] public LastMessageData LastMessage { get; set; }
    }
}