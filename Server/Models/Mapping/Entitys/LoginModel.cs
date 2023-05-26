using System.ComponentModel.DataAnnotations;

namespace CRM_Server_Side.Models.Mapping.Entitys;

public class LoginModel
{
    [Required(ErrorMessage = "Не все поля заполнены")]
    [StringLength(maximumLength:100,ErrorMessage = "Неверный формат почты")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Не все поля заполнены")]
    [StringLength(maximumLength:100,MinimumLength = 6, ErrorMessage = "Неверный формат пароля")]
    public string Password { get; set; }
}