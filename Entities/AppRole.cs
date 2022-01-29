using Microsoft.AspNetCore.Identity;

namespace FPIS.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public List<AppUserRole> UserRoles { get; set; }
    }
}
