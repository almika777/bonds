using System.ComponentModel.DataAnnotations;

namespace Bonds.App.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Укажите ваш Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Задайте пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо подтвердить пароль")]
        [Compare(nameof(Password), ErrorMessage = "Не удалось подтвердить пароль")]
        public string PasswordVerify { get; set; }
    }
}
