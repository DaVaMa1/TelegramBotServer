using System.Collections.Generic;
using System.Net.Http;
using DataServices;
using Entities;
using IDataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TelegramBotServer.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
		private readonly IUserRepository _userRepository;

		private UserController(IUserRepository userRepository)
		{
			this._userRepository = userRepository;
		}

		public UserController() : this(new UserRepository()) { }

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(long id)
        {
			return (User)_userRepository.GetUser(id);
		}

		// POST: api/User
		[HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
