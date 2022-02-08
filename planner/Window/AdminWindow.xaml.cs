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

namespace planner.Window
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow 
    {
        public AdminWindow()
        {
            InitializeComponent();
            Listt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.StatusRecipe == "На валидации").ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow n = new RecipeWindow((sender as Button).DataContext as Recipes);
            n.Show();
        }

        private void btnOdobrit_Click(object sender, RoutedEventArgs e)
        {
            Recipes currentRecipe = (sender as Button).DataContext as Recipes;
            currentRecipe.StatusRecipe = "Одобрено";
            foodplanEntities.GetContext().SaveChanges();
            foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Listt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.StatusRecipe == "На валидации").ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Recipes currentRecipe = (sender as Button).DataContext as Recipes;
            foodplanEntities.GetContext().IngrRecipe.RemoveRange(foodplanEntities.GetContext().IngrRecipe.Where(b => b.IdRecipe == currentRecipe.IdRecipe));
            foodplanEntities.GetContext().Recipes.Remove(currentRecipe);
            foodplanEntities.GetContext().SaveChanges();
            foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Listt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.StatusRecipe == "На валидации").ToList();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Listt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.StatusRecipe == "На валидации").ToList();
        }
    }
}
