//Abhishek Sawant, 8683623
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JoesLawnService
{
    class Customer : INotifyPropertyChanged
    {
        public bool IsNew { get; set; } = true;
        public string Name { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public decimal Lawn { get; set; } = 0;
        public string Date { get; set; } = string.Empty;

        public BindingList<string> Types { get; set; } = new BindingList<string>() { "Full -$9.99/m2", "Maintenance - $0.59/m2", "Weed spraying -$7.99/m2" };
        private string selectedType;
        public string SelectedType
        {
            get { return selectedType; }
            set { selectedType = value; propertyChanged(); }
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
