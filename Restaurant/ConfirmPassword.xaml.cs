using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    /// Interaction logic for ConfirmPassword.xaml
    /// </summary>
    public partial class ConfirmPassword : Window
    {
        private readonly object newpass;

        public ConfirmPassword()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

            if (textNewPass.Text == textConPass.Text)
            {
                MessageBox.Show("Password Matched and changed successfully.");
                textNewPass.Focus();
            }
            else if (!Regex.IsMatch(textNewPass.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Password not matched.");
                textNewPass.Select(0, textNewPass.Text.Length);
                textNewPass.Focus();
                Close();
            }
            
            {

                SqlConnection con = new SqlConnection("Data Source=DESKTOP-262BJ4G;Initial Catalog=EmpDB;Integrated Security=True");
                con.Open();

                string newPassword = textNewPass.Text;
                string confirmPassword = textConPass.Text;
                string sqlquery = "UPDATE [Registration] SET Password=@newpass Where Email ='" + Application.Current.Properties["Email"].ToString() + "'";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@newpass", textNewPass.Text);

                cmd.ExecuteNonQuery();
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((textNewPass.Text == reader["newPassword"].ToString()) & (textConPass.Text == (reader["confirmPassword"].ToString()))) { }
                }
                MessageBox.Show("Password Changed Successfully!");
                this.Close();
            }

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DashBoard dashBoard = new DashBoard();
           dashBoard.Show();
            Close();

        }
    }
}