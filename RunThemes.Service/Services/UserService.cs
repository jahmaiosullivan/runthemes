using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NearForums;
using RunThemes.Business.Providers;
using RunThemes.Data.Repositories;
using User = RunThemes.Data.Models.User;

namespace RunThemes.Business.Services
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// Add the email address to the user profile.
        /// </summary>
        /// <exception cref="ValidationException"></exception>
        void AddEmail(Guid id, string email, EmailPolicy policy);
        /// <summary>
        /// Tries to authenticate against the custom provider. If success, it gets or creates an application user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ValidationException">Throws a ValidationException when userName and/or password are empty</exception>
        User AuthenticateWithCustomProvider(string userName, string password);
        /// <summary>
        /// Bans a user
        /// </summary>
        /// <param name="id">Id of the user to ban</param>
        /// <param name="moderatorId">UserId of the moderator</param>
        /// <param name="moderatorRole">Role of the user trying to moderate</param>
        /// <param name="reason"></param>
        /// <param name="reasonText"></param>
        /// <returns>True if the user was banned</returns>
        bool Ban(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText);

        /// <summary>
        /// Determines if a user can moderate (warn,suspend,ban) and manage (promote/demote) another user
        /// </summary>
        /// <param name="moderatorUser"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CanModerate(User moderatorUser, User user);
        /// <summary>
        /// Removes the user from the repository
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
        /// <summary>
        /// Assigns the previous (down) user group to the user
        /// </summary>
        void Demote(Guid id);
        void Edit(User user);
         User GetByPasswordResetGuid(AuthenticationProvider provider, string passwordResetGuid);
        /// <summary>
        /// Gets a dictionary containing the user roles and its names.
        /// </summary>
        /// <returns></returns>
        Dictionary<UserRole, string> GetRoles();
        bool IsThereAnyUser();
        /// <summary>
        /// Assigns the next (up) user group to the user
        /// </summary>
        void Promote(Guid id);
        /// <summary>
        /// Updates the user's password reset temporary Guid used for password reset purposes and sends an email to the user
        /// </summary>
        /// <param name="membershipKey"></param>
        /// <param name="guid"></param>
        /// <param name="linkUrl">Url of the page to set the new password</param>
        void ResetPassword(string membershipKey, string guid, string linkUrl);
        /// <summary>
        /// Temporarily suspends a user
        /// </summary>
        /// <param name="id">Id of the user to ban</param>
        /// <param name="moderatorId">UserId of the moderator</param>
        /// <param name="moderatorRole">Role of the user trying to moderate</param>
        /// <param name="reason"></param>
        /// <param name="reasonText"></param>
        /// <param name="endDate">End date of the suspension</param>
        bool Suspend(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText, DateTime endDate);
        /// <summary>
        /// Validates username and password
        /// </summary>
        /// <exception cref="ValidationException">Throws a ValidationException when userName and/or password are empty</exception>
        void ValidateUserAndPassword(string userName, string password);
        /// <summary>
        /// Warns a user.
        /// </summary>
        /// <param name="id">user id of the user to warn</param>
        /// <param name="moderatorId">UserId of the moderator</param>
        /// <param name="moderatorRole">Role of the user trying to moderate</param>
        /// <param name="reason"></param>
        /// <param name="reasonText"></param>
        bool Warn(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText);
        /// <summary>
        /// Dismisses the warning from a moderator. 
        /// Confirmimg that the user read the message.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool WarnDismiss(Guid id);

        IEnumerable<User> GetByName(string userName);
    }

    public class UserService : BaseDapperService<User>, IUserService
    {
        public UserService(IUserRepository repository, IUserProvider userProvider)
            : base(repository, userProvider)
        {
        }

        public void AddEmail(Guid id, string email, EmailPolicy policy)
        {
            throw new NotImplementedException();
        }

        public User AuthenticateWithCustomProvider(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool Ban(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText)
        {
            throw new NotImplementedException();
        }

        public bool CanModerate(User moderatorUser, User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Demote(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }
        
        public User GetByPasswordResetGuid(AuthenticationProvider provider, string passwordResetGuid)
        {
            throw new NotImplementedException();
        }
        
        public string GetRoleName(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public Dictionary<UserRole, string> GetRoles()
        {
            throw new NotImplementedException();
        }
        
        public bool IsThereAnyUser()
        {
            throw new NotImplementedException();
        }

        public void Promote(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ResetPassword(string membershipKey, string guid, string linkUrl)
        {
            throw new NotImplementedException();
        }

        public bool Suspend(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText,
            DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void ValidateUserAndPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool Warn(Guid id, Guid moderatorId, UserRole moderatorRole, ModeratorReason reason, string reasonText)
        {
            throw new NotImplementedException();
        }

        public bool WarnDismiss(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetByName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
