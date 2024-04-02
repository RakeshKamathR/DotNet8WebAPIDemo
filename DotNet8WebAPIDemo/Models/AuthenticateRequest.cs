using System.ComponentModel;

namespace DotNet8WebAPIDemo.Models
{
    public class AuthenticateRequest
    {
        [DefaultValue("System")]
        public required string Username { get; set; }

        [DefaultValue("System")]
        public required string Password { get; set; }
    }
}
