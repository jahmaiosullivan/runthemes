using System;
using System.Collections.Generic;
using System.Data.Common;
using NearForums.DataAccess;
using System.Data;

namespace NearForums.DataAccess
{
	public class UsersDataAccess : BaseDataAccess, IUsersDataAccess
	{
        public void AddEmail(Guid id, string email, EmailPolicy policy)
		{
			DbCommand comm = GetCommand("SPUsersUpdateEmail");
            comm.AddParameter<Guid>(this.Factory, "UserId", id);
			comm.AddParameter<string>(this.Factory, "UserEmail", email);
			comm.AddParameter(this.Factory, "UserEmailPolicy", DbType.Int32, (int)policy);

			comm.SafeExecuteNonQuery();
		}

		public User AddUser(User user, AuthenticationProvider provider, string providerId)
		{
			DbCommand comm = GetCommand("SPUsersInsertFromProvider");
			comm.AddParameter<string>(this.Factory, "UserName", user.UserName);
			comm.AddParameter<string>(this.Factory, "UserProfile", user.Profile);
			comm.AddParameter<string>(this.Factory, "UserSignature", user.Signature);
			comm.AddParameter<short>(this.Factory, "UserGroupId", (short)user.Role);
			comm.AddParameter(this.Factory, "UserBirthDate", DbType.DateTime, user.BirthDate);
			comm.AddParameter<string>(this.Factory, "UserWebsite", user.Website);
			comm.AddParameter<Guid>(this.Factory, "UserGuid", Guid.NewGuid());
			comm.AddParameter<decimal>(this.Factory, "UserTimezone", (decimal)user.TimeZone.TotalHours);
			comm.AddParameter(this.Factory, "UserEmail", DbType.String, string.IsNullOrWhiteSpace(user.Email) ? null : user.Email);
			comm.AddParameter(this.Factory, "UserEmailPolicy", DbType.Int32, null);
			comm.AddParameter<string>(this.Factory, "UserPhoto", user.Photo);
			comm.AddParameter<string>(this.Factory, "UserExternalProfileUrl", user.ExternalProfileUrl);
			comm.AddParameter<string>(this.Factory, "UserProvider", provider.ToString().ToUpper());
			comm.AddParameter<string>(this.Factory, "UserProviderId", providerId.ToUpper());

			DataRow dr = GetFirstRow(comm);
			user = ParseUserLoginInfo(dr);

			return user;
		}

        public bool Ban(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText)
		{
			var comm = GetCommand("SPUsersBan");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);
            comm.AddParameter<Guid>(this.Factory, "ModeratorUserId", id);
			comm.AddParameter<ModeratorReason>(this.Factory, "ModeratorReason", reason);
			comm.AddParameter<string>(this.Factory, "ModeratorReasonFull", reasonText);

			return comm.SafeExecuteNonQuery() > 0;
		}

		public void Delete(Guid id)
		{
			DbCommand comm = GetCommand("SPUsersDelete");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);

