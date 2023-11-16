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

namespace QuanLyBanCaffe.GUI
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            Main.Content = new frmBanner();
        }
        private void Banner_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmBanner();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmProduct();
        }

        private void Selling_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmProduct();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmProduct();
        }

        private void Catagory_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmCatagory();
        }

        private void Bill_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmProduct();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new frmProduct();
        }
    }
}
