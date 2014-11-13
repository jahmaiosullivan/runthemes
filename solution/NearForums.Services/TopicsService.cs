using System;
using System.Collections.Generic;
using NearForums.DataAccess;
using NearForums.Configuration;

namespace NearForums.Services
{
	public class TopicsService : ITopicsService
	{
		/// <summary>
		/// Topics repository
		/// </summary>
		private readonly ITopicsDataAccess _dataAccess;
		/// <summary>
		/// Messages repository
		/// </summary>
		private readonly IMessagesDataAccess _messagesDataAccess;
		/// <summary>
		/// Search index service
		/// </summary>
		private readonly ISearchService _searchIndex;
		/// <summary>
		/// Logging service
		/// </summary>
		private readonly ILoggerService _loggerService;

		public TopicsService(ITopicsDataAccess da, IMessagesDataAccess messagesDa, ISearchService searchIndex, ILoggerService loggerService)
		{
			_dataAccess = da;
			_messagesDataAccess = messagesDa;
			_searchIndex = searchIndex;
			_loggerService = loggerService;
		}

		public List<Topic> GetByForum(int forumId, int startIndex, int length, UserRole? role)
		{
			return _dataAccess.GetByForum(forumId, startIndex, length, role);
		}

		public List<Topic> GetByTag(string tag, int forumId, UserRole? role)
		{
			return _dataAccess.GetByTag(tag, forumId, role);
		}

		public Topic Get(int topicId)
		{
			return _dataAccess.Get(topicId);
		}
		
		/// <summary>
		/// Gets a topic matching the id and the shortname
		/// </summary>
		/// <param name="id"></param>
		/// <param name="shortName"></param>
		/// <returns></returns>
		public Topic Get(int id, string shortName)
		{
			var topic = Get(id);
			if (topic != null && topic.ShortName.ToUpper() != shortName.ToUpper())
			{
				topic = null;
			}
			return topic;
		}

		public Topic GetWithMessages(int topicId, int firstMsg, int amount)
		{
			var topic = Get(topicId);
			if (topic != null)
			{
				topic.Messages = _messagesDataAccess.GetByTopicFrom(topicId, firstMsg, amount);
			}
			return topic;
		}

		public Topic GetWithMessagesLatest(int id, string shortName)
		{
			var topic = Get(id, shortName);
			if (topic != null)
			{
				topic.Messages = _messagesDataAccess.GetByTopicLatest(id);
			}
			return topic;
		}

		public void LoadRelatedTopics(Topic topic, int amount)
		{
			topic.Related = _dataAccess.GetRelatedTopics(topic, amount);
		}

		public void Create(Topic topic, string ip, User user)
		{
			topic.User = user;
			topic.ValidateFields();
			var htmlInputConfig = SiteConfiguration.Current.SpamPrevention.HtmlInput;
			if (!(user.Role > htmlInputConfig.AvoidValidationForRole))
			{
				topic.Description = topic.Description.SafeHtml(htmlInputConfig.FixErrors, htmlInputConfig.AllowedElements);
			}
			topic.Description = topic.Description.ReplaceValues(SiteConfiguration.Current.Replacements);
			_dataAccess.Add(topic, ip);

			try
			{
				_searchIndex.Add(topic);
			}
			catch (Exception e)
			{
				_loggerService.LogError(e);
			}
		}

		public void Edit(Topic topic, string ip, User user)
		{
			topic.User = user;
			topic.ValidateFields();
			var htmlInputConfig = SiteConfiguration.Current.SpamPrevention.HtmlInput;
			if (!(user.Role >= htmlInputConfig.AvoidValidationForRole))
			{
				topic.Description = topic.Description.SafeHtml(htmlInputConfig.FixErrors, htmlInputConfig.AllowedElements);
			}
			topic.Description = topic.Description.ReplaceValues(SiteConfiguration.Current.Replacements);
			_dataAccess.Edit(topic, ip);

			try
			{
				_searchIndex.Update(topic);
			}
			catch (Exception e)
			{
				_loggerService.LogError(e);
			}
		}

		public void AddVisit(int topicId)
		{
			var handler = new Action<int>(AddVisitSync);
			handler.BeginInvoke(topicId, null, null);
		}

		private void AddVisitSync(int topicId)
		{
			_dataAccess.AddVisit(topicId);
		}

		public List<Topic> GetLatest(int forumId, int startIndex, int length, UserRole? role)
		{
			return _dataAccess.GetByForumLatest(forumId, startIndex, length, role);
		}

		public List<Topic> GetLatest()
		{
			return _dataAccess.GetLatest();
		}

        public Topic Move(int id, int forumId, Guid userId, string ip)
		{
			_dataAccess.Move(id, forumId, userId, ip);
			return _dataAccess.Get(id);
		}

        public void Close(int id, Guid userId, string ip)
		{
			_dataAccess.Close(id, userId, ip);
		}

        public void Open(int id, Guid userId, string ip)
		{
			_dataAccess.Open(id, userId, ip);
		}

		public bool Flag(int topicId, string ip)
		{
			return _dataAccess.Flag(topicId, ip);
		}

		public int GetUnansweredTopicCount()
		{
			return _dataAccess.GetUnansweredTopicCount();
		}

		public List<Topic> GetUnanswered(int forumId, UserRole? role)
		{
			return _dataAccess.GetUnanswered(forumId, role);
		}

		public List<Topic> GetAllUnanswered(int firstMsg, int amount)
		{
			return _dataAccess.GetUnanswered(firstMsg, amount);
		}

        public void Delete(int id, Guid userId, string ip)
		{
			_dataAccess.Delete(id, userId, ip);
			_searchIndex.DeleteTopic(id);
		}

        public List<Topic> GetByUser(Guid userId, UserRole? role)
		{
			return _dataAccess.GetByUser(userId, role);
		}

        public List<Topic> GetTopicsAndMessagesByUser(Guid userId)
		{
			return _dataAccess.GetTopicsAndMessagesByUser(userId);
		}
	}
}
