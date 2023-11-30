using System;
namespace LineService.Application.Models
{
	public class OauthResponse
	{
	
	}

    public class VerifyIdTokenModel
    {
        public string? iss { get; set; }
        public string? sub { get; set; }
        public string? aud { get; set; }
        public long exp { get; set; }
        public long iat { get; set; }
        public List<string>? amr { get; set; }
        public string? name { get; set; }
        public string? picture { get; set; }
    }
}

