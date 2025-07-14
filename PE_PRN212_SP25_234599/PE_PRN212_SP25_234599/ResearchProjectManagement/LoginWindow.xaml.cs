using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BAL.Services;

namespace ResearchProjectManagement_SE171151
{
    /// <summary>
    /// Interaction logic for LoginWindw.xaml
    /// </summary>
    public partial class LoginWindw : Window
    {
        private UserAccountService _service;

        public LoginWindw()
        {
            InitializeComponent();
            _service = new();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = _service.Login(EmailTextBox.Text, PasswordTextBox.Text);
            if (login != null)
            {
                MainWindow main = new();
                main.UserAccount = login;
                main.Show();
                this.Close();
                return;
            }

            MessageBox.Show("You have no permission to access this function!");
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            EmailTextBox.Text = "";
            PasswordTextBox.Text = "";
        }
    }
}
