using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using modules.users.Models;
using shared.Configurations.Database;

namespace modules.users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteDbContext _context;

        public UserRepository(SQLiteDbContext context)
        {
            _context = context;
        }


        public List<Users> findAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public Users findById(int id)
        {
            var foundUser = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (foundUser == null)
            {
                throw new BadHttpRequestException("No user found", (int)HttpStatusCode.Conflict);

            }
            return foundUser;
        }
        public Users create(Users newUser)
        {
            //var newUser = new Users("")
            var usr = _context.Add(newUser).Entity;
            _context.SaveChanges();
            return usr;
        }
        public Users update()
        {
            return new Users();
        }
        public void delete()
        {

        }

    }
}