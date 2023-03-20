using System.ComponentModel.DataAnnotations;

namespace ETickets.ModelView
{
    public class RegistrationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
    
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string? Role { get; set; }

    }
}
