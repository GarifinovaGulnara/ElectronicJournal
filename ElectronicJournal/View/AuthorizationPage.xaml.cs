using ElectronicJournal.AView;
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

namespace ElectronicJournal.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        ElectronicJournalEntities eljournal = new ElectronicJournalEntities();
        
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Autorization> autorizations = eljournal.Autorization.ToList();
                Autorization aut = autorizations.FirstOrDefault(p => p.Password == PassPB.Password && p.Login == LoginTB.Text);
                
                if(aut == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                    return;
                }
                else
                {
                    if(aut.ID_role == 2)
                    {
                        List<Users> user = eljournal.Users.ToList();
                        Users us = user.FirstOrDefault(x => x.ID_aut == aut.ID_aut);
                        NavigationService.Navigate(new SkipListPage(Convert.ToInt32(us.NumGroup)));
                    }
                    else
                    {
                        NavigationService.Navigate(new AllStudentsListPage());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
