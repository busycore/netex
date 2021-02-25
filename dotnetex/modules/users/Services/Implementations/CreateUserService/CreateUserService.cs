using modules.users.Models;
using modules.users.Repositories;

namespace dotnetex.modules.users.Services.Implementations.CreateUserService
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserRepository userRepository;

        public CreateUserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Users execute(Users user)
        {
            return this.userRepository.create(user);
        }
    }
}