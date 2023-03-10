using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Day07.Entities
{
    public class CustomRole : IdentityRole
    {
        public string? ShortDetail { get; set; }

        [Required]
        public bool Active { get; set; } = true;

        [Required]
        public bool Deleted { get; set; } = false;
    }
}
