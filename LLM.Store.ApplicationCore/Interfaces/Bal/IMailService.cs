using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task<bool> SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
