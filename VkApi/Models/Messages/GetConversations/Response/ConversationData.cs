using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class ConversationData
    {
        [DataMember(Name = "peer")] public PeerData PeerData { get; set; }
    }
}