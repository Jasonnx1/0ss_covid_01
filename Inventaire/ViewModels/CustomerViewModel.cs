using BillingManagement.Business;
using BillingManagement.Models;
using BillingManagement.UI.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Documents;

namespace BillingManagement.UI.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
       // readonly CustomersDataService customersDataService = new CustomersDataService();

        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;

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


        public CustomerViewModel(ObservableCollection<Customer> c)
        {
            Customers = c;
            DeleteCustomerCommand = new RelayCommand<Customer>(DeleteCustomer, CanDeleteCustomer);

        }


        private void DeleteCustomer(Customer c)
        {
            var currentIndex = Customers.IndexOf(c);

            if (currentIndex > 0) currentIndex--;

            SelectedCustomer = Customers[currentIndex];

            Customers.Remove(c);
        }

        private bool CanDeleteCustomer(Customer c)
        {
            if (c == null) return false;

            
            return c.Invoices.Count == 0;
        }





    }
}
