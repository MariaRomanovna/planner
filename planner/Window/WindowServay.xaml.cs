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
            int traditional = 0, vegan = 0, vegeterian = 0;
            if (d1.IsChecked == true)
            {
                vegeterian += 1;
                traditional += 1;
            }
            else { vegan += 1; }

            if (d2.IsChecked == true)
            {
                traditional += 1;
            }
            else { vegan += 1; vegeterian += 1; }

            if (d3.IsChecked == true)
            {
                vegan += 1; vegeterian += 1; traditional += 1;
            }

            if (d4.IsChecked == true)
            {
                vegeterian += 1; traditional += 1;
            }
            else { vegan += 1; }

            if (d5.IsChecked == true)
            {
                vegeterian += 1; traditional += 1;
            }
            else { vegan += 1; }

            if (d6.IsChecked == true)
            {
                traditional += 1;
            }
            else { vegan += 1; vegeterian += 1; }

            if (d7.IsChecked == true)
            {
                vegan += 1;
            }
            else { traditional += 1; vegeterian += 1; }

            if (d8.IsChecked == true)
            {
                traditional += 1;
            }
            else { vegan += 1; vegeterian += 1; }

            if (d9.IsChecked == true)
            {
                vegan += 1; vegeterian += 1;
            }
            else { traditional += 1; }

            if (vege.IsChecked == true) 
            {
                vegeterian += 1;
            }
            if (meat.IsChecked == true)
            {
                traditional += 1;
            }
            if (vegaan.IsChecked == true)
            {
                vegan += 1;
            }

           if(traditional>vegeterian && traditional > vegan)
            {
                NewUser.IdCategory = 1;
                MessageBox.Show("Вам присвоена категория <Традиционная>");
            }
            if (traditional < vegeterian && vegeterian > vegan)
            {
                NewUser.IdCategory = 3;
                MessageBox.Show("Вам присвоена категория <Вегетерианец>");
            }
            if (vegan > vegeterian && traditional < vegan)
            {
                NewUser.IdCategory = 2;
                MessageBox.Show("Вам присвоена категория <Веган>");
            }
            MainWindow m = new MainWindow(NewUser);
            m.Show();
        
        }

            



        }
    }

