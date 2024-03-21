using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LRPRpractic.BurgerPlaceDataSet2TableAdapters;

namespace LRPRpractic
{
    public partial class MainWindow : Window
    {

        CustomerTableAdapter customer = new CustomerTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter();
        Customer_rusTableAdapter customer_rus = new Customer_rusTableAdapter();
        Orders_rusTableAdapter orders_rus = new Orders_rusTableAdapter();
        private void PreviousTable_Click(object sender, RoutedEventArgs e)
        {
            Customer_rusDataGrid.Visibility = Visibility.Visible;
            Orders_rusDataGrid.Visibility = Visibility.Collapsed;
            NameTbx3.Visibility = Visibility.Collapsed;
            NameTbx1.Text = "Введите данные имени";
            NameTbx2.Text = "Введите данные фамилии";
        }

        private void NextTable_Click(object sender, RoutedEventArgs e)
        {
            Customer_rusDataGrid.Visibility = Visibility.Collapsed;
            Orders_rusDataGrid.Visibility = Visibility.Visible;
            NameTbx3.Visibility = Visibility.Visible;
            NameTbx1.Text = "Введите данные еды";
            NameTbx2.Text = "Введите данные напитка";
        }
        public MainWindow()
        {
            InitializeComponent();
            Customer_rusDataGrid.ItemsSource = customer.GetData();
            Orders_rusDataGrid.ItemsSource = orders.GetData();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.Visibility == Visibility.Visible)
            {
                orders.InsertQuery1(NameTbx1.Text, NameTbx2.Text, NameTbx3.Text);
                Orders_rusDataGrid.ItemsSource = orders.GetData();
            }
            else if (Orders_rusDataGrid.Visibility == Visibility.Collapsed)
            {
                customer.InsertQuery2(NameTbx1.Text, NameTbx2.Text);
                Customer_rusDataGrid.ItemsSource = customer.GetData();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.Visibility == Visibility.Visible)
            {
                object Id1 = (Orders_rusDataGrid.SelectedItem as DataRowView).Row[0];
                orders.UpdateQuery3(NameTbx1.Text, NameTbx2.Text, NameTbx3.Text, Convert.ToInt32(Id1));
                Orders_rusDataGrid.ItemsSource = orders.GetData();
            }
            else if (Orders_rusDataGrid.Visibility == Visibility.Collapsed)
            {
                object Id2 = (Customer_rusDataGrid.SelectedItem as DataRowView).Row[0];
                customer.UpdateQuery4(NameTbx1.Text, NameTbx2.Text, Convert.ToInt32(Id2));
                Customer_rusDataGrid.ItemsSource = customer.GetData();
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.Visibility == Visibility.Visible)
            {
                object Id1 = (Orders_rusDataGrid.SelectedItem as DataRowView).Row[0];
                orders.DeleteQuery5(Convert.ToInt32(Id1));
                Orders_rusDataGrid.ItemsSource = orders.GetData();
            }
            else if (Orders_rusDataGrid.Visibility == Visibility.Collapsed)
            {
                object Id2 = (Customer_rusDataGrid.SelectedItem as DataRowView).Row[0];
                customer.DeleteQuery6(Convert.ToInt32(Id2));
                Customer_rusDataGrid.ItemsSource = customer.GetData();
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            WindowEF window = new WindowEF();
            window.Show();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Close();
        }

    }
}
