using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SneakerLocalMaui.Models
{
    public class Customers
    {
            [PrimaryKey, AutoIncrement]
            public int CustomerId { get; set; }
            public string CustomersName { get; set; }
            public string CustomersSurname { get; set; }
            public string EmailAddress { get; set; }
            public string Bio { get; set; }

            [ForeignKey(typeof(ShoppingCart))]
            public int ShoppingCartId { get; set; }

        [OneToOne]
        public ShoppingCart ShoppingCart { get; set; }
    }
}
