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
    /// Логика взаимодействия для WindowServay.xaml
    /// </summary>
    public partial class WindowServay
    {
        private Users NewUser = new Users();
        public WindowServay(Users user)
        {
            NewUser = user;
            InitializeComponent();

           
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            

            
        }
    }
}
