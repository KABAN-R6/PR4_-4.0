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
    /// Логика взаимодействия для humanadd.xaml
    /// </summary>
    public partial class humanadd : Window
    {
        Entities1 db;

       
        public Humann humann { get; private set; }

        
        public humanadd(Entities1 db, object humans)
        {
            InitializeComponent();

            this.db = db;
            var a = humans as Humann;
            if (a is Humann)
            {
                humann = a;
                DataContext = humann;
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
