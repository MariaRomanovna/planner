using planner.Window;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace planner.View
{
    /// <summary>
    /// Логика взаимодействия для AllRecipes.xaml
    /// </summary>
    public partial class AllRecipes : Page
    {
        public AllRecipes()
        {
            InitializeComponent();
            //foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var allCateg = foodplanEntities.GetContext().Categories.ToList();
            allCateg.Insert(0, new Categories
            {
                NameCategory = "Все категории"
            });
            ComboCategory.ItemsSource = allCateg;
            ComboCategory.SelectedIndex = 0;
            UpdateRecipes();

        }
        private void UpdateRecipes()
        {
            var currentRecipe = foodplanEntities.GetContext().Recipes.ToList();

            if (ComboCategory.SelectedIndex > 0)
            {
                currentRecipe = currentRecipe.Where(p => p.IdCategory == ComboCategory.SelectedIndex).ToList();
            }
            currentRecipe = currentRecipe.Where(b => b.NameRecipe.ToLower().Contains(FindBox.Text.ToLower())).ToList();
            Listt.ItemsSource = currentRecipe.ToList();

        }

        private void FindBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateRecipes();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow n = new RecipeWindow((sender as Button).DataContext as Recipes);
            n.Show();
        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRecipes();
        }
    }
}
