using System.ComponentModel.DataAnnotations;

namespace UserManagementService.Domain.Models
{
    public enum UserRole
    {
        User,
        Admin
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public UserRole Role { get; set; } = UserRole.User;
        [Required]
        public byte[] PasswordHash { get; set; } = new byte[32];

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
