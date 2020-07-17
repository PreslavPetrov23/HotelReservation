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
        private int name;
        private int code;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public int Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public int Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        }
    }
}
