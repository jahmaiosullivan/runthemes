using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NearForums
{
	public interface IMessageRemovalService
	{
		/// <summary>
		/// Returns all message removal reasons
		/// </summary>
		/// <returns></returns>
		IList<MessageRemovalReason> GetAll();
	}
}
