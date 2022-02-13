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
    /// Логика взаимодействия для ProfileView.xaml
    /// </summary>
    public partial class ProfileView : Page
    {
        private Users NewUser = new Users();
        public ProfileView(Users user)
        {
            NewUser = user;
            InitializeComponent();
            Name.Text = NewUser.NameUser;
            Pass.Text = NewUser.Password;
            Email.Text = NewUser.Email;
            
            Surveys ser = new Surveys();
            ser = foodplanEntities.GetContext().Surveys.Where(b => b.IdSurvey == NewUser.IdSurvey).FirstOrDefault();
            servay1.Text = ser.NameSurvey;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow add = new AddRecipeWindow();
            add.Show();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow ee = new EditUserWindow(NewUser);
            ee.Show();
            
        }
    }
}
