using HotelReservation.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace HotelReservation
{
    public class InvoiceWindowViewModel : BindableBase
    {
        private Invoice invoice;
        private decimal discount;
        private decimal total;
        private InvoiceLine selectedInvoiceLine;

        public InvoiceWindowViewModel()
        {
            this.Invoice = new Invoice();
            Invoice.Date = DateTime.Now;
            InvoiceLines = new ObservableCollection<InvoiceLine>();
            AddInvoiceLineCommand = new DelegateCommand(OnAddInvoiceLineCommand);
            DeleteInvoiceLineCommand = new DelegateCommand(OnDeleteInvoiceLineCommand, () => SelectedInvoiceLine != null);
            InvoiceLines.Add(new InvoiceLine());
        }
        
        public Invoice Invoice
        {
            get { return invoice; }
            set { SetProperty(ref invoice, value); }
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

        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }

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

        private void OnAddInvoiceLineCommand()
        {
            InvoiceLines.Add(new InvoiceLine());
        }

        private void OnDeleteInvoiceLineCommand()
        {
            InvoiceLines.Remove(SelectedInvoiceLine);
        }
    }
}

