using System.ComponentModel.DataAnnotations;

namespace Web_C_.BL.Implementations
{
    public class RegistrationModel
    {
        public RegistrationModel()
        {

        }
        [Display(Name = "Имя*")]
        [Required(ErrorMessage = "Имя обязательное поле")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = $"Имя должно состоять от 3 до 20 символов")]

        public string Name { get; set; }

        [Display(Name = "Почта*")]
        [Required(ErrorMessage = "Почта обязательное поле")]
        [StringLength(40, ErrorMessage = "Мы не можем сохранить вашу почту т.к. она слишком длинная")]
        [EmailAddress(ErrorMessage = "Неверна введена почта")]

        public string Email { get; set; }

        [Display(Name = "Телефон*")]
        [Required(ErrorMessage = "Телефон обязательное поле")]
        [Phone(ErrorMessage = "Неверно введен номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Пароль*")]
        [Required(ErrorMessage = "Пароль обязательное поле")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Пароль должен состоять от 8 до 20 символов")]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Вы ввели два разных пароля")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля*")]
        [Required(ErrorMessage = "Подтверждение пароля обязательное поле")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Пароль должен состоять от 8 до 20 символов")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }

}
