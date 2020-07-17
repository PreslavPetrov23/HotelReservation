using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class InvoiceLine : BindableBase
    {
        private int id;
        private int invoiceId;
        private string productName;
        private string productCode;
        private decimal quantity;
        private decimal price;
        private decimal discount;
        private decimal vat;
        private decimal lineTotal;
        private int productId;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public int InvoiceId
        {
            get { return invoiceId; }
            set { SetProperty(ref invoiceId, value); }
        }

        public int ProductId // Done
        {
            get { return productId; }
            set { SetProperty(ref productId, value); }
        }

        public string ProductName // Done
        {
            get { return productName; }
            set { SetProperty(ref productName, value); }
        }
        public string ProductCode // Done
        {
            get { return productCode; }
            set { SetProperty(ref productCode, value); }
        }
        public decimal Quantity // Done
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
        public decimal Price // Done
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        public decimal Discount // Done
        {
            get { return discount; }
            set { SetProperty(ref discount, value); }
        }
        public decimal Vat // Done
        {
            get { return vat; }
            set { SetProperty(ref vat, value); }
        }
        public decimal LineTotal // Done
        {
            get { return lineTotal; }
            set { SetProperty(ref lineTotal, value); }
        }

        public void Copy(InvoiceLine copy)
        {
            Id = copy.Id;
            InvoiceId = copy.InvoiceId;
            ProductId = copy.ProductId;
            ProductName = copy.ProductName;
            ProductCode = copy.ProductCode;
            Quantity = copy.Quantity;
            Price = copy.Price;
            Discount = copy.Discount;
            Vat = copy.Vat;
            LineTotal = copy.LineTotal;
        }
    }
}
