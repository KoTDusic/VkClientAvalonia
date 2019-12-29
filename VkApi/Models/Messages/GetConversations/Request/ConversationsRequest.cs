using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class ConversationsRequest
    {
        [DataMember(Name = "v")] public string ApiVersion { get; set; }
        [DataMember(Name = "access_token")] public string AccessToken { get; set; }
    }
}