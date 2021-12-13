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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration 
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
           
           string login = TextLogin.Text;
            string pass = TextPass.Text;
            string pass1 = TextPass1.Text;
            string email = TextEmail.Text;

            Users NewUser = new Users();
            NewUser.NameUser = login;
            NewUser.Password = pass;
            NewUser.Email = email;
            NewUser.TypeUser = 0;
            if (login.Length < 5)
            {
                MessageBox.Show("Длина логина должна быть больше 5!");

            }
            else if (pass.Length < 5)
            {
                MessageBox.Show("Длина пароля должна быть больше 5!");

            }
            else if (pass != pass1)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else
            {
                Users authUser = null;
                using (foodplanEntities db = new foodplanEntities())
                {
                    authUser = db.Users.Where(b => b.NameUser == login && b.Email == email).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Такой логин или почта уже существует!");
                   
                }
                else
                {
                    
                    foodplanEntities.GetContext().Users.Add(NewUser);
                    foodplanEntities.GetContext().SaveChanges();
                    MessageBox.Show($"Вы успешно зарегистрировались!");
                    WindowServay n = new WindowServay(NewUser);
                    n.Show();

                }
            }
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            Authorize auth = new Authorize();
            auth.Show();
            this.Hide();
        }
    }
}

