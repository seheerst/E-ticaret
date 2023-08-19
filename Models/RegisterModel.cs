using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EticaretWeb.Models;

public class RegisterModel
{
    [Required]
    [DisplayName("Adınız")]
    public string Name { get; set; }
    
    [Required]
    [DisplayName("Soy Adınız")]
    public string SurName { get; set; }
    
    [Required]
    [DisplayName("Kullanıcı Adı")]
    public string UserName { get; set; }
    
    [Required]
    [DisplayName("E-posta adresi")]
    [EmailAddress]
    public string  Email { get; set; }
    
    [Required]
    [DisplayName("Şifre")]
    public string Password { get; set; }
    
    [Required]
    [DisplayName("Şifre Tekrar")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
    public string  Repassword{ get; set; }
}