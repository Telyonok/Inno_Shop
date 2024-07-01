using UserManagementService.Application.DTOs;
using MediatR;

namespace UserManagementService.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDTO>>
    {
    }
}