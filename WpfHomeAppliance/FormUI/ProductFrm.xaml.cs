using System;
using System.Windows;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for ProductFrm.xaml
    /// </summary>
    public partial class ProductFrm : Window
        {
        Product product = ClassCreator.CreateProduct();
        public ProductFrm()
            {
            InitializeComponent();
            txtProduct.Focus();
            LoadData();
            }

        private void btnSubmit_Click(object sender , RoutedEventArgs e)
            {
            try
                {
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
                product.Quantity =Int32.Parse( txtqty.Text.Trim());
                product.BrandName = cmbBrand.Text;
                product.CategoryName = cmbCategory.Text;
                product.Price = Convert.ToDecimal(txtPrice.Text);

                product.AddProduct();
                Clear();
                LoadData();
                MessageBox.Show("Product add successfully" , "Complete" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            catch (Exception ex)
                {
                
                MessageBox.Show(ex.Message , "Data error" , MessageBoxButton.OK , MessageBoxImage.Information);
                
            }
            }
        void LoadData()
            {
            cmbCategory.ItemsSource = product.GetCategory().DefaultView;
            cmbCategory.DisplayMemberPath = "Category";
            cmbBrand.ItemsSource = product.GetBrand().DefaultView;
            cmbBrand.DisplayMemberPath = "Brand";
            }
        void Clear()
            {
            txtProduct.Clear();
            txtqty.Clear();
            txtPrice.Clear();
            cmbCategory.Text = "";
            cmbBrand.Text = "";
            }
        private void btnRest_Click(object sender , RoutedEventArgs e)
            {
            Clear();
            }

        private void btnBack_Click(object sender , RoutedEventArgs e)
            {
            this.Close();
            }
        }
    }
