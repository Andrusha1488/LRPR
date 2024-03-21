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

namespace LRPRpractic
{
    public partial class WindowEF : Window
    {
        private BurgerPlaceEntities3 context = new BurgerPlaceEntities3();
        public WindowEF()
        {
            InitializeComponent();
            Customer_rusDataGrid.ItemsSource = context.Customer.ToList();
            Orders_rusDataGrid.ItemsSource = context.Orders.ToList();

        }

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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.Visibility == Visibility.Visible)
            {
                Orders ord = new Orders();
                ord.Orders_Food = NameTbx1.Text;
                ord.Orders_Drink = NameTbx2.Text;
                ord.Orders_Sauce = NameTbx3.Text;
                context.Orders.Add(ord);
                context.SaveChanges();
                Orders_rusDataGrid.ItemsSource = context.Orders.ToList();
            }
            else
            {
                Customer cus = new Customer();
                cus.CustomerSurname = NameTbx1.Text;
                cus.CustomerName = NameTbx2.Text;
                context.Customer.Add(cus);
                context.SaveChanges();
                Customer_rusDataGrid.ItemsSource = context.Customer.ToList();
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.SelectedItem != null)
            {
                var selected = Orders_rusDataGrid.SelectedItem as Orders;
                selected.Orders_Food = NameTbx1.Text;
                selected.Orders_Drink = NameTbx2.Text;
                selected.Orders_Sauce = NameTbx3.Text;
                context.SaveChanges();
                Orders_rusDataGrid.ItemsSource = context.Orders.ToList();
            }
            if (Customer_rusDataGrid.SelectedItem != null)
            {
                var selected2 = Customer_rusDataGrid.SelectedItem as Customer;
                selected2.CustomerSurname = NameTbx1.Text;
                selected2.CustomerName = NameTbx2.Text;
                context.SaveChanges();
                Customer_rusDataGrid.ItemsSource = context.Customer.ToList();
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Orders_rusDataGrid.SelectedItem != null)
            {
                context.Orders.Remove(Orders_rusDataGrid.SelectedItem as Orders);
                context.SaveChanges();
                Orders_rusDataGrid.ItemsSource = context.Orders.ToList();
            }
            if (Customer_rusDataGrid.SelectedItem != null)
            {
                context.Customer.Remove(Customer_rusDataGrid.SelectedItem as Customer);
                context.SaveChanges();
                Customer_rusDataGrid.ItemsSource = context.Customer.ToList();
            }
        }
    }
}
