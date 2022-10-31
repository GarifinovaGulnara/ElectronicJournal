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
using ElectronicJournal.Model;

namespace ElectronicJournal.AView
{
    /// <summary>
    /// Логика взаимодействия для AllStudentsListPage.xaml
    /// </summary>
    public partial class AllStudentsListPage : Page
    {
        public static ObservableCollection<StudLess> StudLess { get; set; }
        int IndexFilre = 1;
        public AllStudentsListPage()
        {
            InitializeComponent();
            DateLV.ItemsSource = App.Connection.StudLess.ToList();
            DaysCB.ItemsSource = App.Connection.DateLesson.ToList();
            LessonsCB.ItemsSource = App.Connection.Lessons.ToList();
            DaysCB.DisplayMemberPath = "DayTitle";
            LessonsCB.DisplayMemberPath = "Title";
        }

        private void DaysCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IndexFilre != 2)
            {
                IndexFilre = 1;
            }
            else
            {
                IndexFilre = 3;
            }
            FolterSales();
        }

        private void ListHeadermen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadermenListPage());
        }

        public void FolterSales()
        {
            switch (IndexFilre)
            {
                case 1:
                    {
                        if (DaysCB.SelectedItem != null)
                        {
                            var Days = (DaysCB.SelectedItem as DateLesson);
                            StudLess = new ObservableCollection<StudLess>(App.Connection.StudLess.Where(x => x.ID_dateless == Days.ID_dateless).ToList());
                            DateLV.ItemsSource = StudLess;
                        }
                        else
                        {
                            DaysCB.Text = "";
                            DateLV.ItemsSource = StudLess;
                        }
                        break;
                    }
                case 2:
                    {
                        if (LessonsCB.SelectedItem != null)
                        {
                            var Les = (LessonsCB.SelectedItem as Lessons);
                            StudLess = new ObservableCollection<StudLess>(App.Connection.StudLess.Where(x => x.ID_less == Les.ID_less).ToList());
                            DateLV.ItemsSource = StudLess;
                        }
                        else
                        {
                            LessonsCB.Text = "";
                            DateLV.ItemsSource = StudLess;
                        }
                        break;
                    }
                default:
                    {
                        if (DaysCB.SelectedItem != null && LessonsCB.SelectedItem != null)
                        {
                            var Days = (DaysCB.SelectedItem as DateLesson);
                            var Les = (LessonsCB.SelectedItem as Lessons);
                            StudLess = new ObservableCollection<StudLess>(App.Connection.StudLess.Where(x => x.ID_less == Les.ID_less && x.ID_dateless == Days.ID_dateless).ToList());
                            DateLV.ItemsSource = StudLess;
                            IndexFilre = 1;
                        }
                        else
                        {
                            DaysCB.Text = "";
                            LessonsCB.Text = "";
                            DateLV.ItemsSource = StudLess;
                        }
                        break;
                    }
            }
        }

        private void LessonsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IndexFilre != 1)
            {
                IndexFilre = 2;
            }
            else
            {
                IndexFilre = 3;
            }
            

            FolterSales();
        }

        private void ResetFiltersBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DaysCB.SelectedItem != null && LessonsCB.SelectedItem != null)
            {
                DaysCB.Text = "";
                LessonsCB.Text = "";
                DateLV.ItemsSource = App.Connection.StudLess.ToList();
            }
            else
            {
                FolterSales();
            }
        }
    }
}
