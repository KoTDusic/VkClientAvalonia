using System.Runtime.Serialization;

namespace VkApi
{
    [DataContract]
    public class AuthResponse
    {
        [DataMember(Name = "access_token", IsRequired = false)]
        public string AccessToken { get; set; }

        [DataMember(Name = "user_id", IsRequired = false)]
        public string UserId { get; set; }

        [DataMember(Name = "expires_in", IsRequired = false)]
        public string ExpiresIn { get; set; }

        [DataMember(Name = "error", IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "error_type", IsRequired = false)]
        public string ErrorType { get; set; }

        [DataMember(Name = "error_description", IsRequired = false)]
        public string ErrorDescription { get; set; }

        [DataMember(Name = "captcha_sid", IsRequired = false)]
        public string CaptchaSid { get; set; }

        [DataMember(Name = "captcha_img", IsRequired = false)]
        public string CaptchaImg { get; set; }
    }
}