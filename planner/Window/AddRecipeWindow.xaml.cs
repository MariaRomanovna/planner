using Microsoft.Win32;
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

namespace planner.Window
{
    /// <summary>
    /// Логика взаимодействия для AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow 
    {
        public AddRecipeWindow()
        {
           
            InitializeComponent();
            var allCateg = foodplanEntities.GetContext().Categories.ToList();
            ComboCateg.ItemsSource = allCateg;
          
           
           
        }
        
        
        public byte[] imageBytes;
        private void Obzor_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG)| *.BMP; *.JPG; *.GIF; *.PNG | All files(*.*) | *.* ";
            if (open_dialog.ShowDialog() == true)
            {
                try
                {
                    RecImg.Source = new BitmapImage(new Uri(open_dialog.FileName));
                    imageBytes = File.ReadAllBytes(open_dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка");

                }
            }
        }


        Recipes NewRecipe = new Recipes();
        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (NR.Text.Length>1)
            {
                NewRecipe.NameRecipe = NR.Text;
            }
            else { MessageBox.Show("Длинна названия рецепта должна быть больше 6!"); }

            if (DR.Text.Length > 1)
            {
                NewRecipe.DescriptionRecipe = DR.Text;
            }
            else { MessageBox.Show("Описание рецепта должно превышать 200 символов"); }

            if (ComboCateg.SelectedItem != null)
            {
                int i = ComboCateg.SelectedIndex;
                i++;
               
                NewRecipe.IdCategory = i;
            }
            else { MessageBox.Show("Выберите категорию рецепта!"); }

            if (imageBytes != null)
            {
                NewRecipe.ImgRecipe = imageBytes;
            }
            else { MessageBox.Show("Выберите изображение рецепта!"); }

            NewRecipe.StatusRecipe = "На валидации";
            foodplanEntities.GetContext().Recipes.Add(NewRecipe);
            foodplanEntities.GetContext().SaveChanges();
            AddIngredientsWindow add = new AddIngredientsWindow(NewRecipe);
            add.Show();
            this.Hide();

            


        }
    }
}

