using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class InvoiceService
    {
        public InvoiceService()
        {
            Invoices = new ObservableCollection<Invoice>();
            InvoiceLines = new ObservableCollection<InvoiceLine>();
        }

        public ObservableCollection<Invoice> Invoices { get; set; }

        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
