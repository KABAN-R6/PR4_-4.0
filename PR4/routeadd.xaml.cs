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

namespace PR4
{
    /// <summary>
    /// Логика взаимодействия для routeadd.xaml
    /// </summary>
    public partial class routeadd : Window
    {
        Entities1 db;

        public Routee routees { get; private set; }
        public Countryy countryy { get; private set; }

        public Cityy cityy { get; private set; }
        public routeadd(Entities1 db, object routee)
        {
            InitializeComponent();

            this.db = db;
            var a = routee as Routee;
            if (a is Routee)
            {
                routees = a;
                DataContext = routees;
            }
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
