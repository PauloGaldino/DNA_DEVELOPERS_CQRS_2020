using System.ComponentModel.DataAnnotations;

namespace CrossCuting.Identity.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string  Email { get; set; }
    }
}
