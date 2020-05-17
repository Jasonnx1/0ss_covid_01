using BillingManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace BillingManagement.UI.ViewModels
{
	class InvoiceViewModel : BaseViewModel
	{
		private Invoice selectedInvoice;
		private ObservableCollection<Invoice> invoices;
		BillingContext db { get; set; }
		public InvoiceViewModel(BillingContext _db)
		{
			Invoices = new ObservableCollection<Invoice>();
			db = _db;
			load();
		}

		public void load()
		{
			Invoices.Clear();
			Invoices = new ObservableCollection<Invoice>(db.Invoices);
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
