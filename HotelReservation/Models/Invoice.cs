using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace HotelReservation.Models
{
    public class Invoice : BindableBase
    {
        private int id;
        private DateTime date;
        private string customerName;
        private string documentNumber;
        private string customerAddress;
        private int customerId;
        private string paymentMethod;
        private decimal vatAmount;
        private decimal subTotal;
        private string note;
        private string currency;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public string DocumentNumber
        {
            get { return documentNumber; }
            set { SetProperty(ref documentNumber, value); }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { SetProperty(ref customerName, value); }
        }

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { SetProperty(ref customerAddress, value); }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { SetProperty(ref customerId, value); }
        }

        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { SetProperty(ref paymentMethod, value); }
        }

        public decimal VatAmount
        {
            get { return vatAmount; }
            set { SetProperty(ref vatAmount, value); }
        }

        public decimal SubTotal
        {
            get { return subTotal; }
            set { SetProperty(ref subTotal, value); }
        }

        public string Note
        {
            get { return note; }
            set { SetProperty(ref note, value); }
        }

        public string Currency
        {
            get { return currency; }
            set { SetProperty(ref currency, value); }
        }

        public void Copy(Invoice copy)
        {
            Id = copy.Id;
            Date = copy.Date;
            DocumentNumber = copy.DocumentNumber;
            CustomerName = copy.CustomerName;
            CustomerAddress = copy.CustomerAddress;
            CustomerId = copy.CustomerId;
            PaymentMethod = copy.PaymentMethod;
            VatAmount = copy.VatAmount;
            SubTotal = copy.SubTotal;
            Note = copy.Note;
            Currency = copy.Currency;
        }
    }
}
