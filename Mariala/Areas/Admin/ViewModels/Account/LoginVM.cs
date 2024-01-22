using System.ComponentModel.DataAnnotations;

namespace Mariala.Areas.Admin.ViewModels
{
    public class LoginVM
    {
        

        [MinLength(5, ErrorMessage = "Min length 5!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]

        public string UserNameOrEmail { get; set; } = null!;

        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;

        public bool IsPersitence { get; set; }
    }
}
