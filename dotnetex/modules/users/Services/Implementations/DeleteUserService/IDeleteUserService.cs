using modules.users.Models;

namespace dotnetex.modules.users.Services.Implementations.DeleteUserService
{
    public interface IDeleteUserService
    {
        void execute(Users user);
    }
}