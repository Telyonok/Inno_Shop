using MediatR;
using UserManagementService.Application.DTOs;

namespace UserManagementService.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}