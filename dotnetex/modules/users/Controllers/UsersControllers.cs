using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using modules.users.Models;
using modules.users.Repositories;
using modules.users.Services;
using shared.Configurations.Database;

namespace modules.users.Controllers
{
    [ApiController]
    [Route("/user")]
    //[Route("[controller]")]
    public class UsersControllers : ControllerBase
    {
        private readonly SQLiteDbContext _context;
        private readonly UserServices userServices;

        private readonly ILogger<UsersControllers> _logger;

        public UsersControllers(SQLiteDbContext context, UserServices userServices, ILogger<UsersControllers> logger)
        {
            this._context = context;
            this._logger = logger;
            this.userServices = userServices;
        }

        [HttpGet]
        public List<Users> getAllUsers()
        {
            return this.userServices.GetAllUsers();
        }


        [HttpGet("{id}")]
        public Users getSingleUser(int id)
        {
            return this.userServices.GetUserById(id);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            this.userServices.DeleteUser();
            return StatusCode((int)HttpStatusCode.NoContent);

        }

        [HttpPost]
        public Users makeUser([FromBody] Users user)
        {
            return this.userServices.createUser(user);
        }
    }
}