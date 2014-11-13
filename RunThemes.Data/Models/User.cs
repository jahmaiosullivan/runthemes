using System;
using System.Security.Principal;
using RunThemes.Common.Attributes;

namespace RunThemes.Data.Models
{
    public class User : IPrincipal
    {
        [PrimaryKey]
        public string Id { get; set; }

        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string TwoFactorEnabled { get; set; }
        public string SecurityStamp { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string About { get; set; }
        public bool IsInRole(string role)
        {
            return false;
        }

        public IIdentity Identity { get; set; }
    }
}
