using planner.View;
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

namespace planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Users NewUser = new Users();
        public MainWindow(Users user)
        {
            NewUser = user;
            InitializeComponent();
        }

        private void Plan_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new HomeView(NewUser));
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new ProfileView(NewUser));
        }

        private void AllRecipes_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new AllRecipes());
        }
    }
}
