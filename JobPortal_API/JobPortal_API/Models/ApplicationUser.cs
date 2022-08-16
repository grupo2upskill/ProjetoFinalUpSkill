using Microsoft.EntityFrameworkCore;



namespace JobPortal_API.Models
{
    [Keyless]
    public class ApplicationUser
    {
        public string Name { get; set; }
        
    }
}
