using System.Windows;
using BAL;
using DataContract;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            BLUserResgistration blUserResgistration = new BLUserResgistration();
            DCUserResgistration dcBLUserResgistration = new DCUserResgistration();

            //getting list of all users
            blUserResgistration.GetUsersSample(0);


            dcBLUserResgistration.UserID = 123;
            dcBLUserResgistration.FirstName = "Ravi";
            //inserting or uodating or deleting
            blUserResgistration.InsertUpdateUsersSample(dcBLUserResgistration);
        }
    }
}
