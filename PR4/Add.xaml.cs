using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        Entities1 db;
        public Permit Permit { get; private set; }
        public Humann Humann { get; private set; }

        public Routee Routee { get; private set;  }
        public Hotell Hotell { get; private set; }

        public Add(Entities1 db, object permit)
        {

            InitializeComponent();
            this.db = db;
            
            var a = permit as Permit;
            if (a is Permit)
            {
                Permit = a;
                DataContext = Permit;
            }
            

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
