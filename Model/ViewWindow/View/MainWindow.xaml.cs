using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace ViewWindow
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   


        public MainWindow()
        {
           
            InitializeComponent();
            DataContext = new ViewControler();
           
        }

        private void OpenDishWindow_Click(object sender, RoutedEventArgs e)
        {
            DishWindow window = new DishWindow();
            window.DataContext = (this.DataContext as ViewControler).dishViewModel;
            window.ShowDialog();
            (DataContext as ViewControler).RefreshView();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow window = new ClientWindow();
            window.DataContext = (this.DataContext as ViewControler).clientViewModel;
            window.ShowDialog();
            (DataContext as ViewControler).RefreshView();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as ViewControler).RefreshOrderDishes();
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as ViewControler).RefreshDeliveryDishes();
        }








        //private void addOrderButton_Click(object sender, RoutedEventArgs e)
        //{
        //    restaurantManager.CreateOrder("test", DateTime.Now, false, dishesNames, "", "", "", DateTime.Now);
        //    dishesNames.Clear();
        //    addedDishesListView.Items.Clear();
        //}

        //private void addClientButton_Click(object sender, RoutedEventArgs e)
        //{
        //    restaurantManager.CreateClient("test", "0090909", "Street", "24", "12-123");


        //}

        //private void completeLastOrderButton_Click(object sender, RoutedEventArgs e)
        //{
        //    restaurantManager.CompleteOrder(completeOrderIndex);
        //    completeOrderIndex++;
        //}


        //private void dishesComboBox_DropDownOpened(object sender, EventArgs e)
        //{
        //    dishesComboBox.Items.Clear();
        //    List<Dish> menu = restaurantManager.GetMenu();
        //    foreach (Dish dish in menu)
        //    {
        //        dishesComboBox.Items.Add(dish.Id);
        //    }

        //}

        //private void addAddDishToList_Click(object sender, RoutedEventArgs e)
        //{
        //    dishesNames.Add((menuListView.SelectedItem as Dish).Name);
        //    addedDishesListView.Items.Add((menuListView.SelectedItem as Dish));
        //}


    }
}
