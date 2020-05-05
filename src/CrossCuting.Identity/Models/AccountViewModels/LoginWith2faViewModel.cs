using System.ComponentModel.DataAnnotations;

namespace CrossCuting.Identity.Models.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name ="Código de autênticação de 2 fatores")]
        public string TwoFactorCode { get; set; }

        [Display(Name ="Lembra esta maquina")]
        public bool RememberMachine { get; set; }

        [Display(Name = "Lembrar me ?")]
        public bool RememberMe { get; set; }
    }
}
