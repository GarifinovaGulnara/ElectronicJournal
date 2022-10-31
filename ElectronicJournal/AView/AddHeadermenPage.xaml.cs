using ElectronicJournal.Model;
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

namespace ElectronicJournal.AView
{
    /// <summary>
    /// Логика взаимодействия для AddHeadermenPage.xaml
    /// </summary>
    public partial class AddHeadermenPage : Page
    {
        public AddHeadermenPage()
        {
            InitializeComponent();
        }

        private void AddheadmenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameTB.Text == "" || NameTB.Text == "" || LoginTB.Text == "" || PassTB.Text == "")
            {
                MessageBox.Show("Введите все данны");
            }
            else
            {
                Autorization aut = new Autorization();
                {
                    aut.Login = LoginTB.Text;
                    aut.Password = PassTB.Text;
                    aut.ID_role = 2;
                }
                App.Connection.Autorization.Add(aut);
                App.Connection.SaveChanges();
                Users us = new Users();
                {
                    us.Surname = SurnameTB.Text;
                    us.Name = NameTB.Text;
                    us.Patronic = PatronicTB.Text;
                    us.NumGroup = Convert.ToInt32(LoginTB.Text);
                    us.ID_aut = aut.ID_aut;
                }
                App.Connection.Users.Add(us);
                App.Connection.SaveChanges();
                MessageBox.Show("Староста добавлен");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
