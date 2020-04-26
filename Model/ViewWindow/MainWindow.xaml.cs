using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace ViewWindow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RestaurantManager restaurantManager;
        private ReportReceiver reportReceiver;
        private ReportSender reportSender;
        private int completeOrderIndex = 0;
        private List<string> dishesNames;

        public MainWindow()
        {
            dishesNames = new List<string>();
            InitializeComponent();

            restaurantManager = new RestaurantManager();
            reportSender = new ReportSender(restaurantManager, 5000);
            Task.Run(() => reportSender.SendReport());

            reportReceiver = new ReportReceiver(reportStartDateTextBox, reportEndDateTextBox, reportIncomeTextBox);
            reportReceiver.Subscribe(reportSender);

            restaurantManager.AddSampleData();


        }

        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantManager.CreateOrder("test", DateTime.Now, false, dishesNames, "", "", "", DateTime.Now);
            dishesNames.Clear();
            addedDishesListBox.Items.Clear();
        }

        private void addClientButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantManager.CreateClient("test", "0090909", "Street", "24", "12-123");
            
        }

        private void completeLastOrderButton_Click(object sender, RoutedEventArgs e)
        {
            restaurantManager.CompleteOrder(completeOrderIndex);
            completeOrderIndex++;
        }


        private void dishesComboBox_DropDownOpened(object sender, EventArgs e)
        {
            dishesComboBox.Items.Clear();
            List<Dish> menu = restaurantManager.GetMenu();
            foreach (Dish dish in menu)
            {
                dishesComboBox.Items.Add(dish.Name);
            }
            
        }

        private void addAddDishToList_Click(object sender, RoutedEventArgs e)
        {
            dishesNames.Add((string)dishesComboBox.SelectedItem);
            addedDishesListBox.Items.Add((string)dishesComboBox.SelectedItem);
        }
    }
}
