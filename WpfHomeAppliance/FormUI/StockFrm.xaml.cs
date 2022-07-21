using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for StockFrm.xaml
    /// </summary>
    public partial class StockFrm : Window
        {
        
        Product product =ClassCreator.CreateProduct();
        public StockFrm()
            {
            InitializeComponent();
            txtProduct.Focus();
            GetData();
            }

        void GetData()
            {
            cmbBrand.ItemsSource = product.GetBrand().DefaultView;
            cmbBrand.DisplayMemberPath = "Brand";
            cmbCategory.ItemsSource = product.GetCategory().DefaultView;
            cmbCategory.DisplayMemberPath = "Category";
            dgvStock.ItemsSource = product.GetProducts().DefaultView;
            }
        
        private void dgvStock_SelectionChanged(object sender , SelectionChangedEventArgs e)
            {
            DataGrid dg = (DataGrid)sender;
            DataRowView _selectedRow = dg.SelectedItem as DataRowView;
            if(_selectedRow != null)
                {
                product.ProId = _selectedRow["ProId"].ToString();
                txtProduct.Text = _selectedRow["Name"].ToString();
                txtqty.Text = _selectedRow["Qty"].ToString();
                txtPrice.Text = _selectedRow["Price"].ToString();
                cmbBrand.Text = _selectedRow["Brand"].ToString();
                cmbCategory.Text = _selectedRow["Category"].ToString();
                }
            }

        private void btnback_Click(object sender , RoutedEventArgs e)
            {
            var dashboard = new DashBoard();
            this.Close();
            dashboard.Show();
            }
        void Clear()
            {
            txtProduct.Clear();
            txtqty.Clear();
            txtPrice.Clear();
            cmbCategory.Text = "";
            cmbBrand.Text = "";
            }
        private void btnUpdate_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(product.ProId))
                    throw new Exception("Select product to update");
                if (string.IsNullOrEmpty(txtProduct.Text))
                    throw new Exception("Enter product name");
                if (string.IsNullOrEmpty(txtqty.Text))
                    throw new Exception("Enter quantity");
                if (string.IsNullOrEmpty(cmbCategory.Text))
                    throw new Exception("Select Category");
                if (string.IsNullOrEmpty(cmbBrand.Text))
                    throw new Exception("Select brand");
                if (string.IsNullOrEmpty(txtPrice.Text))
                    throw new Exception("Enter price");

                product.Name = txtProduct.Text.Trim();
                product.Quantity = Int32.Parse(txtqty.Text.Trim());
                product.BrandName = cmbBrand.Text;
                product.CategoryName = cmbCategory.Text;
                product.Price = Convert.ToDecimal(txtPrice.Text);

                product.UpdateProduct();
                Clear();
                GetData();
                product.ProId = null;
                MessageBox.Show("Product updated successfully" , "Complete" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            catch (Exception ex)
                {

                MessageBox.Show(ex.Message , "Update error" , MessageBoxButton.OK , MessageBoxImage.Information);

                }
            }

        private void btnDelete_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(product.ProId))
                    throw new Exception("Select product to delete");
                product.DeleteProduct();
                Clear();
                product.ProId = null;
                GetData();
               
                MessageBox.Show("Product deleted successfully" , "Complete" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            catch (Exception ex)
                {

                MessageBox.Show(ex.Message , "Delete error" , MessageBoxButton.OK , MessageBoxImage.Information);

                }
            }
        }
    }
