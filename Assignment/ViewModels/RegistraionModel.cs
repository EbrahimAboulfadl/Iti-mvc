using System.ComponentModel.DataAnnotations;

namespace Assignment.ViewModels
{
    public class RegistraionModel
    { 

        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        public string Address { get; set; }
    }
}