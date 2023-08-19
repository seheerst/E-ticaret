using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EticaretWeb.Models;

public class LoginModel
{
    [Required]
    [DisplayName("Kullanıcı Adı")]
    public string UserName { get; set; }
    [Required]
    [DisplayName("Şifre")]
    public string Password { get; set; }
    
    [DisplayName("Beni Hatırla")]
    public bool RememberMe { get; set; }
}