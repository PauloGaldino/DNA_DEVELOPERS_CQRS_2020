using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using UserLoginInfo = Microsoft.AspNetCore.Identity.UserLoginInfo;

namespace CrossCuting.Identity.Models.ManageViewModels
{
    public class ExternalLoginViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationScheme> OtherLogins { get; set; }

        public bool ShowRemoveButton { get; set; }

        public string StatusMessage { get; set; }

    }
}
