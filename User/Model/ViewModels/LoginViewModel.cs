using System.ComponentModel.DataAnnotations;

namespace Users.Model.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string Password { get; set; }
    }
}
