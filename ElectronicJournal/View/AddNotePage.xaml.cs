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
    /// Логика взаимодействия для AddNotePage.xaml
    /// </summary>
    public partial class AddNotePage : Page
    {
        public int NumGroupHeadmen;
        public AddNotePage(int ngroup)
        {
            InitializeComponent();
            NumGroupHeadmen = ngroup;
            FIOCB.ItemsSource = App.Connection.Students.Where(s => s.NumGroup == ngroup).ToList();
            LessCB.ItemsSource = App.Connection.Lessons.ToList();
            FIOCB.DisplayMemberPath = "FIO";
            LessCB.DisplayMemberPath = "Title";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FIOCB.SelectedItem == null|| DateNote.SelectedDate == null)
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                StudLess sl = new StudLess();
                {
                    var IDstud = FIOCB.SelectedItem;
                    var Ids = ((Students)IDstud).ID_stud;
                    var IDless = LessCB.SelectedItem;
                    var Idl = ((Lessons)IDless).ID_less;
                    sl.ID_stud = Ids;
                    sl.ID_less = Idl;
                    var date = App.Connection.DateLesson.Where(x => x.DayTitle == DateNote.SelectedDate.ToString()).FirstOrDefault();
                    if(date != null)
                    {
                        sl.ID_dateless = date.ID_dateless;
                    }
                    else
                    {
                        DateLesson dl = new DateLesson();
                        {
                            dl.DayTitle = DateNote.Text;
                            App.Connection.DateLesson.Add(dl);
                            App.Connection.SaveChanges();
                            sl.ID_dateless = dl.ID_dateless;
                        }
                    }
                    sl.Checkstat = CheckStat.IsChecked;
                }
                App.Connection.StudLess.Add(sl);
                App.Connection.SaveChanges();
                MessageBox.Show("Запись добавлена");
            }
        }
    }
}
