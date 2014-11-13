using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NearForums.DataAccess
{
	public interface ITopicsSubscriptionsDataAccess
	{
		void Add(int topicId, Guid userId);
        List<Topic> GetTopicsByUser(Guid userId);
		List<User> GetUsersByTopic(int topicId);
        int Remove(int topicId, Guid userId, Guid guid);
	}
}
