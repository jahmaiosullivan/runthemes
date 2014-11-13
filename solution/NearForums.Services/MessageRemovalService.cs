using System;
using System.Collections.Generic;
using NearForums.DataAccess;

namespace NearForums
{
	public class MessageRemovalService : IMessageRemovalService
	{
		/// <summary>
		/// Message removal data access
		/// </summary>
		private readonly IMessageRemovalDataAccess _messageDataAccess;

		public MessageRemovalService(IMessageRemovalDataAccess messageDataAccess)
		{
			_messageDataAccess = messageDataAccess;
		}

		public IList<MessageRemovalReason> GetAll()
		{
			return _messageDataAccess.GetAll();
		}
	}
}