using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace planner.Window
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow
       
    {
        private Users NewUser;
        public EditUserWindow(Users user)
        {
        NewUser = user;
            InitializeComponent();
            Name.Text = NewUser.NameUser;
            Pass.Text = NewUser.Password;
            Email.Text = NewUser.Email;
           
        }
       

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
             NewUser.NameUser = Name.Text;
            NewUser.Password = Pass.Text;
           NewUser.Email = Email.Text;
           
            foodplanEntities.GetContext().Entry(NewUser).State= EntityState.Modified;
            foodplanEntities.GetContext().SaveChanges();
           
            MessageBox.Show("Ваши данные изменены и сохранены!");
        }
    }
}
