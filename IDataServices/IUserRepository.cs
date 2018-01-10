using System.Collections.Generic;

namespace IDataServices
{
    public interface IUserRepository
    {
		IUser GetUser(long telegramUserId);

		void CreateUser(long chatId, string username);
	}
}
