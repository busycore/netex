using modules.users.Models;

namespace dotnetex.modules.users.Services.Implementations.GetUserByEmailService
{
    public interface IGetUserByEmailService
    {
        Users execute(string email);
    }
}