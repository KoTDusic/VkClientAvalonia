using System.Runtime.Serialization;

namespace VkApi
{
    [DataContract]
    public class AuthParams
    {
        [DataMember(Name = "grant_type")] public string GrantType { get; set; }
        [DataMember(Name = "client_id")] public string ClientId { get; set; }
        [DataMember(Name = "scope")] public string Permissions { get; set; }
        [DataMember(Name = "client_secret")] public string ClientSecret { get; set; }
        [DataMember(Name = "username")] public string Username { get; set; }
        [DataMember(Name = "password")] public string Password { get; set; }
        [DataMember(Name = "v")] public string ApiVersion { get; set; }
        [DataMember(Name = "2fa_supported")] public string TwoFactorAuthSupported { get; set; }
    }
}