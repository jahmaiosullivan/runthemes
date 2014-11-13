using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NearForums.DataAccess
{
	public class MessageRemovalDataAccess : BaseDataAccess, IMessageRemovalDataAccess
	{
		public IList<MessageRemovalReason> GetAll()
		{
			var comm = GetCommand("SPMessageRemovalReasonsGetAll");

			return GetTable(comm)
				.AsEnumerable()
				.Select(x => new MessageRemovalReason
				             {
					             Id = x.Field<int>("MessageRemovalReasonId"),
								 Title = x.Field<string>("Title"),
								 ReasonText = x.Field<string>("ReasonText"),
					             HideMessage = x.Field<bool>("HideMessage")
				             })
				.ToList();
		}
	}
}