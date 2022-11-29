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
using System.Globalization;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Theory_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BindingList<Data> datalist;

            Data phone1 = new Data()
            {
                PhoneName0 = "Iphone 13",
                Factory0 = "Apple",
                Price0 = "23.000.000 VNĐ",
                Image0 = $"Image/iphone13.jpg",
            };

            Data phone2 = new Data()
            {
                PhoneName0 = "Iphone XS MAX",
                Factory0 = "Apple",
                Price0 = "12.000.000 VNĐ",
                Image0 = $"Image/iphonexsmax.jpg",
            };

            Data phone3 = new Data()
            {
                PhoneName0 = "Samsung Galaxy ZFold 4",
                Factory0 = "Samsung",
                Price0 = "43.4900.000 VNĐ",
                Image0 = $"Image/zfold4.jpg",
            };

            Data phone4 = new Data()
            {
                PhoneName0 = "Samsung Galaxy ZFlip 4",
                Factory0 = "Samsung",
                Price0 = "30.190.000 VNĐ",
                Image0 = $"Image/zflip4.jpg",
            };

            Data phone5 = new Data()
            {
                PhoneName0 = "Samsung Galaxy S22 Ultra",
                Factory0 = "Samsung",
                Price0 = "35.490.000 VNĐ",
                Image0 = $"Image/s22ultra.jpg",
            };

            Data phone6 = new Data()
            {
                PhoneName0 = "Xiaomi 11 Lite",
                Factory0 = "Xiaomi",
                Price0 = "10.990.00 VNĐ",
                Image0 = $"Image/xiaomi11lite5g.jpg",
            };

            Data phone7 = new Data()
            {
                PhoneName0 = "Xiaomi 12T",
                Factory0 = "Xiaomi",
                Price0 = "7.600.000 VNĐ",
                Image0 = $"Image/xiaomi12t.jpg",
            };

            Data phone8 = new Data()
            {
                PhoneName0 = "Vivo V25",
                Factory0 = "Vivo",
                Price0 = "13.190.000 VNĐ",
                Image0 = $"Image/vivov25.jpg",
            };

            Data phone9 = new Data()
            {
                PhoneName0 = "OPPO A9",
                Factory0 = "OPPO",
                Price0 = "6.690.000",
                Image0 = $"Image/oppoa9.jpg",
            };

            Data phone10 = new Data()
            {
                PhoneName0 = "Realme C20",
                Factory0 = "Realme",
                Price0 = "17.100.000 VNĐ",
                Image0 = $"Image/realmec20.jpg",
            };


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datalist = new BindingList<Data>();

            datalist.Add(phone1);
            datalist.Add(phone2);
            datalist.Add(phone3);
            datalist.Add(phone4);
            datalist.Add(phone5);
            datalist.Add(phone6);
            datalist.Add(phone7);
            datalist.Add(phone8);
            datalist.Add(phone9);
            datalist.Add(phone10);

            PhoneListBox.ItemsSource = datalist;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            datalist.Add(phone10);
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            var index = PhoneListBox.SelectedIndex;
            datalist.RemoveAt(index);
        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            phone1.PhoneName0 = "Iphone 13 Pro";
            phone1.Factory0 = "Apple";
            phone1.Price0 = "27.500.000 VNĐ";
            phone1.Image0 = $"Image/iphone13.jpg";
        }
    }
}
