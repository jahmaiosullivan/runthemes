using System;
using System.Collections.Generic;
using NearForums.Validation;

namespace NearForums.Services
{
	public interface IMessagesService
	{
		/// <summary>
		/// Adds a new message to the topic
		/// </summary>
		/// <exception cref="ValidationException">If the model is not valid</exception>
		/// <param name="user">User posting the message</param>
		void Add(Message message, string ip, User user);
		/// <summary>
		/// Removes the flags/marks on a message
		/// </summary>
		/// <param name="topicId"></param>
		/// <param name="messageId"></param>
		/// <returns></returns>
		bool ClearFlags(int topicId, int messageId);

		/// <summary>
		/// Deletes/Hides a message
		/// </summary>
		/// <param name="topicId"></param>
		/// <param name="messageId"></param>
		/// <param name="userId">identifier of the user deleting the message</param>
		/// <param name="removalReasonId"></param>
        void Delete(int topicId, int messageId, Guid userId, int? removalReasonId = null);
		/// <summary>
		/// Flags / Creates a mark on a message of a topic. The ip of flagger is stored.
		/// </summary>
		/// <param name="ip">Ip of the user creating the flag</param>
		bool Flag(int topicId, int messageId, string ip);
		/// <summary>
		/// Gets a list of flagged messages grouped by topic
		/// </summary>
		/// <param name="firstMsg">Zero-based index of the message</param>
		/// <param name="amount">Number of messages to return</param>
		List<Topic> ListFlagged(int firstMsg, int amount);
		/// <summary>
		/// Gets count of total flagged messages
		/// </summary>
		/// <returns></returns>
		int GetFlaggedMessageCount();
		/// <summary>
		/// Gets the message for the specified topicId, and msgId.
		/// </summary>
		/// <param name="topicId"></param>
		/// <param name="messageId"></param>
		/// <returns></returns>
		Message Get(int topicId, int messageId);

		/// <summary>
		/// Edits a message
		/// </summary>
		/// <exception cref="ValidationException"></exception>
		/// <param name="user">User editing the message</param>
		/// <param name="message"> </param>
		void Edit(Message message, string ip, User user);
	}
}
