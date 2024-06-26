using System.ComponentModel.DataAnnotations;

namespace HR_System.ViewModels
{
    public class LoginVM
    {
        [Required]  
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
