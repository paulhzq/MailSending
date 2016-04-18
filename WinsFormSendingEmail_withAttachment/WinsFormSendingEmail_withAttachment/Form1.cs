using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinsFormSendingEmail_withAttachment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //The smtp server of your sender email.
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("your_email_address@gmail.com");
                //to_address -- receiver email address.
                mail.To.Add("to_address");
                mail.Subject = "Test Mail - 1";
                mail.Body = "mail with attachment";
                //the path of your attachment file.
                Attachment attachment = new System.Net.Mail.Attachment("your attachment file");
                mail.Attachments.Add(attachment);
                //or port 25,depend on your smtp server.
                SmtpServer.Port = 587;
                //the sender's username,password.
                SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
