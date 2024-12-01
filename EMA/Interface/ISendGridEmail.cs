namespace EMA.Interface
{
    public interface ISendGridEmail
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
