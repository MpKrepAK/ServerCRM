using System.ComponentModel.DataAnnotations;
using CRM_Server_Side.Models.Database.Entitys.Enums;

namespace CRM_Server_Side.Models.Mapping.Entitys;

public class RegistrationModel
{
    [Required(ErrorMessage = "Не все поля заполнены")]
    [StringLength(maximumLength:100, MinimumLength = 3,ErrorMessage = "Длина строки 3 - 20")]
    public string Nickname { get; set; }
    [Required(ErrorMessage = "Не все поля заполнены")]
    [StringLength(maximumLength:100,ErrorMessage = "Неверный формат почты")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Не все поля заполнены")]
    [StringLength(maximumLength:100,MinimumLength = 6, ErrorMessage = "Неверный формат пароля")]
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string RepeatPassword { get; set; }
    [Required(ErrorMessage = "Не все поля заполнены")]
    public Genders Gender { get; set; }
}