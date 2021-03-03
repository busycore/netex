using System.Net;
using dotnetex.shared.Errors;
using modules.users.Models;
using modules.users.Repositories;

namespace dotnetex.modules.users.Services.Implementations.GetUserByEmailService
{
    public class GetUserByEmailService : IGetUserByEmailService
    {

        private readonly IUserRepository userRepository;

        public GetUserByEmailService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Users execute(string email)
        {
            var foundUser = this.userRepository.findByEmail(email);
            if (foundUser == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "This email is not registered");
            }
            return foundUser;
        }
    }
}