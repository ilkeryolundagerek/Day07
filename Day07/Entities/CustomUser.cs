using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Day07.Entities
{
    public class CustomUser : IdentityUser
    {
        [Required, MaxLength(25)]
        public string Firstname { get; set; }

        [MaxLength(25)]
        public string? Middlename { get; set; }

        [Required, MaxLength(25)]
        public string Lastname { get; set; }

        public string? Address { get; set; }

        public string? ShortDetail { get; set; }

        [Required]
        public bool Active { get; set; } = true;

        [Required]
        public bool Deleted { get; set; } = false;
    }
}
