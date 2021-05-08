//Abhishek Sawant, 8683623
using System.Windows;

namespace JoesLawnService
{
    /// <summary>
    /// Interaction logic for DataDisplay.xaml
    /// </summary>
    public partial class DataDisplay : Window
    {
        readonly VM vm;

        public DataDisplay()
        {
            InitializeComponent();
            vm = VM.Instance;
            DataContext = vm;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (columnNames.SelectedIndex == -1)
                MessageBox.Show("Please select a column from the list and then click search", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                vm.HandleSelection();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (columnNames.SelectedIndex == -1 || columnNames.SelectedIndex == 0)
                MessageBox.Show("Sort button only works on a column", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                vm.Sort();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCustomer != null)
            {
                MainWindow mw = new MainWindow() { Owner = this };
                mw.ShowDialog();
            }
            else
                MessageBox.Show("Please select a customer to edit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            vm.Delete();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow ew = new MainWindow() { Owner = this };
            ew.ShowDialog();
            Close();
        }
    }
}
