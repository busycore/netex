using System.Collections.Generic;
using modules.users.Models;
using modules.users.Repositories;

namespace dotnetex.modules.users.Services.Implementations.GetAllUsersService
{
    public class GetAllUsersService : IGetAllUsersService
    {

        private readonly IUserRepository userRepository;

        public GetAllUsersService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<Users> execute()
        {
            return this.userRepository.findAll();
        }
    }
}