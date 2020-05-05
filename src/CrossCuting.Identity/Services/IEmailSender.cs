﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCuting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
