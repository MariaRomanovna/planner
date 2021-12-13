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

            a1.ItemsSource = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 1).ToList();
            
            a2.ItemsSource = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 2).ToList();
            a3.ItemsSource = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 3).ToList();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Answers an1 = new Answers();
            an1 = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 1).FirstOrDefault();
            Answers an2 = new Answers();
            an2 = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 2).FirstOrDefault();
            Answers an3 = new Answers();
            an3 = foodplanEntities.GetContext().Answers.Where(b => b.IdQuestion == 3).FirstOrDefault();

            if (a1.SelectedItem== an1)
            {
                NewUser.IdSurvey = 1;
                NewUser.IdCategory = 1;
                foodplanEntities.GetContext().SaveChanges();
                MessageBox.Show("Вы мясоед");
                MainWindow n = new MainWindow(NewUser);
                n.Show();
                this.Hide();
            }
            else if(a2.SelectedItem == an2)
            {
                NewUser.IdSurvey = 3;
                NewUser.IdCategory = 3;
                foodplanEntities.GetContext().SaveChanges();
                MessageBox.Show("Вы вегетерианец");
                MainWindow n = new MainWindow(NewUser);
                n.Show();
                this.Hide();
            }
            else if (a3.SelectedItem == an3)
            {
                NewUser.IdSurvey = 2;
                NewUser.IdCategory = 2;
                foodplanEntities.GetContext().SaveChanges();
                MessageBox.Show("Вы веган");
                MainWindow n = new MainWindow(NewUser);
                n.Show();
                this.Hide();
            }
            
            else { MessageBox.Show("Выберите ответы!"); }
        }
    }
}
