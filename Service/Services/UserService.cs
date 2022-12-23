using Survey_Project.Core;
using Survey_Project.Core.DTOs;
using Survey_Project.Core.Repositories;
using Survey_Project.Core.Services;
using Survey_Project.Core.UnitOfWorks;
using System;
using AutoMapper;
using Core.Repositories;
using Core.Models;
using Core.DTOs;

namespace Survey_Project.Service.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public UserService(IGenericRepository<User> repository, IGenericUnitOfWork unitOfWork, IUserRepository productImageRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetWebAllUser()
        {
            var user = await _userRepository.GetWebAllUserAsync();
            var userDtos = _mapper.Map<List<UserDto>>(user);
            return userDtos;
        }

        public async Task<CustomResponseDto<List<UserDto>>> GetApiAllUser()
        {
            var user = await _userRepository.GetApiAllUserAsync();
            var userDtos = _mapper.Map<List<UserDto>>(user);
            return CustomResponseDto<List<UserDto>>.Success(200, userDtos);
        }
        

        public async Task<List<UserDto>> GetWebAllUserAsync()
        {
            var user = await _userRepository.GetWebAllUserAsync();
            var userDtos = _mapper.Map<List<UserDto>>(user);
            return userDtos;
        }

     
    }

}

