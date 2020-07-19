using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Models
{
    public class Product : BindableBase
    {
        private int id;
        private string name;
        private string code;
        private decimal price;
        private int vat;
        private int discount;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        }

        public decimal Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        public int Vat
        {
            get { return vat; }
            set { SetProperty(ref vat, value); }
        }

        public int Discount
        {
            get { return discount; }
            set { SetProperty(ref discount, value); }
        }

        public string DisplayName
        {
            get
            {
                return $"{Code} - {Name}";
            }
        }
    }
}
