using Academy_2025.Data;
using System.ComponentModel.DataAnnotations;

namespace Academy_2025.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        //public string? FirstName { get; set; }

        /*[Required]
        [StringLength(50)]
        public string? LastName { get; set; }*/

        [Required]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public string? Role { get; set; }

    }
}
