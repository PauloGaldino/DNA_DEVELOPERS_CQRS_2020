using Microsoft.AspNetCore.Identity;
using System;
using System.Data;

namespace CrossCuting.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        // Add profile data for application users by adding properties to the ApplicationUser class
        // Adicione dados de perfil para usuários do aplicativo adicionando propriedades à classe ApplicationUser
        public string Nome { get; set; }
        public DateTime DataNasimento { get; set; }
    }
}
