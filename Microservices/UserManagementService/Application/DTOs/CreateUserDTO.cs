using UserManagementService.Domain.Models;

namespace UserManagementService.Application.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public string Password { get; set; } = string.Empty;
    }
}
