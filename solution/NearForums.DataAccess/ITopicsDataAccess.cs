using System;
using System.Collections.Generic;

namespace NearForums.DataAccess
{
	public interface ITopicsDataAccess
	{
		void Add(Topic topic, string ip);
		void AddVisit(int topicId);
        void Close(int id, Guid userId, string ip);
        void Delete(int id, Guid userId, string ip);
		void Edit(Topic topic, string ip);
		Topic Get(int id);
		/// <summary>
		/// Gets a list of topics of a forum, from startIndex to startIndex+length, sorted by views
		/// </summary>
		List<Topic> GetByForum(int forumId, int startIndex, int length, UserRole? role);
		/// <summary>
		/// Gets a list of topics of a forum, from startIndex to startIndex+length, sorted by latest activity
		/// </summary>
		List<Topic> GetByForumLatest(int forumId, int startIndex, int length, UserRole? role);
		List<Topic> GetByTag(string tag, int forumId, UserRole? role);
        List<Topic> GetByUser(Guid userId, UserRole? role);
		List<Topic> GetLatest();
		List<Topic> GetRelatedTopics(Topic topic, int amount);
        List<Topic> GetTopicsAndMessagesByUser(Guid userId);
		List<Topic> GetUnanswered(int firstMsg, int amount);
		List<Topic> GetUnanswered(int forumId, UserRole? role);
        void Move(int id, int forumId, Guid userId, string ip);
        void Open(int id, Guid userId, string ip);
		int GetUnansweredTopicCount();
		bool Flag(int topicId, string ip);
	}
}
