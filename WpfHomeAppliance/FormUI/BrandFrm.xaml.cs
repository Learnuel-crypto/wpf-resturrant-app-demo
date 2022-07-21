using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for BrandFrm.xaml
    /// </summary>
    public partial class BrandFrm : Window
        {
        Brand brand = ClassCreator.CreateBrand();
        public BrandFrm()
            {
            InitializeComponent();
            txtBrand.Focus();
            Data();
            }

        void Data()
            {

            dgvBrand.ItemsSource = brand.GetBrand().DefaultView;
            }
        private void dgvBrand_SelectionChanged(object sender , SelectionChangedEventArgs e)
            {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;
            if(selectedRow != null)
                {
                brand.BrandId = selectedRow["BrandId"].ToString();
                txtBrand.Text = selectedRow["Brand"].ToString();
                }
            }

        private void btnAdd_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(txtBrand.Text))
                    throw new Exception("Enter brand name");
                brand.BrandName = txtBrand.Text.Trim();
                brand.Add();
                Data();
                txtBrand.Clear();
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message , "Data error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }

            }

        private void btnUpdate_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(brand.BrandId))
                    throw new Exception("Select brand to update");
                if (string.IsNullOrEmpty(txtBrand.Text))
                    throw new Exception("Enter category name");
               brand.BrandName = txtBrand.Text.Trim();
                brand.Update();
                Data();
                txtBrand.Clear();
                brand.BrandId = null;
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message , "Data error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            }

        private void btnDelete_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(brand.BrandId))
                    throw new Exception("Select brand to delete"); 
                brand.BrandName = txtBrand.Text.Trim();
                brand.Delete();
                Data();
                txtBrand.Clear();
                brand.BrandId = null;
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message , "Data error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            }
        }
    }
