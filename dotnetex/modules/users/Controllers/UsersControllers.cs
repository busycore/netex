using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using modules.users.Models;
using modules.users.Repositories;
using shared.Configurations.Database;

namespace modules.users.Controllers
{
    [ApiController]
    [Route("/user")]
    //[Route("[controller]")]
    public class UsersControllers : ControllerBase
    {
        private readonly SQLiteDbContext _context;
        private readonly IUserRepository repository;

        private readonly ILogger<UsersControllers> _logger;

        public UsersControllers(SQLiteDbContext context, IUserRepository repository, ILogger<UsersControllers> logger)
        {
            this._context = context;
            this._logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        public List<Users> getAllUsers()
        {
            // List<Users> usuarios = new List<Users>() {
            //     new Users(1, "John", "john@john.com", "123456", new DateTime(1996, 01, 20)) ,
            //     new Users(2, "Mark", "mark@mark.com", "123456", new DateTime(1992, 08, 19)) ,
            //     new Users(3, "Zeke", "zeke@zeke.com", "123456", new DateTime(1990, 06, 02))
            //     };
            return this.repository.findAll();
            //return _context.Users.AsNoTracking().Where(user => user.name != "Mark").ToList<Users>();
        }
        [HttpGet("{id}")]
        public Users getSingleUser(int id)
        {
            return this.repository.findById(id);
        }

        [HttpPost]
        public Users create([FromBody] Users user)
        {
            //if (user == null) return BadRequest();
            this._logger.LogInformation(user.ToString());
            return user;
            //return this.repository.create(user);
        }
    }
}