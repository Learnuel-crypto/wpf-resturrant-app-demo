using System;
using System.Windows;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for SignUpFrm.xaml
    /// </summary>
    public partial class SignUpFrm : Window
        {
        User newUser = ClassCreator.CreateUser();
        public SignUpFrm()
            {
            InitializeComponent();
            txtUsername.Focus();
            }

        private void btnClose_Click(object sender , RoutedEventArgs e)
            {
            var login = new LoginFrm();
            this.Close();
            login.Show();
            }

        private void btnSignup_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(txtUsername.Text))
                    throw new Exception("Enter username");
                if (string.IsNullOrEmpty(txtPassword.Password))
                    throw new Exception("Enter password");
                if (string.IsNullOrEmpty(txtConfirmPassword.Password))
                    throw new Exception("Confirm password");
                if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
                    throw new Exception("Password did not match");
                newUser.Username = txtUsername.Text.Trim();
                newUser.Password = txtPassword.Password;
                newUser.Register();
                MessageBox.Show("Sign up completed, please login" , "Successful" , MessageBoxButton.OK , MessageBoxImage.Information);
                var login = new LoginFrm();
                this.Close();
                login.Show();
                }
            catch (Exception ex)
                { 
                MessageBox.Show(ex.Message , "Sign up error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            }
        }
    }
