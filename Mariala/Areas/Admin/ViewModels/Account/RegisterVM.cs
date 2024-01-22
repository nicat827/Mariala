using System.ComponentModel.DataAnnotations;

namespace Mariala.Areas.Admin.ViewModels
{
    public class RegisterVM
    {
        [MinLength(3, ErrorMessage = "Min length 3!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]

        public string Name { get; set; } = null!;


        [MinLength(3, ErrorMessage = "Min length 3!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]

        public string Surname { get; set; } = null!;


        [MinLength(5, ErrorMessage = "Min length 5!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]

        public string UserName { get; set; } = null!;

        [MinLength(6, ErrorMessage = "Min length 6!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email is incorrect!")]

        public string Email { get; set; } = null!;

        [MinLength(8, ErrorMessage = "Min length 8!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;

        [MinLength(8, ErrorMessage = "Min length 8!")]
        [MaxLength(100, ErrorMessage = "Max length 100!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]

        public string RepeatPassword { get; set; } = null!;


    }
}
