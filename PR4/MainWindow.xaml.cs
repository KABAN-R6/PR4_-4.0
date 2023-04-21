﻿using System;
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
                 cli = win.Client;
                _db.Permit.Add(permits);
                try
                {
                    _db.SaveChanges();
                }
                catch { }
                Update();

            }
            //DataContext = db.Client.ToList();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Client client = usersList.SelectedItem as Client;
            if (client == null) return;
            try
            {
                db.Client.Remove(client);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            DataContext = db.Client.ToList();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Client client = usersList.SelectedItem as Client;
            if (client == null) return;
            DataEntry entry = new DataEntry(db, new Client
            {
                id = client.id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MidleName = client.MidleName,
                Gender1 = client.Gender1,
                Number = client.Number,
            });
            if (entry.ShowDialog() == true)
            {
                client = db.Client.Find(entry.Client.id);
                if (client != null)
                {
                    client.FirstName = entry.Client.FirstName;
                    client.LastName = entry.Client.LastName;
                    client.MidleName = entry.Client.MidleName;
                    client.Gender1 = entry.Client.Gender1;
                    client.Number = entry.Client.Number;
                    db.SaveChanges();
                    usersList.Items.Refresh();
                }

            }
            DataContext = db.Client.ToList();

        }

        private void Update()
        {
            Clients = new ObservableCollection<Client>(db.Client);
            usersList.ItemsSource = Clients;
        }

        private void OpenCoach(object sender, RoutedEventArgs e)
        {
            Clientxaml clientxaml = new Clientxaml(db);
            clientxaml.Show();
        }

        private void OpenSeasonTicket(object sender, RoutedEventArgs e)
        {
            SeasonTicketData ticket = new SeasonTicketData(db);
            ticket.Show();
        }

        private void OpenTrainingPlan(object sender, RoutedEventArgs e)
        {
            PlanTraining planTraining = new PlanTraining(db);
            planTraining.Show();
        }

        private void OpenWorkout(object sender, RoutedEventArgs e)
        {
            Workout workout = new Workout(db);
            workout.Show();
        }

    }

    private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
