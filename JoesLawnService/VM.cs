//Abhishek Sawant, 8683623
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace JoesLawnService
{
    class VM : INotifyPropertyChanged
    {
        readonly DB db = DB.Instance;
        List<Customer> customers;

        bool ascend = true;

        #region singleton
        private static VM vm;
        public static VM Instance { get { vm ??= new VM(); return vm; } }

        private VM()
        {
            customers = db.Get();
            UpdateCustomers();
        }
        #endregion

        #region Properties
        public BindingList<string> Columns { get; set; } = new BindingList<string>() { "All", "Name", "Postal Code", "Phone", "Lawn Size", "Type", "Date" };

        private string selectedColumn;
        public string SelectedColumn
        {
            get { return selectedColumn; }
            set { selectedColumn = value; propertyChanged(); }
        }

        public BindingList<Customer> Customers { get; set; } = new BindingList<Customer>();

        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; propertyChanged(); }
        }
        #endregion

        #region methods
        public void Save(Customer customer)
        {
            if (customer.IsNew)
            {
                db.Insert(customer);
            }
            else
            {
                db.Update(customer);
                customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
            customers.Add(customer);
            UpdateCustomers();
        }

        public void Delete()
        {
            db.Delete(SelectedCustomer);
            Customers.Remove(SelectedCustomer);
            customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

        public void SortHighToLow()
        {
            if (SelectedColumn == "Name")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.Name).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Postal Code")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.PostalCode).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Phone")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.Phone).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Lawn Size")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.Lawn).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Type")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.SelectedType).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Date")
            {
                Customers.Clear();
                customers = customers.OrderByDescending(c => c.Date).ToList();
                UpdateCustomers();
            }
        }

        public void SortLowToHigh()
        {
            if (SelectedColumn == "Name")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.Name).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Postal Code")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.PostalCode).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Phone")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.Phone).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Lawn Size")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.Lawn).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Type")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.SelectedType).ToList();
                UpdateCustomers();
            }
            if (SelectedColumn == "Date")
            {
                Customers.Clear();
                customers = customers.OrderBy(c => c.Date).ToList();
                UpdateCustomers();
            }
        }

        public void Sort()
        {
            if (ascend)
            {
                SortLowToHigh();
                ascend = false;
            }
            else
            {
                SortHighToLow();
                ascend = true;
            }
        }

        public void HandleSelection()
        {
            if (SelectedColumn == "All")
            {
                Customers.Clear();
                customers = db.Get();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Name")
            {
                Customers.Clear();
                customers = db.GetName();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Postal Code")
            {
                Customers.Clear();
                customers = db.GetPostal();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Phone")
            {
                Customers.Clear();
                customers = db.GetPhone();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Lawn Size")
            {
                Customers.Clear();
                customers = db.GetLawn();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Type")
            {
                Customers.Clear();
                customers = db.GetType();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
            if (SelectedColumn == "Date")
            {
                Customers.Clear();
                customers = db.GetDate();
                foreach (Customer c in customers)
                    Customers.Add(c);
            }
        }

        private void UpdateCustomers()
        {
            Customers.Clear();
            foreach (Customer c in customers)
                Customers.Add(c);
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
