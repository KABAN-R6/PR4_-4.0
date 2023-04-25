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
        Entities1 db;
        public ObservableCollection<Permit> permits { get; set; }
        public ObservableCollection<Cityy> cityys { get; set; }
        public ObservableCollection<Countryy> countryys { get; set; }
        public ObservableCollection<Routee> routees { get; set; }
        public ObservableCollection<Servicce> Servicces { get; set; }
        public ObservableCollection<Hotell> Hotells { get; set; }
        public ObservableCollection<Humann> humanns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            db = new Entities1();
            permits = new ObservableCollection<Permit>(db.Permit);
            List.ItemsSource = permits;
            cityys = new ObservableCollection<Cityy>(db.Cityy);
            List2.ItemsSource = cityys;

            humanns = new ObservableCollection<Humann>(db.Humann);
            List4.ItemsSource = humanns;

            Servicces = new ObservableCollection<Servicce>(db.Servicce);
            List7.ItemsSource = Servicces;

            Hotells = new ObservableCollection<Hotell>(db.Hotell);
            List6.ItemsSource = Hotells;

            routees = new ObservableCollection<Routee>(db.Routee);
            List5.ItemsSource = routees;

            countryys = new ObservableCollection<Countryy>(db.Countryy);
            List3.ItemsSource = countryys;

            

        }
        

        

       

        private void Update()
        {
            permits = new ObservableCollection<Permit>(db.Permit);
            List.ItemsSource = permits;
            cityys = new ObservableCollection<Cityy>(db.Cityy);
            List2.ItemsSource = cityys;
            countryys = new ObservableCollection<Countryy>(db.Countryy);
            List3.ItemsSource = countryys;
            Servicces = new ObservableCollection<Servicce>(db.Servicce);
            List7.ItemsSource = Servicces;
            routees = new ObservableCollection<Routee>(db.Routee);
            List5.ItemsSource = routees;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add win = new Add(db, new Permit());
            if (win.ShowDialog() == true)
            {
                Permit permit = win.Permit;
                db.Permit.Add(permit);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            Add entry = new Add(db, new Permit
            {
                Id = permits.Id,
                Route = permits.Route,
                Hotell = permits.Hotell,
                Humann = permits.Humann,

            });
            if (entry.ShowDialog() == true)
            {
                permits = db.Permit.Find(entry.Permit.Id);
                if (permits != null)
                {
                    permits.Id = permits.Id;
                    permits.Route = permits.Route;
                    permits.Hotell = permits.Hotell;
                    permits.Humann = permits.Humann;
                    db.SaveChanges();
                    List.Items.Refresh();
                }

            }
           

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Permit permits = List.SelectedItem as Permit;
            if (permits == null) return;
            try
            {
                db.Permit.Remove(permits);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }

       

        private void List2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            countryadd win = new countryadd(db, new Countryy());
            if (win.ShowDialog() == true)
            {
                Countryy countryy = win.countryy;
                db.Countryy.Add(countryy);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Countryy countryy = List3.SelectedItem as Countryy;
            if (countryy == null) return;
            try
            {
                db.Countryy.Remove(countryy);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            cityadd win = new cityadd(db, new Cityy());
            if (win.ShowDialog() == true)
            {
                Cityy cityy = win.cityy;
                db.Cityy.Add(cityy);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Cityy cityy = List2.SelectedItem as Cityy;
            if (cityy == null) return;
            cityadd entry = new cityadd(db, new Cityy
            {
                Id = cityy.Id,
                Name = cityy.Name,


            });
            if (entry.ShowDialog() == true)
            {
                cityy = db.Cityy.Find(entry.cityy.Id);
                if (cityy != null)
                {
                    cityy.Id = entry.cityy.Id;
                    cityy.Name = entry.cityy.Name;

                    db.SaveChanges();
                    List.Items.Refresh();
                    Update();
                }

            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            routeadd win = new routeadd(db, new Routee());
            if (win.ShowDialog() == true)
            {
                Routee routee = win.routees;
                db.Routee.Add(routee);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Routee routees = List5.SelectedItem as Routee;
            if (routees == null) return;
            routeadd entry = new routeadd(db, new Routee
            {
                Id = routees.Id,
                Name = routees.Name,
                Countryy = routees.Countryy,
                Cityy = routees.Cityy,
            });
            if (entry.ShowDialog() == true)
            {
                routees = db.Routee.Find(entry.routees.Id);
                if (routees != null)
                {
                    routees.Id = entry.routees.Id;
                    routees.Name = entry.routees.Name;
                    routees.Countryy = entry.routees.Countryy;
                    routees.Cityy = entry.routees.Cityy;

                    db.SaveChanges();
                    List.Items.Refresh();
                    Update();
                }

            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Routee routee = List5.SelectedItem as Routee;
            if (routee == null) return;
            try
            {
                db.Routee.Remove(routee);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Cityy cityy = List2.SelectedItem as Cityy;
            if (cityy == null) return;
            try
            {
                db.Cityy.Remove(cityy);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Countryy countryy = List3.SelectedItem as Countryy;
            if (countryy == null) return;
            countryadd entry = new countryadd(db, new Countryy
            {
                Id = countryy.Id,
                Name = countryy.Name,
                

            });
            if (entry.ShowDialog() == true)
            {
                countryy = db.Countryy.Find(entry.countryy.Id);
                if (countryy != null)
                {
                    countryy.Id = entry.countryy.Id;
                    countryy.Name = entry.countryy.Name;
                    
                    db.SaveChanges();
                    List.Items.Refresh();
                    Update();
                }

            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Countryy countryy = List3.SelectedItem as Countryy;
            if (countryy == null) return;
            countryadd entry = new countryadd(db, new Countryy
            {
                Id = countryy.Id,
                Name = countryy.Name,


            });
            if (entry.ShowDialog() == true)
            {
                countryy = db.Countryy.Find(entry.countryy.Id);
                if (countryy != null)
                {
                    countryy.Id = entry.countryy.Id;
                    countryy.Name = entry.countryy.Name;

                    db.SaveChanges();
                    List.Items.Refresh();
                    Update();
                }

            }
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_43454(object sender, RoutedEventArgs e)
        {
            serviceadd win = new serviceadd(db, new Servicce());
            if (win.ShowDialog() == true)
            {
                Servicce servicce = win.servicce;
                db.Servicce.Add(servicce);
                try
                {
                    db.SaveChanges();
                }
                catch { }
                Update();

            }
        }

        private void Button_Click_445(object sender, RoutedEventArgs e)
        {
          
            Servicce servicce = List7.SelectedItem as Servicce;
            if (servicce == null) return;
            try
            {
                db.Servicce.Remove(servicce);
                db.SaveChanges();
                Update();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click_445345(object sender, RoutedEventArgs e)
        {
            Servicce servicce = List7.SelectedItem as Servicce;
            if (servicce == null) return;
            serviceadd entry = new serviceadd(db, new Servicce
            {
                Id = servicce.Id,
                Name = servicce.Name,


            });
            if (entry.ShowDialog() == true)
            {
                servicce = db.Servicce.Find(entry.servicce.Id);
                if (servicce != null)
                {
                    servicce.Id = entry.servicce.Id;
                    servicce.Name = entry.servicce.Name;

                    db.SaveChanges();
                    List.Items.Refresh();
                    Update();
                }

            }
        }
    }
}

  

