using System;
using System.Collections.Generic;

namespace NearForums.DataAccess
{
	public interface IMessagesDataAccess
	{
		void Add(Message message, string ip);
		void Edit(Message message, string ip);
		bool ClearFlags(int topicId, int messageId);
        void Delete(int topicId, int messageId, Guid userId, int? removalReasonId);
		bool Flag(int topicId, int messageId, string ip);
		Message Get(int topicId, int messageId);
		List<Message> GetByTopic(int topicId);
		List<Message> GetByTopic(int topicId, int firstMsg, int lastMsg);
		List<Message> GetByTopicFrom(int topicId, int firstMsg, int amount);
		List<Message> GetByTopicLatest(int topicId);
		List<Topic> ListFlagged(int firstMsg, int amount);
		int GetFlaggedMessageCount();
	}
}
