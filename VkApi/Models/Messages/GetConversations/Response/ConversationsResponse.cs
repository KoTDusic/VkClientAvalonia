using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class ConversationsResponse
    {
        [DataMember(Name = "response")]
        public ConversationsResponseInternal Response { get; set; }
    }
    
    [DataContract]
    public class ConversationsResponseInternal
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "items")]
        public Conversation[] Items { get; set; }
    }
}