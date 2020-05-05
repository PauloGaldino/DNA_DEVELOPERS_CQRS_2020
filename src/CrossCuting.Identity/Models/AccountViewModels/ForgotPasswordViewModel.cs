using System.ComponentModel.DataAnnotations;

namespace CrossCuting.Identity.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
    }
}
