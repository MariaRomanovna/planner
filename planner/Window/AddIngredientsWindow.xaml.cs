using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddIngredientsWindow.xaml
    /// </summary>
    public partial class AddIngredientsWindow 
    {
        private Recipes currentRecipe;
        public AddIngredientsWindow(Recipes NewRecipe)
        {
            currentRecipe = NewRecipe;
            InitializeComponent();
            var allIngr = foodplanEntities.GetContext().Ingredients.ToList();
            ComboIngred.ItemsSource = allIngr;
            
        }

  

   

        private void AddFromList_Click(object sender, RoutedEventArgs e)
        {
            if (ComboIngred.SelectedIndex != null)
            {
                IngrRecipe iR = new IngrRecipe();
                iR.IdRecipe = currentRecipe.IdRecipe;
                ListIngr.Items.Add(ComboIngred.SelectedItem);
                Ingredients ii = foodplanEntities.GetContext().Ingredients.Where(b => b.NameIngredient == ComboIngred.Text).FirstOrDefault();
                iR.IdIngredient = ii.IdIngredient;
                if (kolich.Text.EndsWith(","))
                {
                    MessageBox.Show("Поставьте вместо запятой точку");
                }
                else { iR.Quantity = Convert.ToDouble(kolich.Text); }
               
                foodplanEntities.GetContext().IngrRecipe.Add(iR);
                foodplanEntities.GetContext().SaveChanges();
              
                MessageBox.Show($"Вы добавили ингредиент {ComboIngred.Text} \n в количестве {kolich.Text} кг");
                
            }
        }

        private void Safe_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
