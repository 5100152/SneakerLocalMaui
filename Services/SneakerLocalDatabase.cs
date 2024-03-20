using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using SneakerLocalMaui.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using SQLitePCL;

namespace SneakerLocalMaui.Services
{
    public class SneakerLocalDatabase
    {
        private SQLiteConnection _dbConnection;
        public List<Sneakers> SelectedSneakers { get; set; }
        public SneakerLocalDatabase(string dbPath)
        {
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<Sneakers>();
        }

        public List<Sneakers> GetAllSneakers()
        {
            return _dbConnection.Table<Sneakers>().ToList();
        }

        public string GetDatabasePath()
        {
            string filename = "sneakerdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        public SneakerLocalDatabase()
        {
            _dbConnection = new SQLiteConnection(GetDatabasePath());

            _dbConnection.CreateTable<Sneakers>();
            _dbConnection.CreateTable<ShoppingCart>();
            _dbConnection.CreateTable<Customers>();
            SelectedSneakers = new List<Sneakers>();

            SeedDatabase();
        }

        public void SeedDatabase()
        {
            if (_dbConnection.Table<Sneakers>().Count() == 0)
            {
                List<Sneakers> sneakers = new List<Sneakers>
                {
                                      new Sneakers()
                    {
                        Name = "Air Jordan 1",
                        Brand = "Nike",
                        Price = 160.00m,
                        Quantity = 10,
                        SneakerPic = "AJ1.jpeg",
                        Description = "The Air Jordan 1 is a legendary basketball shoe that revolutionized the sneaker industry. With its iconic high-top silhouette and timeless design, it's a symbol of style and performance. Featuring premium leather construction and Nike Air cushioning, it offers comfort and support both on and off the court."
                    },

                    new Sneakers()
                    {
                        Name = "Yeezy Boost 350",
                        Brand = "Adidas",
                        Price = 220.00m,
                        SneakerPic = "YB350.jpeg",
                        Quantity = 5,
                        Description = "The Yeezy Boost 350 is a highly coveted sneaker designed by Kanye West in collaboration with Adidas. Known for its sleek and minimalist design, it features a Primeknit upper and Boost cushioning for unparalleled comfort and style. With its limited availability and unique colorways, it's a must-have for sneaker enthusiasts worldwide."
                    },

                    new Sneakers()
                    {
                        Name = "Nike Air Force 1",
                        Brand = "Nike",
                        Price = 90.00m,
                        Quantity = 8,
                        SneakerPic = "AF1.jpeg",
                        Description = "The Nike Air Force 1 is a classic sneaker that has stood the test of time. Originally released in 1982, it's known for its simple yet versatile design and durable construction. With its iconic Air cushioning and premium leather upper, it offers superior comfort and style for everyday wear."
                    },

                    new Sneakers()
                    {
                        Name = "Converse Chuck Taylor All Star",
                        Brand = "Converse",
                        Price = 55.00m,
                        SneakerPic = "CCT.jpeg",
                        Quantity = 12,
                        Description = "The Converse Chuck Taylor All Star is an iconic sneaker that has been a staple of street style for decades. With its timeless silhouette and canvas upper, it's a symbol of rebellion and self-expression. Whether worn on the basketball court or in everyday life, it's a versatile choice for sneaker enthusiasts."
                    },

                    new Sneakers()
                    {
                        Name = "Vans Old Skool",
                        Brand = "Vans",
                        Price = 60.00m,
                        Quantity = 6,
                        SneakerPic = "AF1.jpeg",
                        Description = "The Vans Old Skool is a classic skate shoe that has transcended its roots to become a fashion staple. With its signature side stripe and durable canvas upper, it offers timeless style and durability. Whether worn on the skateboard or on the streets, it's a versatile choice for casual wear."
                    },


                     new Sneakers()
                    {
                        Name = "Nike Air Max 97",
                        Brand = "Nike",
                        Price = 170.00m,
                        Quantity = 7,
                        SneakerPic = "NAM.jpeg",
                        Description = "The Nike Air Max 97 reimagines an iconic running shoe with a sleek design and modern details. Featuring a full-length Max Air unit for comfortable cushioning and a futuristic aesthetic."
                    },
                    new Sneakers()
                    {
                        Name = "Adidas Ultraboost",
                        Brand = "Adidas",
                        Price = 180.00m,
                        Quantity = 9,
                        SneakerPic = "AU.jpeg",
                        Description = "The Adidas Ultraboost combines responsive cushioning with a lightweight and supportive design. Its flexible outsole and knit upper provide a comfortable and adaptive fit for everyday wear."
                    },
                    new Sneakers()
                    {
                        Name = "New Balance 990v5",
                        Brand = "New Balance",
                        Price = 175.00m,
                        Quantity = 6,
                        SneakerPic = "NB990.jpeg",
                        Description = "The New Balance 990v5 is a classic silhouette updated with modern comfort and style. Its premium suede and mesh upper offers durability and breathability, while the ENCAP midsole provides responsive cushioning and support."
                    },
                    new Sneakers()
                    {
                        Name = "Reebok Classic Leather",
                        Brand = "Reebok",
                        Price = 75.00m,
                        Quantity = 10,
                        SneakerPic = "RCL.jpeg",
                        Description = "The Reebok Classic Leather is an iconic sneaker known for its timeless style and versatility. With a soft leather upper and cushioned midsole, it delivers all-day comfort and classic streetwear appeal."
                    },
                    new Sneakers()
                    {
                        Name = "Puma Suede Classic",
                        Brand = "Puma",
                        Price = 65.00m,
                        Quantity = 8,
                        SneakerPic = "PSC.jpeg",
                        Description = "The Puma Suede Classic is a retro-inspired sneaker that combines sporty style with everyday comfort. Its suede upper and padded collar provide a soft feel and secure fit, while the rubber outsole offers traction and durability."
                    },
                    // Add five more sneakers with descriptions...
                    new Sneakers()
                    {
                        Name = "Asics Gel-Lyte III",
                        Brand = "Asics",
                        Price = 120.00m,
                        Quantity = 7,
                        SneakerPic = "AGL.jpeg",
                        Description = "The Asics Gel-Lyte III features a split tongue design and GEL cushioning for enhanced comfort and support. Its retro-inspired silhouette and premium materials make it a stylish choice for casual wear."
                    },
                    new Sneakers()
                    {
                        Name = "Saucony Jazz Original",
                        Brand = "Saucony",
                        Price = 70.00m,
                        Quantity = 9,
                        SneakerPic = "SJO.jpeg",
                        Description = "The Saucony Jazz Original is a classic running shoe with a timeless design and superior comfort. Its nylon and suede upper provides durability and breathability, while the EVA midsole offers lightweight cushioning for all-day wear."
                    },
                    new Sneakers()
                    {
                        Name = "Under Armour HOVR Phantom",
                        Brand = "Under Armour",
                        Price = 140.00m,
                        Quantity = 5,
                        SneakerPic = "UAH.jpeg",
                        Description = "The Under Armour HOVR Phantom is a high-performance running shoe designed for maximum comfort and energy return. Its HOVR technology provides a responsive ride, while the compression mesh upper offers a secure and breathable fit."
                    },
                    new Sneakers()
                    {
                        Name = "Brooks Ghost 14",
                        Brand = "Brooks",
                        Price = 130.00m,
                        Quantity = 8,
                        SneakerPic = "BG14.jpeg",
                        Description = "The Brooks Ghost 14 is a versatile running shoe that offers a smooth and cushioned ride. Its DNA LOFT cushioning and Segmented Crash Pad provide plush comfort and reliable support, making it ideal for long-distance running."
                    },
                    new Sneakers()
                    {
                        Name = "Mizuno Wave Rider 25",
                        Brand = "Mizuno",
                        Price = 140.00m,
                        Quantity = 6,
                        SneakerPic = "MWR.jpeg",
                        Description = "The Mizuno Wave Rider 25 is a neutral running shoe designed for runners seeking responsive cushioning and a smooth transition. Its Mizuno Wave technology and U4icX midsole deliver a comfortable and energized ride."
                    }
                    };

                _dbConnection.InsertAll(sneakers);

            }

            if (_dbConnection.Table<Customers>().Count() == 0)
            {
                Customers customer = new Customers()
                {
                    CustomersName = "John",
                    CustomersSurname = "Doe",
                    EmailAddress = "johndoe@example.com",
                    Bio = "im a student"

                };

                _dbConnection.Insert(customer);
            }

        }


        public void SaveShoppingCart(ShoppingCart cart)
        {
            _dbConnection.Insert(cart);
        }

        public List<ShoppingCart> GetShoppingCartByCustomerId(int customerId)
        {
            return _dbConnection.Table<ShoppingCart>().Where(c => c.CustomerId == customerId).ToList();
        }

        public void UpdateShoppingCart(ShoppingCart cart)
        {
            // Check if the item already exists in the shopping cart
            var existingItem = _dbConnection.Table<ShoppingCart>()
                                            .FirstOrDefault(c => c.SneakerId == cart.SneakerId);

            if (existingItem != null)
            {
                // If the item exists, increment its quantity
                existingItem.Quantity++; // Increment by one click
                _dbConnection.Update(existingItem);
            }
            else
            {
                // If the item doesn't exist, add it to the shopping cart with a quantity of 1
                cart.Quantity = 1; // Initial quantity
                _dbConnection.Insert(cart);
            }
        }


        public void DeleteShoppingCart(ShoppingCart cart)
        {
            _dbConnection.Delete(cart);
        }

        public void AssignShoppingCartsToCustomers()
        {
            // Get all customers and shopping carts from the database
            List<Customers> customers = _dbConnection.Table<Customers>().ToList();
            List<ShoppingCart> shoppingCarts = _dbConnection.Table<ShoppingCart>().ToList();

            // Assign a shopping cart to each customer
            foreach (Customers customer in customers)
            {
                // Check if the customer already has a shopping cart
                ShoppingCart existingCart = shoppingCarts.FirstOrDefault(c => c.CustomerId == customer.CustomerId);

                if (existingCart == null)
                {
                    // If the customer doesn't have a shopping cart, create a new one and assign it to the customer
                    ShoppingCart newCart = new ShoppingCart() { CustomerId = customer.CustomerId };
                    _dbConnection.Insert(newCart);
                }
            }
        }

        public void SaveCustomer(Customers customer)
        {
            _dbConnection.InsertOrReplace(customer);
        }

        public Customers GetSavedCustomer()
        {
            return _dbConnection.Table<Customers>().FirstOrDefault();
        }


        public Customers GetCustomerByEmail(string email)
        {
            return _dbConnection.Table<Customers>().Where(c => c.EmailAddress == email).FirstOrDefault();
        }


        public List<Sneakers> GetSelectedSneakers()
        {
            return _dbConnection.Table<Sneakers>().Where(s => s.IsSelected).ToList();
        }
    }


    public static class DatabaseFilePath
    {
        public static string GetDatabasePath()
        {
            string filename = "sneakerdata.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }


    }
    }