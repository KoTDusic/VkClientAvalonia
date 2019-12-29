using System.Threading.Tasks;
using VkApi.Messages.GetConversations;

namespace VkApi
{
    public interface IVkRequestSender
    {
        Task<bool> Auth(string login, string password);
        Task<ConversationsResponse> GetDialogs();
    }
}