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
        public DateTime? UserRegistrationDate { get; set; }
        public Guid PasswordResetGuid { get; set; }
        public DateTime? PasswordResetExpireDate { get; set; }
        public DateTime? WarningStart { get; set; }
        public bool WarningRead { get; set; }
        public DateTime? SuspendedStart { get; set; }
        public DateTime? SuspendedEnd { get; set; }
        public DateTime? BannedStart { get; set; }
        public bool Suspended
        {
            get
            {
                return (SuspendedStart.HasValue) && (!SuspendedEnd.HasValue || SuspendedEnd.Value >= DateTime.UtcNow);
            }
        }

        public bool Warned
        {
            get { return WarningStart.HasValue && WarningRead != true; }
        }

        public bool Banned
        {
            get { return BannedStart.HasValue; }
        }

        public int UserEmailPolicy { get; set; }
        public bool IsInRole(string role)
        {
            return false;
        }

        public string RoleName { get; set; }

        public IIdentity Identity { get; set; }

        public bool AllowChangeEmail { get; set; }

    }
}
