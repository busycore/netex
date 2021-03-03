using System.Collections.Generic;
using dotnetex.modules.users.Services.Implementations.CreateUserService;
using dotnetex.modules.users.Services.Implementations.DeleteUserService;
using dotnetex.modules.users.Services.Implementations.GetAllUsersService;
using dotnetex.modules.users.Services.Implementations.GetUserByEmailService;
using dotnetex.modules.users.Services.Implementations.GetUserByIdService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modules.users.Models;
using modules.users.Repositories;
using shared.Configurations.Database;

namespace modules.users.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IGetAllUsersService getAllUsersService;
        private readonly IGetUserByIdService getUserByIdService;
        private readonly ICreateUserService createUserService;
        private readonly IGetUserByEmailService getUserByEmailService;
        private readonly IDeleteUserService deleteUserService;

        public UserServices(IUserRepository userRepository, IGetAllUsersService getAllUsersService,
        IGetUserByIdService getUserByIdService, ICreateUserService createUserService,
         IGetUserByEmailService getUserByEmailService, IDeleteUserService deleteUserService)
        {
            this.userRepository = userRepository;
            this.getAllUsersService = getAllUsersService;
            this.getUserByIdService = getUserByIdService;
            this.createUserService = createUserService;
            this.getUserByEmailService = getUserByEmailService;
            this.deleteUserService = deleteUserService;
        }
        public Users createUser(Users usr)
        {
            return this.createUserService.execute(usr);
        }

        public void DeleteUser(int id)
        {
            var foundUser = this.getUserByIdService.executeTracked(id);
            deleteUserService.execute(foundUser);
        }

        public List<Users> GetAllUsers()
        {
            return this.getAllUsersService.execute();
        }

        public Users GetUserById(int id)
        {
            return this.getUserByIdService.execute(id);
        }

        public Users GetUserByEmail(string email)
        {
            return this.getUserByEmailService.execute(email);
        }
    }
}