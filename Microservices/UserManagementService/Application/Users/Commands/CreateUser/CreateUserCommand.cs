﻿using MediatR;
using UserManagementService.Domain.Models;

namespace UserManagementService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public string Password { get; set; } = string.Empty;
    }
}