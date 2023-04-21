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

namespace PR4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities _db;
        public ObservableCollection<Permit> permits { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _db = new Entities();
            permits = new ObservableCollection<Permit>(_db.Permit);
            List.ItemsSource = permits;
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            Add win = new Add(_db, new Permit());
            if (win.ShowDialog() == true)
            {
                Permit permits = win.permit;
                _db.Permit.Add(permits);
                try
                {
                    _db.SaveChanges();
                }
                catch { }
                Update();

            }
            //DataContext = _db.Permit.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            try
            {
                _db.Permit.Remove(permits);
                _db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            //DataContext = _db.Permit.ToList();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            Add entry = new Add(_db, new Permit
            {
                Id = permits.Id,
                Route = permits.Route,
                Hotell = permits.Hotell,
                Humann = permits.Humann,

            });
            if (entry.ShowDialog() == true)
            {
                permits = _db.Permit.Find(entry.permit.Id);
                if (permits != null)
                {
                    permits.Id = permits.Id;
                    permits.Route = permits.Route;
                    permits.Hotell = permits.Hotell;
                    permits.Humann = permits.Humann;
                    _db.SaveChanges();
                    List.Items.Refresh();
                }

            }
            //DataContext = db.Client.ToList();

        }

        private void Update()
        {
            permits = new ObservableCollection<Permit>(_db.Permit);
            List.ItemsSource = permits;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void OpenCoach(object sender, RoutedEventArgs e)
        //{
        //    Clientxaml clientxaml = new Clientxaml(db);
        //    clientxaml.Show();
        //}

        //private void OpenSeasonTicket(object sender, RoutedEventArgs e)
        //{
        //    SeasonTicketData ticket = new SeasonTicketData(db);
        //    ticket.Show();
        //}

        //private void OpenTrainingPlan(object sender, RoutedEventArgs e)
        //{
        //    PlanTraining planTraining = new PlanTraining(db);
        //    planTraining.Show();
        //}

        //private void OpenWorkout(object sender, RoutedEventArgs e)
        //{
        //    Workout workout = new Workout(db);
        //    workout.Show();
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}

  

