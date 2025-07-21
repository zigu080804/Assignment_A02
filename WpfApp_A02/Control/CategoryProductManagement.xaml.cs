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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects_A02;
using Services_A02;
using WpfApp_A02.Views;
namespace WpfApp_A02.Control
{
    /// <summary>
    /// Interaction logic for CategoryProductManagement.xaml
    /// </summary>
    public partial class CategoryProductManagement : System.Windows.Controls.UserControl
    {
        
            private readonly ICategoryService _categoryService;
            private readonly IProductService _productService;

            public CategoryProductManagement()
            {
                InitializeComponent();
                _categoryService = new CategoryService();
                _productService = new ProductService();

                LoadAllData();
            }

            private void LoadAllData()
            {
                LoadCategories();
                LoadProducts();
            }

            private void LoadCategories()
            {
                dgCategories.ItemsSource = _categoryService.GetAllCategories();
            }

            private void LoadProducts()
            {
                dgProducts.ItemsSource = _productService.GetAllProducts();
            }

            // ---------- CATEGORY EVENTS ----------

            private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
            {
                var addForm = new CategoryForm(); // Giả sử bạn có 1 form popup
                if (addForm.ShowDialog() == true)
                {
                    _categoryService.AddCategory(addForm.Category);
                    LoadCategories();
                }
            }

            private void BtnEditCategory_Click(object sender, RoutedEventArgs e)
            {
                if (dgCategories.SelectedItem is Category selectedCategory)
                {
                    var editForm = new CategoryForm(selectedCategory); // Truyền dữ liệu vào form
                    if (editForm.ShowDialog() == true)
                    {
                        _categoryService.UpdateCategory(editForm.Category);
                        LoadCategories();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to edit.", "No Selection");
                }
            }

            private void BtnDeleteCategory_Click(object sender, RoutedEventArgs e)
            {
                if (dgCategories.SelectedItem is Category selectedCategory)
                {
                    var confirm = MessageBox.Show(
                        $"Are you sure you want to delete category '{selectedCategory.CategoryName}'?",
                        "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (confirm == MessageBoxResult.Yes)
                    {
                        _categoryService.DeleteCategory(selectedCategory.CategoryId);
                        LoadCategories();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to delete.", "No Selection");
                }
            }

        // ---------- PRODUCT EVENTS ----------
        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var categories = _categoryService.GetAllCategories();
            var addForm = new ProductForm(categories); // ✅ gọi đúng constructor

            if (addForm.ShowDialog() == true)
            {
                _productService.AddProduct(addForm.Product);
                LoadProducts();
                MessageBox.Show("Add Product Successfully");
            }
        }


        // NÚT EDIT
        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                var categories = _categoryService.GetAllCategories();
                var editForm = new ProductForm(selectedProduct, categories); // ✅ gọi đúng constructor

                if (editForm.ShowDialog() == true)
                {
                    var updated = editForm.Product;
                    updated.ProductId = selectedProduct.ProductId;
                    _productService.UpdateProduct(updated);
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "No Selection");
            }
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selectedProduct)
            {
                var confirm = MessageBox.Show(
                    $"Are you sure you want to delete product '{selectedProduct.ProductName}'?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (confirm == MessageBoxResult.Yes)
                {
                    _productService.DeleteProduct(selectedProduct.ProductId);
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Image image && image.DataContext is Category category)
            {
                if (category.Picture != null && category.Picture.Length > 78)
                {
                    try
                    {
                        // Cắt bỏ 78 byte đầu – đây là OLE header (Northwind chuẩn)
                        byte[] imageData = category.Picture;

                        // Kiểm tra nếu là ảnh kiểu Northwind có OLE header (78 bytes)
                        if (category.Picture.Length > 78 &&
                            category.Picture[0] == 0x15 && category.Picture[1] == 0x1C)
                        {
                            // Đây là OLE header, loại bỏ 78 bytes đầu
                            imageData = category.Picture.Skip(78).ToArray();
                        }


                        using var stream = new MemoryStream(imageData);
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                        bitmap.Freeze(); // Tránh lỗi thread

                        image.Source = bitmap;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Image load error: {ex.Message}");
                    }
                }
            }
        }


    }
}