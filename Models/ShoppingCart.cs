using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SneakerLocalMaui.Models
{
    public class ShoppingCart
    {
            [PrimaryKey, AutoIncrement]
            public int ShoppingCartId { get; set; }
            public int Quantity { get; set; }
            public DateTimeOffset CreatedAt { get; set; }

            [ForeignKey(typeof(Sneakers))]
            public int SneakerId { get; set; }

        [OneToOne]
        public Sneakers Sneakers { get; set; }

        [ForeignKey(typeof(Customers))]
        public int CustomerId { get; set; }

        [OneToOne]
        public Customers Customers { get; set; }
    }
}
