﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WhiteLabel.Web.ViewModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
        public string About { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Location { get; set; }
        public string DisplayName { get; set; }
        public DateTime? UserRegistrationDate { get; set; }
        public Guid PasswordResetGuid { get; set; }
        public DateTime? PasswordResetExpireDate { get; set; }
        public DateTime? WarningStart { get; set; }
        public bool WarningRead { get; set; }
        public DateTime? SuspendedStart { get; set; }
        public DateTime? SuspendedEnd { get; set; }
        public DateTime? BannedStart { get; set; }
        public int UserEmailPolicy { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}