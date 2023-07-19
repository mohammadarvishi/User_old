using System.ComponentModel.DataAnnotations;

namespace Users.Model.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string Family { get; set; }

        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Entering {0} is mandatory.")]
        public string Password { get; set; }
    }
}
