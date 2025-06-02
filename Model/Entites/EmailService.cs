using System.Net;
using System.Net.Mail;
using System.Text;
using Model.Entites;

public class EmailService
{
    private readonly string smtpHost = "sandbox.smtp.mailtrap.io";
    private readonly int smtpPort = 2525;
    private readonly string smtpUsername = "d1b8cdf3708cfe";
    private readonly string smtpPassword = "3f8961d6618b58";

    public async Task SendOrderConfirmation(
        string toEmail,
        string restaurantName,
        string restaurantAddress,
        List<Dish> items)
    {
        var body = GenerateBody(toEmail, restaurantName, restaurantAddress, items);

        using var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@example.com"),
            Subject = "Order Confirmation",
            Body = body,
            IsBodyHtml = false
        };

        mailMessage.To.Add(toEmail);
        await smtpClient.SendMailAsync(mailMessage);
    }

    private string GenerateBody(string customerEmail, string restaurantName, string restaurantAddress, List<Dish> items)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"To: {customerEmail}");
        sb.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd}");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"Tai Yang");
        sb.AppendLine($"Jo-han Chiu e.U.\nChinarestaurant TAI YANG\nObere Landstraße 5\n3500 Krems an der Donau, Niederösterreich\nFN 531236f");
        sb.AppendLine("\nBestellung:");

        foreach (var item in items)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
                sb.AppendLine($"- 1x {item.Name}    {item.Price}        {item.Price}");
        }

        return sb.ToString();
    }
}