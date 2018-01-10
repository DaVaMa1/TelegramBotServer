using Common;
using IDataServices;
using System;
using System.Runtime.Serialization;

namespace Entities
{
	[DataContract]
	public class User : IUser
	{
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public string Username { get; set; }

		[DataMember]
		public Userrole Userrole { get; set; }

		[DataMember]
		public long TelegramUserId { get; set; }

		public bool IsAuthorized()
		{
			return Userrole.IsAuthorized();
		}
	}
}
