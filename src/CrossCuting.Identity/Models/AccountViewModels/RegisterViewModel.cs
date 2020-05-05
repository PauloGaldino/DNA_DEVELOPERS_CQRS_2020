using System.ComponentModel.DataAnnotations;

namespace CrossCuting.Identity.Models.AccountViewModels
{
    public  class RegisterViewModel
    {
        [Required]
        [Display(Name="Nome")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

    }
}
