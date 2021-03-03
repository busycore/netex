using modules.users.Models;
using modules.users.Repositories;

namespace dotnetex.modules.users.Services.Implementations.DeleteUserService
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository userRepository;

        public DeleteUserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void execute(Users user)
        {
            this.userRepository.delete(user);
        }
    }
}