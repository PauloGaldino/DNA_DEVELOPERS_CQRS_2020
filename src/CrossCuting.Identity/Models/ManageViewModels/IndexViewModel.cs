using System.ComponentModel.DataAnnotations;

namespace CrossCuting.Identity.Models.ManageViewModels
{

    public class IndexViewModel
    {
        [Display(Name = "Nome do Usuário")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Número de Telefone")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
