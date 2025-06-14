using System.Net;
using System.Net.Mail;
using System.Text;
using Model.Entites;

public class EmailService
{
    private readonly string smtpHost = "sandbox.smtp.mailtrap.io";
    private readonly int smtpPort = 2525;
    private readonly string smtpUsername = "ef81b3b093aa05";
    private readonly string smtpPassword = "55c47855b98a19";

    public async Task SendOrderConfirmation(
        string customerName,
        string customerAddress,
        string customerEmail,
        string customerNumber,
        Dictionary<Dish, int> items,
        decimal total,
        char orderType,
        TimeOnly plannedTime)
    {
        var body = GenerateBody(customerName, customerAddress, customerEmail, customerNumber, items, total, orderType, plannedTime);

        using var smtpClient = new SmtpClient(smtpHost)
        {
            Port = smtpPort,
            Credentials = new NetworkCredential(smtpUsername, smtpPassword),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@example.com"),
            Subject = "Bestellbestätigung",
            Body = body,
            IsBodyHtml = false
        };

        mailMessage.To.Add(customerEmail);
        await smtpClient.SendMailAsync(mailMessage);
    }

    private string GenerateBody(
        string customerName,
        string customerAddress,
        string customerEmail,
        string customerNumber,
        Dictionary<Dish, int> items,
        decimal total,
        char orderType,
        TimeOnly plannedTime)
    {
        var sb = new StringBuilder();

        // Header
        sb.AppendLine("Von: onlineshop@chiu-box.at");
        sb.AppendLine("Gesendet: " + DateTime.Now.ToString("HH:mm"));
        sb.AppendLine("An: " + customerEmail);
        sb.AppendLine();
        sb.AppendLine("Gewünschte Uhrzeit: " + plannedTime.ToString("HH:mm"));
        sb.AppendLine();
        sb.AppendLine(new string('-', 50));
        sb.AppendLine();

        // Customer Info
        sb.AppendLine(orderType == 'D' ? "Lieferadresse" : "Restaurantbestellung");
        sb.AppendLine($"Name:    {customerName}");

        if (orderType == 'D')
        {
            sb.AppendLine($"Adresse: {customerAddress}");
        }
        else
        {
            sb.AppendLine("Adresse: Obere Landstraße 5, 3500 Krems an der Donau, Niederösterreich");
        }

        sb.AppendLine($"E-Mail:  {customerEmail}");
        sb.AppendLine($"Telefon: {customerNumber}");
        sb.AppendLine();

        sb.AppendLine(new string('-', 50));
        sb.AppendLine();

        // Order Items
        sb.AppendLine("Bestellung");
        sb.AppendLine();
        sb.AppendLine(string.Format("{0,-4} {1,-30} {2,8} {3,10}", "Anz", "Artikel", "Einzel", "Gesamt"));
        sb.AppendLine();
        sb.AppendLine(new string('-', 50));
        foreach (var item in items)
        {
            var dish = item.Key;
            var quantity = item.Value;
            var lineTotal = dish.Price * quantity;

            sb.AppendLine(string.Format("{0,-4} {1,-30} {2,8:C} {3,10:C}",
                quantity,
                dish.Name,
                dish.Price,
                lineTotal));
        }

        sb.AppendLine(new string('-', 50));
        sb.AppendLine(string.Format("{0,-36} {1,10:C}", "Total", total));
        sb.AppendLine();
        sb.AppendLine("Mit freundlichen Grüßen,");
        sb.AppendLine();
        sb.AppendLine("Tai Yang");
        sb.AppendLine("Jo-han Chiu e.U.");
        sb.AppendLine("Chinarestaurant TAI YANG");
        sb.AppendLine("Obere Landstraße 5");
        sb.AppendLine("3500 Krems an der Donau, Niederösterreich");
        sb.AppendLine("FN 531236f");

        return sb.ToString();
    }
}
