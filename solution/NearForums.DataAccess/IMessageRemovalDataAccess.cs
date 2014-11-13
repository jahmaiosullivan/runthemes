using System.Collections.Generic;

namespace NearForums.DataAccess
{
	public interface IMessageRemovalDataAccess
	{
		IList<MessageRemovalReason> GetAll();
	}
}