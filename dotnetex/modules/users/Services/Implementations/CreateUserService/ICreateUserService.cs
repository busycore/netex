using modules.users.Models;

namespace dotnetex.modules.users.Services.Implementations.CreateUserService
{
    public interface ICreateUserService
    {
        Users execute(Users user);
    }
}