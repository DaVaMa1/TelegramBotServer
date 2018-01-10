using System.Linq;
using System;
using IDataServices;
using Entities;
using System.Data.SqlClient;
using Dapper;
using Common;

namespace DataServices
{
	public class UserRepository : IUserRepository
	{
		public string ConnectionString => "Server=localhost;Database=TelegramBot;Trusted_Connection=True;";

		public UserRepository()
		{
		}

		public void CreateUser(long chatId, string username)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Open();
				connection.Execute($"INSERT INTO [user]([Username], [Userrole], [TelegramUserId]) VALUES ({username}, {Userrole.NormalUser}, {chatId});");
				connection.Close();							  
			}												  
		}

		public IUser GetUser(long telegramUserId)
		{
			User user;
			using (var connection = new SqlConnection(ConnectionString))
			{
				try
				{
					connection.Open();
					user = connection.Query<User>($"SELECT * FROM [TelegramBot].[dbo].[user] WHERE TelegramUserId = {telegramUserId};").SingleOrDefault();
					connection.Close();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
			return user;
		}
	}
}
