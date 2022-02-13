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
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize
    {
        public Authorize()
        {
           
            InitializeComponent();
           
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string login = TextLogin.Text;
            string pass = TextPass.Text;
            if (login.Length < 5)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");
               
            }
            else if (pass.Length < 5)
            {
                MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста проверьте ещё раз введенные данные");
              
            }

            else
            {
                
                    Users authUser = null;
                    using (foodplanEntities db = new foodplanEntities())
                    {
                        authUser = db.Users.Where(b => b.NameUser == login && b.Password == pass).FirstOrDefault();
                    }
                if (authUser.TypeUser == 0)
                {
                    if (authUser != null)
                    {
                        MessageBox.Show("Вы успешно вошли в систему!");
                        MainWindow n = new MainWindow(authUser);
                        n.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так, проверьте введённые данные!");

                    }
                }
                else
                { 
                    AdminWindow a = new AdminWindow();
                    a.Show();
                }
                   
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }
    }
}
