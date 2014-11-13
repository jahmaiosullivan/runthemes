using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NearForums;

namespace NearForums.DataAccess
{
	/// <summary>
	/// Represents the repository for the user
	/// </summary>
	public interface IUsersDataAccess
	{
        void AddEmail(Guid id, string email, EmailPolicy policy);
		User AddUser(User user, AuthenticationProvider provider, string providerId);
        bool Ban(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText);
		void Delete(Guid id);
        void Demote(Guid id);
		void Edit(User user);
        User Get(Guid userId);
		List<User> GetAll();
		List<User> GetByName(string userName);
		User GetByPasswordResetGuid(AuthenticationProvider provider, string PasswordResetGuid);
		User GetByProviderId(AuthenticationProvider provider, string providerId);
		string GetRoleName(UserRole userRole);
		System.Collections.Generic.Dictionary<UserRole, string> GetRoles();
		User GetTestUser();
        void Promote(Guid id);
        bool Suspend(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText, DateTime endDate);
		void UpdatePasswordResetGuid(Guid id, string Guid, DateTime expireDate);
        bool Warn(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText);
		/// <summary>
		/// Stores on the repository that the warning was read.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        bool WarnDismiss(Guid id);
	}
}
