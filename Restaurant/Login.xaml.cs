using BAL;
using DataContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        MainWindow mainwindow = new MainWindow();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            Close();

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("Enter an email.");
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                BLLogin Bllogin = new BLLogin();
                DCLogin Dclogin = new DCLogin();
                Dclogin.Email = textBoxEmail.Text;
                Dclogin.PasswordHash = passwordBox1.Password;
                string response = Bllogin.AuthenticateUser(Dclogin);
                if (!string.IsNullOrEmpty(response))
                {
                    DashBoard dashboard = new DashBoard();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Sorry! Please enter existing emailid/password.");
                }
                //string email = textBoxEmail.Text;
                //string password = passwordBox1.Password;
                //SqlConnection con = new SqlConnection("Data Source=DESKTOP-262BJ4G;Initial Catalog=EmpDB;Integrated Security=True");
                //con.Open();
                //SqlCommand cmd = new SqlCommand("Select * from AspNetUsers where Email='" + email + "'  and PasswordHash='" + password + "'", con);
                //cmd.CommandType = CommandType.Text;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = cmd;
                //DataSet dataSet = new DataSet();
                //adapter.Fill(dataSet);
                //if (dataSet.Tables[0].Rows.Count > 0)
                //{
                //    string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                //    //  mainwindow.TextBlockName.Text = username;//Sending value from one form to another form.  
                //    DashBoard dashboard = new DashBoard();

                //    dashboard.Show();
                //    Close();
                //}
                //else
                //{
                //    MessageBox.Show("Sorry! Please enter existing emailid/password.");
                //}
                //con.Close();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
