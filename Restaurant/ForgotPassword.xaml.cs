using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {

        private string randomCode;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxEmail.Text.Trim().Length == 0)
            {

                textBoxEmail.Text = "Required";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"))
            {

                textBoxEmail.Text = "Invalid";
                textBoxEmail.Focus();
            }

            Application.Current.Properties["Email"] = textBoxEmail.Text.ToString();

            // string email;

            //email = textBoxEmail.Text;

            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("Avinashreddy521@gmail.com");
            msg.To.Add(textBoxEmail.Text);
            msg.Subject = "password reseting code";
            msg.Body = "your Reset Code is" + randomCode;
            //msg.IsBodyHtml = true;
            //var smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
            //var port = ConfigurationManager.AppSettings["Port"];
            //SmtpClient smt = new SmtpClient();
            //smt.Host = "smtp.gmail.com";
            //System.Net.NetworkCredential ntwd = new NetworkCredential();
            //ntwd.UserName = "Avinashyreddy521@gmail.com"; //Your Email ID  
            //ntwd.Password = "Avinash521"; // Your Password  
            //smt.UseDefaultCredentials = true;
            //smt.Credentials = ntwd;
            //smt.Port = 587;
            //smt.EnableSsl = true;
            //smt.Send(msg);
            // MessageBox.Show("Username and Password Sent Successfully");

            {
                var smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
                var port = ConfigurationManager.AppSettings["Port"];
                var senderEmailId = ConfigurationManager.AppSettings["SenderEmailId"];
                var senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

                var smptClient = new SmtpClient(smtpServerName, Convert.ToInt32(port))
                {
                    Credentials = new NetworkCredential(senderEmailId, senderPassword),
                    EnableSsl = true
                };
                smptClient.Send(senderEmailId, textBoxEmail.Text, msg.Subject, msg.Body);
                MessageBox.Show("Message Sent Successfully");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            ConfirmPassword ConfirmPassword = new ConfirmPassword();
            ConfirmPassword.Show();
            Close();
        }

        private void textVerBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}


