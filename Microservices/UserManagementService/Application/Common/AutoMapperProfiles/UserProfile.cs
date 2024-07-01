using AutoMapper;
using UserManagementService.Application.DTOs;
using UserManagementService.Application.Users.Commands.CreateUser;
using UserManagementService.Application.Users.Commands.UpdateUser;
using UserManagementService.Domain.Models;

namespace ProductManagementService.Application.Common.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, CreateUserCommand>();
            CreateMap<UpdateUserDTO, UpdateUserCommand>();
            CreateMap<User, UserDTO>();
        }
    }
}