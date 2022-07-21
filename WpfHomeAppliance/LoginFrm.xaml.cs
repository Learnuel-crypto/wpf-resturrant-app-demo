using System;
using System.Windows;
using WpfHomeAppliance.DataModel;
using WpfHomeAppliance.FormUI;

namespace WpfHomeAppliance
    {
    /// <summary>
    /// Interaction logic for LoginFrm.xaml
    /// </summary>
    public partial class LoginFrm : Window
        {
        User user = ClassCreator.CreateUser();
        public LoginFrm()
            {
            InitializeComponent();
            txtUsername.Focus();
            }

        private void btnRegister_Click(object sender , RoutedEventArgs e)
            {
            var signUp = new SignUpFrm();
            this.Hide();
            signUp.Show();
            }

        private void btnClose_Click(object sender , RoutedEventArgs e)
            {
              Application.Current.Shutdown();
            }

        private void btnLogin_Click(object sender , RoutedEventArgs e)
            {

            try
                {
                if (string.IsNullOrEmpty(txtUsername.Text))
                    throw new Exception("Enter username");
                if (string.IsNullOrEmpty(txtPassword.Password))
                    throw new Exception("Enter password"); 
                user.Username = txtUsername.Text.Trim();
                user.Password = txtPassword.Password;
                if (user.Login())
                    {
                    var dashboard = new DashBoard();
                    this.Hide();
                    dashboard.Show();
                    }
                else
                    {
                    throw new Exception("Incorrect username or password");
                    } 
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message , "Sign in error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            }
        }
    }
