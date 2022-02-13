using Microsoft.AspNetCore.Identity.UI.Services;

namespace FruitsTraceabilitySystem.Application.Services.EmailSender
{
    public class EmailSenderService : IEmailSender
    {
        #region Methods
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
        #endregion
    }
}
