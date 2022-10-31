using ElectronicJournal.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectronicJournal.AView
{
    /// <summary>
    /// Логика взаимодействия для HeadermenListPage.xaml
    /// </summary>
    public partial class HeadermenListPage : Page
    {
        public HeadermenListPage()
        {
            InitializeComponent();
            HeadermenLV.ItemsSource = App.Connection.Users.Where(z=>z.Autorization.ID_role == 2).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveChengesListBtn_Click(object sender, RoutedEventArgs e)
        {
            App.Connection.SaveChanges();
        }

        private void AddHeadermenBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHeadermenPage());
        }
    }
}
