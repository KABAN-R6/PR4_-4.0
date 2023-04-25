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
    /// Логика взаимодействия для oteladd.xaml
    /// </summary>
    public partial class oteladd : Window
    {
        Entities1 db;

        public Hotell hotell { get; private set; }
        public Servicce servicce { get; private set; }

      
        public oteladd(Entities1 db, object hotel)
        {
            InitializeComponent();

            this.db = db;
            var a = hotel as Hotell;
            if (a is Hotell)
            {
                hotell = a;
                DataContext = hotell;
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
