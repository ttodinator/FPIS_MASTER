﻿using Microsoft.AspNetCore.Identity;

namespace FPIS.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? CellphoneNumber { get; set; }

        public string? UserEmail { get; set; }

        public List<AppUserRole> UserRoles { get; set; }
    }
}
