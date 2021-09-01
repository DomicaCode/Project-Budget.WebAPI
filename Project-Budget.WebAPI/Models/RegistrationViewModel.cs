using System.ComponentModel.DataAnnotations;

namespace Project_Budget.WebAPI.Models
{
    public class RegistrationViewModel
    {
        #region Properties

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        #endregion Properties
    }
}