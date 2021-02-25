using System.Collections.Generic;
using modules.users.Models;

namespace dotnetex.modules.users.Services.Implementations.GetAllUsersService
{
    public interface IGetAllUsersService
    {
        List<Users> execute();
    }
}