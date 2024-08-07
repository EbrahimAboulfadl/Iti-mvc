using Microsoft.AspNetCore.Identity;

namespace Assignment.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string  Address { get; set; }
    }
}
