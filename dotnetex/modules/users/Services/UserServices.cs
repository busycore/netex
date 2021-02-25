using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using modules.users.Models;
using modules.users.Repositories;
using shared.Configurations.Database;

namespace modules.users.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Users createUser(Users usr)
        {
            return this.userRepository.create(usr);
        }

        public void DeleteUser()
        {
            throw new System.NotImplementedException();
        }

        public List<Users> GetAllUsers()
        {
            return this.userRepository.findAll();
        }

        public Users GetUserById(int id)
        {
            var foundUser = this.userRepository.findById(id);
            if (foundUser == null)
            {
                throw new BadHttpRequestException("User Not found ");
            }
            return this.userRepository.findById(id);
        }
    }
}