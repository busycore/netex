using System.Collections.Generic;
using modules.users.Models;

namespace modules.users.Repositories
{
    public interface IUserRepository
    {
        List<Users> findAll();
        Users findById(int id);
        Users create(Users newUser);
        Users update();
        void delete();
    }
}