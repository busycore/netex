using System;
using System.Net;
using dotnetex.shared.Errors;
using Microsoft.AspNetCore.Http;
using modules.users.Models;
using modules.users.Repositories;

namespace dotnetex.modules.users.Services.Implementations.GetUserByIdService
{
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Users execute(int id)
        {
            var foundUser = this.userRepository.findById(id);
            if (foundUser == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User not found");
            }
            return foundUser;
        }

        public Users executeTracked(int id)
        {
            var foundUser = this.userRepository.findByIdTracked(id);
            if (foundUser == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "User not found");
            }
            return foundUser;
        }
    }
}