using HotelReservation.Models;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace HotelReservation
{
    public class InvoiceWindowViewModel : BindableBase
    {
        private Invoice invoice;
        private decimal discount;
        private decimal total;

        public InvoiceWindowViewModel()
        {
            this.Invoice = new Invoice();
            InvoiceLines = new ObservableCollection<InvoiceLine>();
        }

        public Invoice Invoice
        {
            get { return invoice; }
            set { SetProperty(ref invoice, value); }
        }

        public decimal Discount {
            get { return discount; }
            set { SetProperty(ref discount, value); }
        }

        public decimal Total {
            get { return total; }
            set { SetProperty(ref total, value); }
        }

        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }
    }
}

