using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Shared;
using VkApi.Messages.GetConversations;
using RestRequest = RestSharp.RestRequest;

namespace VkApi
{
    public class VkRequestSender:IVkRequestSender
    {
        private readonly IRestClient _authClient;
        private readonly IRestClient _workClient;
        private const string AuthUri = "/token";
        private const string DialogsUri = "/messages.getConversations";
        
        private const string ClientSecret = "AlVXZFMUqyrnABp8ncuU";
        private const string ClientId = "3697615";
        private const string ApiVersion = "5.103";
        private const string GrantType = "password";
        private const string Permissions = "messages,offline";
        private string _token;
        
        
        public VkRequestSender(IRestClient authClient, IRestClient workClient)
        {
            _authClient = authClient ?? throw new ArgumentException();
            _workClient = workClient ?? throw new ArgumentException();;
        }
        
        public async Task<bool> Auth(string login, string password)
        {
            var request = new RestRequest(AuthUri);
            request.AddParamsToRequestFromJson(new AuthParams
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                GrantType = GrantType,
                ApiVersion = ApiVersion,
                Password = password,
                Username = login,
                Permissions = Permissions,
                TwoFactorAuthSupported = "1"
            });
            var response = await _authClient.ExecuteGetTaskAsync(request).ConfigureAwait(false);
            var responseData = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
            _token = responseData.AccessToken;
            if (_token != null)
            {
                return true;
            }

            return false;
        }

        public async Task<ConversationsResponse> GetDialogs()
        {
            var request = new RestRequest(DialogsUri);
            request.AddParamsToRequestFromJson(new ConversationsRequest
            {
                AccessToken = _token,
                ApiVersion = ApiVersion
            });
            var response = await _workClient.ExecuteGetTaskAsync(request).ConfigureAwait(false);
            var responseData = JsonConvert.DeserializeObject<ConversationsResponse>(response.Content);
            return responseData;
        }
    }
}