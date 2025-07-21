using System;
using System.Collections.Generic;
using System.IO;
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
using BusinessObjects_A02;
using Microsoft.Win32;

namespace WpfApp_A02.Views
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Window
    {
        public Product Product { get; private set; }
        public string ProductName => txtProductName.Text;
        public string QuantityPerUnit => txtQuantityPerUnit.Text;
        public decimal UnitPrice => decimal.TryParse(txtUnitPrice.Text, out var price) ? price : 0;
        public short UnitsInStock => short.TryParse(txtUnitsInStock.Text, out var stock) ? stock : (short)0;
        public short UnitsOnOrder => short.TryParse(txtUnitsOnOrder.Text, out var order) ? order : (short)0;
        public short ReorderLevel => short.TryParse(txtReorderLevel.Text, out var reorder) ? reorder : (short)0;
        public bool Discontinued => chkDiscontinued.IsChecked == true;
        public int SelectedCategoryId => cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0;
        private List<Category> _categories;
        public Product product { get; set; }


        public ProductForm(List<Category> categories)
        {
            InitializeComponent();
            _categories = categories;
            LoadCategories(_categories);
        }



        // ✅ Constructor nhận product
        public ProductForm(Product product, List<Category> categories)
        {
            InitializeComponent();
            _categories = categories;
            LoadCategories(_categories);
            SetInitialData(product);
        }

        public void LoadCategories(List<Category> categories)
        {
            cmbCategory.ItemsSource = categories;
            cmbCategory.DisplayMemberPath = "CategoryName";
            cmbCategory.SelectedValuePath = "CategoryId";
        }

        //private void ChooseImage_Click(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new OpenFileDialog
        //    {
        //        Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        //    };

        //    if (dialog.ShowDialog() == true)
        //    {
        //        PictureData = File.ReadAllBytes(dialog.FileName);

        //        using var stream = new MemoryStream(PictureData);
        //        var bitmap = new BitmapImage();
        //        bitmap.BeginInit();
        //        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        //        bitmap.StreamSource = stream;
        //        bitmap.EndInit();
        //        bitmap.Freeze();
        //        imgPreview.Source = bitmap;
        //    }
        //}

        public Product GetProduct(int productId = 0)
        {
            return new Product
            {
                ProductId = productId,
                ProductName = ProductName,
                QuantityPerUnit = QuantityPerUnit,
                UnitPrice = UnitPrice,
                UnitsInStock = UnitsInStock,
                UnitsOnOrder = UnitsOnOrder,
                ReorderLevel = ReorderLevel,
                Discontinued = Discontinued,
                CategoryId = SelectedCategoryId
            };
        }

        public void SetInitialData(Product product)
        {
            txtProductName.Text = product.ProductName;
            txtQuantityPerUnit.Text = product.QuantityPerUnit;
            txtSupplierId.Text = product.SupplierId?.ToString() ?? "";
            txtUnitPrice.Text = product.UnitPrice?.ToString() ?? "";
            txtUnitsInStock.Text = product.UnitsInStock?.ToString() ?? "";
            txtUnitsOnOrder.Text = product.UnitsOnOrder?.ToString() ?? "";
            txtReorderLevel.Text = product.ReorderLevel?.ToString() ?? "";
            chkDiscontinued.IsChecked = product.Discontinued;
            cmbCategory.SelectedValue = product.CategoryId;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var errors = new List<string>();

            // Validate ProductName (required)
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
                errors.Add("Product Name is required.");

            // Validate SupplierId (optional, but must be int if entered)
            if (!string.IsNullOrWhiteSpace(txtSupplierId.Text) &&
                !int.TryParse(txtSupplierId.Text, out _))
                errors.Add("Supplier ID must be a valid integer.");

            // Validate UnitPrice (optional, must be decimal if entered)
            if (!string.IsNullOrWhiteSpace(txtUnitPrice.Text) &&
                !decimal.TryParse(txtUnitPrice.Text, out _))
                errors.Add("Unit Price must be a valid number.");

            // Validate UnitsInStock (optional, must be int if entered)
            if (!string.IsNullOrWhiteSpace(txtUnitsInStock.Text) &&
                !int.TryParse(txtUnitsInStock.Text, out _))
                errors.Add("Units In Stock must be a valid integer.");

            // Validate UnitsOnOrder (optional, must be int if entered)
            if (!string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text) &&
                !int.TryParse(txtUnitsOnOrder.Text, out _))
                errors.Add("Units On Order must be a valid integer.");

            // Validate ReorderLevel (optional, must be int if entered)
            if (!string.IsNullOrWhiteSpace(txtReorderLevel.Text) &&
                !int.TryParse(txtReorderLevel.Text, out _))
                errors.Add("Reorder Level must be a valid integer.");

            // Validate Category (optional, must be selected if set)
            if (cmbCategory.SelectedValue != null &&
                !int.TryParse(cmbCategory.SelectedValue.ToString(), out _))
                errors.Add("Category selection is invalid.");

            // Show errors if any
            if (errors.Any())
            {
                MessageBox.Show(string.Join("\n", errors), "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // If all validations pass, create the Product object
            Product = new Product
            {
                ProductName = txtProductName.Text.Trim(),
                SupplierId = string.IsNullOrWhiteSpace(txtSupplierId.Text) ? null : int.Parse(txtSupplierId.Text),
                CategoryId = cmbCategory.SelectedValue != null ? (int?)cmbCategory.SelectedValue : null,
                QuantityPerUnit = string.IsNullOrWhiteSpace(txtQuantityPerUnit.Text) ? null : txtQuantityPerUnit.Text.Trim(),
                UnitPrice = string.IsNullOrWhiteSpace(txtUnitPrice.Text) ? null : decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = string.IsNullOrWhiteSpace(txtUnitsInStock.Text) ? null : int.Parse(txtUnitsInStock.Text),
                UnitsOnOrder = string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text) ? null : int.Parse(txtUnitsOnOrder.Text),
                ReorderLevel = string.IsNullOrWhiteSpace(txtReorderLevel.Text) ? null : int.Parse(txtReorderLevel.Text),
                Discontinued = chkDiscontinued.IsChecked == true
            };

            // Đóng form và báo thành công
            DialogResult = true;
            Close();
        }
    }
}