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

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
        {
        public DashBoard()
            {
            InitializeComponent();
            }

        private void Window_Closed(object sender , EventArgs e)
            {
            Application.Current.Shutdown();
            }

        private void btnBrand_Click(object sender , RoutedEventArgs e)
            {
            var brand = new BrandFrm();
            brand.ShowDialog();
            }

        private void btnCategory_Click(object sender , RoutedEventArgs e)
            {
            var category = new CategoryFrm();
            category.ShowDialog();
            }

        private void btnProduct_Click(object sender , RoutedEventArgs e)
            {
            var product = new ProductFrm();
            product.ShowDialog();
            }

        private void btnLogout_Click(object sender , RoutedEventArgs e)
            {
            var login = new LoginFrm();
            this.Hide();
            login.Show();
            }

        private void btnViewStock_Click(object sender , RoutedEventArgs e)
            {
            var stock = new StockFrm();
            this.Hide();
            stock.Show();
            }
        }
    }
