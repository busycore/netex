using System.Net;
using dotnetex.shared.Errors;
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
            var isEmailRegistered = this.userRepository.findByEmail(user.email);
            if (isEmailRegistered != null)
            {
                throw new HttpException(HttpStatusCode.Conflict, "This email is already registered");
            }
            return this.userRepository.create(user);
        }
    }
}