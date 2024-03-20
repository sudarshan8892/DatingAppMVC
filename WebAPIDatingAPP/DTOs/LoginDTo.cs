using System.ComponentModel.DataAnnotations;

namespace WebAPIDatingAPP.DTOs
{
    public class LoginDTo
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
