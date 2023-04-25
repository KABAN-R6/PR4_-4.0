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
    /// Логика взаимодействия для cityadd.xaml
    /// </summary>
    public partial class cityadd : Window
    {
        Entities1 db;

        public Cityy cityy { get; private set; }
        public cityadd(Entities1 db, object city)
        {
            InitializeComponent();
            this.db = db;
            var a = city as Cityy;
            if (a is Cityy)
            {
                cityy = a;
                DataContext = cityy;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
