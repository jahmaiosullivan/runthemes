namespace NearForums
{
	public class MessageRemovalReason : Entity
	{
		public MessageRemovalReason()
		{

		}

		public MessageRemovalReason(int id)
		{
			this.Id = id;
		}
		/// <summary>
		/// MessageRemovalReason identifier. 1 based index inside the thread.
		/// </summary>
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// The title of the reason why the message was removed
		/// </summary>
		public string Title
		{
			get;
			set;
		}
		/// <summary>
		/// Text to display when message is removed
		/// </summary>
		public string ReasonText
		{
			get;
			set;
		}

		/// <summary>
		/// Determines if the message can be shown.
		/// </summary>
		public bool HideMessage
		{
			get;
			set;
		}
	}
}