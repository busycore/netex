using modules.users.Models;

namespace dotnetex.modules.users.Services.Implementations.GetUserByIdService
{
    public interface IGetUserByIdService
    {
        Users execute(int id);
    }
}