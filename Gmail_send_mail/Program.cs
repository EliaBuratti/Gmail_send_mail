
using Google.Apis.Gmail;
using Google.Apis.Gmail.v1.Data;
using System.Net;
using System.Net.Mail;

//INSTALL Google.Apis.Gmail.v1
internal class Program
{
    private static void Main(string[] args)
    {
        InvioMail();
    }
    public static void InvioMail()
    {
        try
        {
            MailAddress Destinatario = new MailAddress("slavevitanov02@gmail.com");
            MailAddress Mittente = new MailAddress("elia.buratti.dev@gmail.com");
            MailMessage EmailInviare = new MailMessage(Mittente, Destinatario);
            EmailInviare.Subject = "Prova";
            MailAddress bcc = new MailAddress("c.mazza@q360.it");
            EmailInviare.Bcc.Add(bcc);
            EmailInviare.Body = "Prova invio mail";
            SmtpClient smtpServer = new SmtpClient();
            smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new NetworkCredential("elia.buratti.dev@gmail.com", "KEY_SMTP_GMAIL_APP");
            smtpServer.EnableSsl = true;
            smtpServer.Send(EmailInviare);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}