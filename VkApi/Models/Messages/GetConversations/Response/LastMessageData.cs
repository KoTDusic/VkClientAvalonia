using System.Runtime.Serialization;

namespace VkApi.Messages.GetConversations
{
    [DataContract]
    public class LastMessageData
    {
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}