			comm.SafeExecuteNonQuery();
		}

		/// <summary>
		/// Assigns the previous (down) user role to the user
		/// </summary>
		/// <param name="id"></param>
        public void Demote(Guid id)
		{
			DbCommand comm = GetCommand("SPUsersDemote");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);

			comm.SafeExecuteNonQuery();
		}

		public void Edit(User user)
		{
			DbCommand comm = GetCommand("SPUsersUpdate");
            comm.AddParameter<Guid>(this.Factory, "UserId", user.Id);
			comm.AddParameter<string>(this.Factory, "UserName", user.UserName);
			comm.AddParameter<string>(this.Factory, "UserProfile", user.Profile);
			comm.AddParameter<string>(this.Factory, "UserSignature", user.Signature);
			comm.AddParameter(this.Factory, "UserBirthDate", DbType.DateTime, user.BirthDate);
			comm.AddParameter<string>(this.Factory, "UserWebsite", user.Website);
			comm.AddParameter<decimal>(this.Factory, "UserTimezone", (decimal)user.TimeZone.TotalHours);
			comm.AddParameter(this.Factory, "UserEmail", DbType.String, user.Email);
			comm.AddParameter(this.Factory, "UserEmailPolicy", DbType.Int32, (int)user.EmailPolicy);
			comm.AddParameter<string>(this.Factory, "UserPhoto", user.Photo);
			comm.AddParameter<string>(this.Factory, "UserExternalProfileUrl", user.ExternalProfileUrl);

			comm.SafeExecuteNonQuery();
		}

        public User Get(Guid userId)
		{
			User user = null;
			var comm = GetCommand("SPUsersGet");
            comm.AddParameter<Guid>(this.Factory, "UserId", userId);

			var dr = GetFirstRow(comm);
			if (dr != null)
			{
				user = ParseUserInfo(dr);
				user.ExternalProfileUrl = dr.GetString("UserExternalProfileUrl");
				user.Email = dr.GetString("UserEmail");
				user.EmailPolicy = (EmailPolicy)(dr.GetNullable<int?>("UserEmailPolicy") ?? (int)EmailPolicy.None);
				user.Photo = dr.GetString("UserPhoto");
				user.Website = dr.GetString("UserWebsite");
				user.BirthDate = dr.GetNullableStruct<DateTime>("UserBirthDate");
				user.Warned = (!dr.IsNull("WarningStart")) && dr.GetNullableStruct<bool>("WarningRead") != true;
				user.Suspended = (!dr.IsNull("SuspendedStart")) && (dr.IsNull("SuspendedEnd") || dr.GetNullableStruct<DateTime>("SuspendedEnd") >= DateTime.UtcNow);
				user.Banned = !dr.IsNull("BannedStart");
				user.SuspendedEnd = dr.GetNullableStruct<DateTime>("SuspendedEnd");
				user.ModeratorReason = dr.GetNullableStruct<ModeratorReason>("ModeratorReason");
				user.ModeratorReasonMessage = dr.GetString("ModeratorReasonFull");
			}
			return user;
		}

		public List<User> GetAll()
		{
			DbCommand comm = GetCommand("SPUsersGetAll");
			DataTable dt = GetTable(comm);

			List<User> users = new List<User>();
			foreach (DataRow dr in dt.Rows)
			{
				User u = ParseUserInfo(dr);
				users.Add(u);
			}
			return users;
		}

		public List<User> GetByName(string userName)
		{
			DbCommand comm = GetCommand("SPUsersGetByName");
			comm.AddParameter<string>(this.Factory, "UserName", userName);
			DataTable dt = GetTable(comm);

			List<User> users = new List<User>();
			foreach (DataRow dr in dt.Rows)
			{
				User u = ParseUserInfo(dr);
				users.Add(u);
			}
			return users;
		}

		public User GetByPasswordResetGuid(AuthenticationProvider provider, string PasswordResetGuid)
		{
			User user = null;

			DbCommand command = GetCommand("SPUsersGetByPasswordResetGuid");
			command.AddParameter<string>(this.Factory, "Provider", provider.ToString().ToUpper());
			command.AddParameter<string>(this.Factory, "PasswordResetGuid", PasswordResetGuid);

			DataRow dr = GetFirstRow(command);
			if (dr != null)
			{
				user = ParseUserLoginInfo(dr);
				user.PasswordResetGuid = dr.GetString("PasswordResetGuid");
				user.PasswordResetGuidExpireDate = dr.GetDate("PasswordResetGuidExpireDate");
			}
			return user;
		}

		public User GetByProviderId(AuthenticationProvider provider, string providerId)
		{
			User user = null;

			DbCommand command = GetCommand("SPUsersGetByProvider");
			command.AddParameter<string>(this.Factory, "Provider", provider.ToString().ToUpper());
			command.AddParameter<string>(this.Factory, "ProviderId", providerId);

			DataRow dr = GetFirstRow(command);
			if (dr != null)
			{
				user = ParseUserLoginInfo(dr);
			}
			return user;
		}

		/// <summary>
		/// Gets the name of the user role
		/// </summary>
		/// <returns></returns>
		public string GetRoleName(UserRole userRole)
		{
			string result = null;
			var comm = GetCommand("SPUsersGroupsGet");
			comm.AddParameter<short>(this.Factory, "UserGroupId", (short)userRole);

			DataRow dr = GetFirstRow(comm);
			if (dr != null)
			{
				result = dr.GetString("UserGroupName");
			}
			return result;
		}

		/// <summary>
		/// Gets a dictionary containing the user roles and its names.
		/// </summary>
		/// <returns></returns>
		public Dictionary<UserRole, string> GetRoles()
		{
			var comm = GetCommand("SPUsersGroupsGetAll");
			var dt = GetTable(comm);
			var roles = new Dictionary<UserRole, string>();
			foreach (DataRow dr in dt.Rows)
			{
				roles.Add(dr.Get<UserRole>("UserGroupId"), dr.GetString("UserGroupName"));
			}
			return roles;
		}

		public User GetTestUser()
		{
			User user = null;

			DbCommand command = GetCommand("SPUsersGetTestUser");

			DataRow dr = GetFirstRow(command);
			if (dr != null)
			{
				user = ParseUserLoginInfo(dr);
			}
			return user;
		}

		#region Parse user
		protected virtual User ParseUserInfo(DataRow dr)
		{
			User user = new User();
            user.Id = dr.Get<Guid>("UserId");
			user.UserName = dr.GetString("UserName");
			user.Role = dr.Get<UserRole>("UserGroupId");
			user.RoleName = dr.GetString("UserGroupName");
			user.RegistrationDate = dr.GetDate("UserRegistrationDate");

			decimal offSet = dr.Get<decimal>("UserTimeZone");
			user.TimeZone = new TimeSpan((long)(offSet * (decimal)TimeSpan.TicksPerHour));

			return user;
		}

		/// <summary>
		/// Converts a user data row into a app user entity
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
		protected virtual User ParseUserLoginInfo(DataRow dr)
		{
			var user = new User();
            user.Id = dr.Get<Guid>("UserId");
			user.UserName = dr.GetString("UserName");
			user.Role = dr.Get<UserRole>("UserGroupId");
			user.Guid = dr.Get<Guid>("UserGuid");
			user.ExternalProfileUrl = dr.GetString("UserExternalProfileUrl");
			user.ProviderLastCall = dr.GetDate("UserProviderLastCall");
			user.Email = dr.GetString("UserEmail");
			decimal offSet = dr.Get<decimal>("UserTimeZone");
			user.TimeZone = new TimeSpan((long)(offSet * (decimal)TimeSpan.TicksPerHour));
			if (dr.Table.Columns.Contains("WarningStart"))
			{
				user.Warned = (!dr.IsNull("WarningStart")) && dr.GetNullableStruct<bool>("WarningRead") != true;
				user.Suspended = (!dr.IsNull("SuspendedStart")) && (dr.IsNull("SuspendedEnd") || dr.GetNullableStruct<DateTime>("SuspendedEnd") >= DateTime.UtcNow);
				user.Banned = !dr.IsNull("BannedStart");
				user.SuspendedEnd = dr.GetNullableStruct<DateTime>("SuspendedEnd");
			}

			return user;
		}
		#endregion


		/// <summary>
		/// Assigns the next (up) user role to the user
		/// </summary>
		/// <param name="id"></param>
        public void Promote(Guid id)
		{
			DbCommand comm = GetCommand("SPUsersPromote");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);

			comm.SafeExecuteNonQuery();
		}

        public bool Suspend(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText, DateTime endDate)
		{
			var comm = GetCommand("SPUsersSuspend");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);
            comm.AddParameter<Guid>(this.Factory, "ModeratorUserId", id);
			comm.AddParameter<ModeratorReason>(this.Factory, "ModeratorReason", reason);
			comm.AddParameter<string>(this.Factory, "ModeratorReasonFull", reasonText);
			comm.AddParameter<DateTime>(this.Factory, "SuspendedEnd", endDate);

			return comm.SafeExecuteNonQuery() > 0;
		}

		public void UpdatePasswordResetGuid(Guid id, string Guid, DateTime expireDate)
		{
			DbCommand comm = GetCommand("SPUsersUpdatePasswordResetGuid");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);
			comm.AddParameter<string>(this.Factory, "PasswordResetGuid", Guid);
			comm.AddParameter(this.Factory, "PasswordResetGuidExpireDate", DbType.DateTime, expireDate);

			comm.SafeExecuteNonQuery();
		}

        public bool Warn(Guid id, Guid moderatorId, ModeratorReason reason, string reasonText)
		{
			var comm = GetCommand("SPUsersWarn");
			comm.AddParameter<Guid>(this.Factory, "UserId", id);
            comm.AddParameter<Guid>(this.Factory, "ModeratorUserId", id);
			comm.AddParameter<ModeratorReason>(this.Factory, "ModeratorReason", reason);
			comm.AddParameter<string>(this.Factory, "ModeratorReasonFull", reasonText);

			return comm.SafeExecuteNonQuery() > 0;
		}

        public bool WarnDismiss(Guid id)
		{
			var comm = GetCommand("SPUsersWarnDismiss");
            comm.AddParameter<Guid>(this.Factory, "UserId", id);

			return comm.SafeExecuteNonQuery() > 0;
		}
	}
}
