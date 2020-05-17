using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

        public BillingContext db { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Customer> DeleteCustomerCommand { get; private set; }
        public RelayCommand<object> SaveCommand { get; set; }

        // CTOR
        public CustomerViewModel(BillingContext _db)
        {
            DeleteCustomerCommand = new RelayCommand<Customer>(DeleteCustomer, CanDeleteCustomer);
            SaveCommand = new RelayCommand<object>(Save);
            Customers = new ObservableCollection<Customer>();

            db = _db;
            load();
        }

        public void load()
        {
            Customers.Clear();
            Customers = new ObservableCollection<Customer>(db.Customers.OrderBy(c => c.LastName));
        }

        public void Save(object c)
        {
            db.SaveChanges();
        }

        private void DeleteCustomer(Customer c)
        {
            var currentIndex = Customers.IndexOf(c);

            if (currentIndex > 0) currentIndex--;

            db.Remove(c);
            db.SaveChanges();
            Customers.Clear();
            Customers = new ObservableCollection<Customer>(db.Customers.OrderBy(c => c.LastName));

            SelectedCustomer = Customers[currentIndex];
        }

        private bool CanDeleteCustomer(Customer c)
        {
            if (c == null) return false;


            return c.Invoices.Count == 0;
        }

    }
}
