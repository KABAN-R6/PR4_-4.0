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
    /// Логика взаимодействия для serviceadd.xaml
    /// </summary>
    public partial class serviceadd : Window
    {
        Entities1 db;

        public Servicce servicce { get; private set; }
        public serviceadd(Entities1 db, object service)
        {
            InitializeComponent();
            this.db = db;
            var a = service as Servicce;
            if (a is Servicce)
            {
                servicce = a;
                DataContext = servicce;
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
