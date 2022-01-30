using System;
using System.Collections.Generic;
using FPIS.Entities._1_Identifikacija_novih_klijenata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FPIS.Entities
{
    public class Context :IdentityDbContext<AppUser, AppRole, int,
                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Delatnost> Delatnost { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            this.SeedUsers(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                            Database=FPIS_NASTER");
        }

        
        private void SeedRoles(ModelBuilder builder)  
        {  
            builder.Entity<IdentityRole<int>>().HasData(  
                new IdentityRole() {  Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },  
                new IdentityRole() {  Name = "BasicUser", ConcurrencyStamp = "2", NormalizedName = "Basic User" }  
                );  
        }

        private void SeedUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = 1,
                Name = "Petar",
                Surname = "Todic",
                UserName = "admin1",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
            };
            user.PasswordHash = new PasswordHasher<AppUser>().HashPassword(user, "P@$$w0rd");

            builder.Entity<AppUser>().HasData(user);
        }
    }

}
