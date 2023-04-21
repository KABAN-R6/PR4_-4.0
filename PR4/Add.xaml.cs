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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        Entities _db;
        public Client Client { get; private set; }
        public Coach Coach { get; private set; }
        public Add(Entities db, object client)
        {

            InitializeComponent();
            this._db = _db;
            
            var a = client as Permit;
            if (a is Permit)
            {
                Client = a;
                
                DataContext = Client;


            }
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
