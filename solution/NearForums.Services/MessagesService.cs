using System;
using System.Collections.Generic;
using NearForums.DataAccess;
using NearForums.Configuration;

namespace NearForums.Services
{
	public class MessagesService : IMessagesService
	{
		/// <summary>
		/// messages repository
		/// </summary>
		private readonly IMessagesDataAccess _dataAccess;
		/// <summary>
		/// Search index service
		/// </summary>
		private readonly ISearchService _searchIndex;
		/// <summary>
		/// Logging service
		/// </summary>
		private readonly ILoggerService _loggerService;

		public MessagesService(IMessagesDataAccess da, ISearchService searchIndex, ILoggerService loggerService)
		{
			_dataAccess = da;
			_searchIndex = searchIndex;
			_loggerService = loggerService;
		}

		public void Add(Message message, string ip, User user)
		{
			message.User = user;
			message.ValidateFields();
			var htmlInputConfig = SiteConfiguration.Current.SpamPrevention.HtmlInput;
			if (!(user.Role >= htmlInputConfig.AvoidValidationForRole))
			{
				message.Body = message.Body.SafeHtml(htmlInputConfig.FixErrors, htmlInputConfig.AllowedElements);
			}
			message.Body = message.Body.ReplaceValues(SiteConfiguration.Current.Replacements);
			_dataAccess.Add(message, ip);

			try
			{
				_searchIndex.Add(message);
			}
			catch (Exception e)
			{
				_loggerService.LogError(e);
			}
		}

		public bool ClearFlags(int topicId, int messageId)
		{
			return _dataAccess.ClearFlags(topicId, messageId);
		}

        public void Delete(int topicId, int messageId, Guid userId, int? removalReasonId = null)
		{
			_dataAccess.Delete(topicId, messageId, userId, removalReasonId);
			_searchIndex.DeleteMessage(topicId, messageId);
		}

		public bool Flag(int topicId, int messageId, string ip)
		{
			return _dataAccess.Flag(topicId, messageId, ip);
		}

		/// <summary>
		/// Gets all the messages of a topic
		/// </summary>
		/// <param name="topicId"></param>
		/// <returns></returns>
		public List<Message> GetByTopic(int topicId)
		{
			return _dataAccess.GetByTopic(topicId); 
		}

		public List<Message> GetByTopicLatest(int topicId)
		{
			return _dataAccess.GetByTopicLatest(topicId);
		}

		public List<Topic> ListFlagged(int firstMsg, int amount)
		{
			return _dataAccess.ListFlagged(firstMsg, amount);
		}

		public int GetFlaggedMessageCount()
		{
			return _dataAccess.GetFlaggedMessageCount();
		}

		public Message Get(int topicId, int messageId)
		{
			return _dataAccess.Get(topicId, messageId);
		}

		public void Edit(Message message, string ip, User user)
		{
			message.User = user;
			message.ValidateFields();
			var htmlInputConfig = SiteConfiguration.Current.SpamPrevention.HtmlInput;
			if (!(user.Role >= htmlInputConfig.AvoidValidationForRole))
			{
				message.Body = message.Body.SafeHtml(htmlInputConfig.FixErrors, htmlInputConfig.AllowedElements);
			}
			message.Body = message.Body.ReplaceValues(SiteConfiguration.Current.Replacements);
			_dataAccess.Edit(message, ip);

			try
			{
				_searchIndex.Update(message);
			}
			catch (Exception e)
			{
				_loggerService.LogError(e);
			}
		}
	}
}
