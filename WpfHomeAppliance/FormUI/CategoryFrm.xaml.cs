using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance.FormUI
    {
    /// <summary>
    /// Interaction logic for CategoryFrm.xaml
    /// </summary>
    public partial class CategoryFrm : Window
        {
        Category category = ClassCreator.CreateCategory();
        public CategoryFrm()
            {
            InitializeComponent();
            txtCategory.Focus();
            Data();
            }

        void Data()
            {
            dgvCategory.ItemsSource = category.GetCategory().DefaultView;
            }
        private void dgvBrand_SelectionChanged(object sender , SelectionChangedEventArgs e)
            {
            DataGrid dg = (DataGrid)sender;
            DataRowView _selectedRow = dg.SelectedItem as DataRowView;
            if(_selectedRow != null)
                {
                category.CatId = _selectedRow["CatId"].ToString() ;
                txtCategory.Text = _selectedRow["Category"].ToString();
                }
            }

        private void btnAdd_Click(object sender , RoutedEventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty(txtCategory.Text))
                    throw new Exception("Enter category name");
                category.CategoryName = txtCategory.Text.Trim();
                category.Add();
                Data();
                txtCategory.Clear();
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
                if (string.IsNullOrEmpty(category.CatId))
                    throw new Exception("Select category to update");
                if (string.IsNullOrEmpty(txtCategory.Text))
                    throw new Exception("Enter category name");
                category.CategoryName = txtCategory.Text.Trim();
                category.Update();
                Data();
                txtCategory.Clear();
                category.CatId = null;
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
                if (string.IsNullOrEmpty(category.CatId))
                    throw new Exception("Select category to delete"); 
                category.Delete();
                Data();
                txtCategory.Clear();
                category.CatId = null;
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message , "Data error" , MessageBoxButton.OK , MessageBoxImage.Information);
                }
            }
        }
    }
