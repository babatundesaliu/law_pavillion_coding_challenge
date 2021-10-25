using System;
using System.Text.Json.Serialization;

namespace login_service.DTOs
{
    public class AuthenticateResponse
    {        
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string JwtToken { get; set; }
    }
}