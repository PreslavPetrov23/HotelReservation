using HotelReservation.Models;
using HotelReservation.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Shapes;

namespace HotelReservation
{
    public class InvoiceWindowViewModel : BindableBase
    {
        private Invoice invoice;
        private decimal discount;
        private decimal total;
        private InvoiceLine selectedInvoiceLine;
        private InvoiceLine currentInvoiceLine;
        private Product selectedProduct;

        public InvoiceWindowViewModel()
        {
            this.Invoice = new Invoice();
            CurrentInvoiceLine = new InvoiceLine();
            Invoice.Date = DateTime.Now;
            InvoiceLines = new ObservableCollection<InvoiceLine>();
            AddInvoiceLineCommand = new DelegateCommand(OnAddInvoiceLineCommand);
            DeleteInvoiceLineCommand = new DelegateCommand(OnDeleteInvoiceLineCommand, () => SelectedInvoiceLine != null);
            Products = HotelRepository.Instance.ProductService.Products;
            MeasureUnits = new ObservableCollection<string>();
            MeasureUnits.Add("pcs(Pieces)");
            MeasureUnits.Add("Box");
            MeasureUnits.Add("l(Liter)");
        }

        public Invoice Invoice
        {
            get { return invoice; }
            set { SetProperty(ref invoice, value); }
        }

        public InvoiceLine CurrentInvoiceLine
        {
            get { return currentInvoiceLine; }
            set { SetProperty(ref currentInvoiceLine, value); }
        }

        public decimal Discount
        {
            get { return discount; }
            set { SetProperty(ref discount, value); }
        }

        public decimal Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                SetProperty(ref selectedProduct, value);
                if (SelectedProduct != null)
                {
                    CurrentInvoiceLine.Price = SelectedProduct.Price;
                    CurrentInvoiceLine.Discount = SelectedProduct.Discount;
                    CurrentInvoiceLine.Vat = SelectedProduct.Vat;
                }
            }
        }

        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }

        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<string> MeasureUnits { get; set; }

        public DelegateCommand AddInvoiceLineCommand { get; set; }

        public DelegateCommand DeleteInvoiceLineCommand { get; set; }

        public InvoiceLine SelectedInvoiceLine
        {
            get { return selectedInvoiceLine; }
            set
            {
                SetProperty(ref selectedInvoiceLine, value);
                DeleteInvoiceLineCommand.RaiseCanExecuteChanged();
            }
        }

        private void CalculateInvoice()
        {

        }

        private void CalculateInvoiceLine (InvoiceLine line)
        {
            decimal discountSum = line.Price * line.Discount / 100;
            line.LineTotal = (line.Price - discountSum) * line.Quantity;
        }

        private void OnAddInvoiceLineCommand()
        {
            if (CurrentInvoiceLine.Quantity == 0)
            {
                MessageBox.Show("Quantity can not be 0!");
                return;
            }
            InvoiceLines.Add(CurrentInvoiceLine);
            CalculateInvoiceLine(CurrentInvoiceLine);
            CurrentInvoiceLine = new InvoiceLine();
        }

        private void OnDeleteInvoiceLineCommand()
        {
            InvoiceLines.Remove(SelectedInvoiceLine);
        }
    }
}

