using CrossCuting.Identity.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CrossCuting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "confirme seu email",
                $"Confirme sua conta clicando neste link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
