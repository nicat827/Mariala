using Microsoft.AspNetCore.Identity;

namespace Mariala.Entities
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;
    }
}
