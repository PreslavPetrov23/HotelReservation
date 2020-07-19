using HotelReservation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class ProductService
    {
        public ProductService()
        {
            Products = new ObservableCollection<Product>();

            Products.Add(new Product()
            {
                Id = 1,
                Code = "0012",
                Name = "Moet",
                Discount = 3,
                Price = 80,
                Vat = 20
            }); ;

            Products.Add(new Product()
            {
                Id = 2,
                Code = "0150",
                Name = "Hennessy XO",
                Discount = 5,
                Price = 120,
                Vat = 20
            });

            Products.Add(new Product()
            {
                Id = 3,
                Code = "0421",
                Name = "Teremana Tequila",
                Discount = 3,
                Price = 60,
                Vat = 20
            });

            Products.Add(new Product()
            {
                Id = 4,
                Code = "01294",
                Name = "Johnnie Walker Blue",
                Discount = 5,
                Price = 160,
                Vat = 20
            }) ;
        }

        public ObservableCollection<Product> Products { get; set; }
    }
}
