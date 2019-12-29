using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class PeerData
    {
        [DataMember(Name = "Id")] public string Id { get; set; }
        [DataMember(Name = "type")] public string Type { get; set; }
        [DataMember(Name = "local_id")] public string LocalId { get; set; }
    }
}