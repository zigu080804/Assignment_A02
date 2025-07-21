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
    /// Interaction logic for CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : Window
    {
        public Category Category { get; private set; }
        public Category CurrentCategory { get; set; }

        // Constructor for Add
        private byte[] selectedImageData;

        public CategoryForm()
        {
            InitializeComponent();
            Category = new Category();
            DataContext = Category;
        }

        // Constructor for Edit
        public CategoryForm(Category existingCategory)
        {
            InitializeComponent();
            Category = new Category
            {
                CategoryId = existingCategory.CategoryId,
                CategoryName = existingCategory.CategoryName,
                Description = existingCategory.Description,
                Picture = existingCategory.Picture
            };

            DataContext = Category;

            if (Category.Picture != null)
            {
                LoadImagePreview(Category.Picture);
            }
        }




        private void LoadImagePreview(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                imgPreview.Source = null;
                return;
            }

            try
            {
                using (var stream = new MemoryStream(imageData))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                    image.Freeze();

                    imgPreview.Source = image;
                }
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show("Unsupported image format. Please choose a valid .jpg/.jpeg/.png image.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not display image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private string selectedImagePath = null;
        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    selectedImageData = imageBytes; // 🟢 Gán vào selectedImageData
                    Category.Picture = imageBytes;
                    LoadImagePreview(imageBytes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }








        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving category: " + ex.Message);
            }
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
