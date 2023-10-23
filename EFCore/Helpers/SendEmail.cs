using System.Net;
using System.Net.Mail;

namespace EFCore.Helpers;

public static class SendEmail
{
    
    
    public static string SendNewMail(string destinatario, string subject, string message)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.office365.com");
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("EMAIL", "SENHA");

        MailMessage mensagem = new MailMessage();
        mensagem.From = new MailAddress("EMAIL");
        mensagem.To.Add(destinatario);
        mensagem.Subject = subject;
        mensagem.Body = message;

        try
        {
            smtpClient.Send(mensagem);
            return "E-mail enviado com sucesso!";
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao enviar e-mail: " + ex.Message);
        }
    }
}