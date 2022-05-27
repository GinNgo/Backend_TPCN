using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailUtils
{
    public class MailUtils
    {
        public static async Task<string> SendMail(string _form, string _to, string _subject,string _body)
        {
            MailMessage message = new MailMessage(_form, _to, _subject, _body);
            message.BodyEncoding=System.Text.Encoding.UTF8;
            message.SubjectEncoding=System.Text.Encoding.UTF8;
            message.IsBodyHtml=true;
            message.ReplyToList.Add(new MailAddress(_form));
            message.Sender = new MailAddress(_form);

            using var smtpClient = new SmtpClient("localhost");
            try
            {
               await smtpClient.SendMailAsync(message);
                return "gui thanh cong";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "gui that bai";
            }

        }
        public static async Task<string> SendGmail(string _form, string _to, string _subject, string _body, string _gmail,string _passwork)
        {
            MailMessage message = new MailMessage(_form, _to, _subject, _body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.ReplyToList.Add(new MailAddress(_form));
            message.Sender = new MailAddress(_form);

            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; 
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_gmail, _passwork);
            try
            {
                await smtpClient.SendMailAsync(message);
                return "gui thanh cong";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "gui that bai";
            }

        }
    }
}