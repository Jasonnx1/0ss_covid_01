using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingManagement.UI.ViewModels
{
	class InvoiceViewModel : BaseViewModel
	{
		private Invoice selectedInvoice;
		private ObservableCollection<Invoice> invoices;

		public InvoiceViewModel(ObservableCollection<Invoice> i)
		{
			Invoices = i;
		}

		public Invoice SelectedInvoice
		{
			get { return selectedInvoice; }
			set { 
				selectedInvoice = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Invoice> Invoices { 
			get => invoices;
			set { 
				invoices = value;
				OnPropertyChanged();
			}
		}

	}
}
