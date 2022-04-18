using Poster.Entities;
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

namespace Poster.Views.AddNewItem
{
    /// <summary>
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder(Order order)
        {
            InitializeComponent();
            DataGridXAML.ItemsSource = Seed.getListOfItemsInOrderById(order.Id);
            ProductList.ItemsSource = Seed.getListOfItem();
            CostTextBlock.Text = Convert.ToString(order.Cost);
            DiscountTextBlock.Text = Convert.ToString(order.Discount);
        }
        
    }
}
