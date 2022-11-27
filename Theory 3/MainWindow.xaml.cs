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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Theory_3
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Data? data = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label0.Content = "Theory excercise 3";
            var data = new Data
            {
                PhoneName0 = "Samsung Galaxy ZFold 4",
                Factory0 = "Samsung",
                Price0 = "42.490.000 VNĐ",
                Image0 = $"Image/zfold4.jpg",
            };

            PhoneName.Content = data.PhoneName0;
            Factory.Content = data.Factory0;
            Price.Content = data.Price0;

            DataContext = data;
        }
    }
}
