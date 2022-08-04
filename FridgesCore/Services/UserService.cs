using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> AddAsync(User user)
        {
            UserEntity entity = new UserEntity()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = "User",
            };
            var result = await _userRepository.AddAsync(entity);
            UserCredentialsEntity credentialsEntity = new UserCredentialsEntity()
            {

            }
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var userEntity = await _userRepository.GetByEmailAsync(email);
            var user = _mapper.Map<User>(userEntity);
            return user;
        }
    }
}
