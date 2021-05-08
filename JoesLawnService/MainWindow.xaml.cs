//Abhishek Sawant, 8683623
using System.Text.RegularExpressions;
using System.Windows;

namespace JoesLawnService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Regex nameRegex = new Regex("^[A-Za-z -']+$");
        readonly Regex postalCodeRegex = new Regex("^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$");
        readonly Regex phoneRegex = new Regex("^[0-9]{10}$");

        readonly VM vm;
        readonly Customer customer = new Customer();

        public MainWindow()
        {
            InitializeComponent();
            vm = VM.Instance;
            if (vm.SelectedCustomer != null)
            {
                customer.IsNew = false;

                customer.Name = vm.SelectedCustomer.Name;
                customer.PostalCode = vm.SelectedCustomer.PostalCode;
                customer.Phone = vm.SelectedCustomer.Phone;
                customer.Lawn = vm.SelectedCustomer.Lawn;
                customer.SelectedType = vm.SelectedCustomer.SelectedType;
                customer.Date = vm.SelectedCustomer.Date;

                Add.Content = "Save";
                Clear.Content = "Cancel";
                Show.Visibility = Visibility.Collapsed;
            }
            DataContext = customer;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool nameResult = nameRegex.IsMatch(customer.Name);
            bool postalResult = postalCodeRegex.IsMatch(customer.PostalCode);
            bool phoneResult = phoneRegex.IsMatch(customer.Phone);

            if (nameResult == false || postalResult == false || phoneResult == false || custLawn.Value == 0 || custType.SelectedIndex == -1 || custDate.SelectedDate == null)
                MessageBox.Show("Enter valid input in all fields to proceed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (vm.SelectedCustomer != null)
            {
                vm.Save(customer);
                Close();
            }
            else
            {
                vm.Save(customer);
                ClearEverything();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedCustomer != null)
                Close();
            else
                ClearEverything();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            DataDisplay dw = new DataDisplay() { Owner = this };
            dw.ShowDialog();
            Close();
        }

        private void ClearEverything()
        {
            custName.Clear();
            custPhone.Clear();
            custPostalCode.Clear();
            custLawn.Value = 0;
            custType.SelectedIndex = -1;
            custDate.SelectedDate = null;
        }
    }
}
