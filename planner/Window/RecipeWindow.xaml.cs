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
    /// Логика взаимодействия для RecipeWindow.xaml
    /// </summary>
    public partial class RecipeWindow 
    {
        private Recipes _currentrecipe = new Recipes();
        public RecipeWindow(Recipes recipe1)
        {
            if (recipe1 != null)
                _currentrecipe = recipe1;
         
            InitializeComponent();
            DataContext = _currentrecipe;
           
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                
                foodplanEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridIngr.ItemsSource = foodplanEntities.GetContext().IngrRecipe.Where(b=>b.IdRecipe==_currentrecipe.IdRecipe).ToList();
            }
        }
    }
}
