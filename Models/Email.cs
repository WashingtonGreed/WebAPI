using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Email
    {
        public string EmailOrigem { get; set; }
        public string NomeOrigem { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Retorno { get; set; }
        public Boolean Autentica { get; set; }

        public string SendEmail(Usuario usuario)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("washington.oliveira.san@gmail.com", "gearofwar");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("washington.oliveira.san@gmail.com", "ENVIADOR");
            mail.From = new MailAddress("washington.oliveira.san@gmail.com", "ENVIADOR");
            mail.To.Add(new MailAddress("washington.oliveira.san@gmail.com", "RECEBEDOR"));
            mail.Subject = "Contato";
            mail.Body = " Mensagem do site:<br/> Nome:  " + "OI" + "<br/> Email : " + "OI" + " <br/> Mensagem : " + "";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                client.Send(mail);
                return "E-mail Enviado com sucesso";
            }
            catch (System.Exception error)
            {
                return "Tente mais tarde novamente";
            }
        }


    }



}
