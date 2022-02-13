using planner.Window;
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

namespace planner.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        private Users NewUser = new Users();
        public HomeView(Users user)
        {
            NewUser = user;
            InitializeComponent();
            foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Listt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe=="Одобрено").OrderBy(p=>p.IdRecipe).Take(2).Skip(1).ToList();
            ListVt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();
            ListSr.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();
            ListCh.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();
            ListPt.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();
            ListSub.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();
            ListVs.ItemsSource = foodplanEntities.GetContext().Recipes.Where(b => b.IdCategory == NewUser.IdCategory && b.StatusRecipe == "Одобрено").OrderBy(p => p.IdRecipe).ToList();

       

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow n = new RecipeWindow((sender as Button).DataContext as Recipes);
            n.Show();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }
       
    }
}
