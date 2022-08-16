using JobPortal_API.Models;

namespace JobPortal_API.DTOs
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
