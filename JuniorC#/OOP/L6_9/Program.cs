using System;

namespace L6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Begin();
        }
    }

    class Product
    {
        private Groceries _name;
        private int _price;

        public Product(Groceries name, int price)
        {
            _name = name;
            _price = price;
        }

        public Groceries Name => _name;
        public int Price => _price;
    }

    class Customer
    {
        private Random _random;
        private List<Product> _products;
        private int _wallet;

        public Customer(int money, List<Product> assortment)
        {
            _random = new Random();
            _products = new List<Product>();
            _wallet = money;
            PickUpProducts(assortment);
        }

        public void ShowProducts()
        {
            Console.Write("В корзине у клиента: ");

            if (_products.Count > 0)
            {
                foreach (Product item in _products)
                {
                    Console.Write($"{item.Name} ");
                }
            }
            else
            {
                Console.Write("Пусто");
            }

            Console.WriteLine();
        }

        public int Pay()
        {
            int empty = 0;
            int totalCost = CalculateTotalCost();
            int cash = empty;

            if (totalCost == empty)
            {
                Console.WriteLine("Клиент ничего не приобрел");
            }
            else if (_wallet == empty)
            {
                Console.WriteLine("У клиента нет средств для оплаты товаров");
            }
            else
            {
                for (int i = _products.Count; i > 0; i--)
                {
                    if (totalCost > _wallet)
                    {
                        Product? product = ThrowAwayRandomProduct();

                        if (product != null)
                        {
                            totalCost -= product.Price;
                            Console.WriteLine($"Клиент вытащил из корзины {product.Name}");
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (_products.Count == empty)
                {
                    Console.WriteLine("У клиента не хватило средств");
                }
                else if (totalCost <= _wallet)
                {
                    _wallet -= totalCost;
                    Console.WriteLine($"Клиент оплатил товаров на сумму {totalCost}$");
                    cash = totalCost;
                }
                else
                {
                    Console.WriteLine("У клиента не хватило средств на оплату");
                }
            }

            return cash;
        }

        private void PickUpProducts(List<Product> assortment)
        {
            for (int i = 0; i < _random.Next(assortment.Count); i++)
            {
                int productId = _random.Next(assortment.Count);
                _products.Add(new Product(assortment[productId].Name, assortment[productId].Price));
            }
        }

        private int CalculateTotalCost()
        {
            int totalCost = 0;

            foreach (Product item in _products)
            {
                totalCost += item.Price;
            }

            return totalCost;
        }

        private Product? ThrowAwayRandomProduct()
        {
            Product? randomProduct = _products[_random.Next(_products.Count)];
            _products.Remove(randomProduct);
            return randomProduct;
        }
    }

    class Shop
    {
        private int _cash;
        private List<Product> _assortment;
        private List<Customer> _customers;

        public Shop()
        {
            _cash = 0;
            _assortment = new List<Product>();
            _customers = new List<Customer>();
            Initialize();
        }

        public void Begin()
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                int clientNumber = i + 1;
                Console.WriteLine($"Клиент - {clientNumber}");
                _customers[i].ShowProducts();
                int cash = _customers[i].Pay();
                MakePayment(cash);
            }

            Console.WriteLine("Все клиенты обслужены!");
        }

        private void Initialize()
        {
            _assortment.Add(new Product(Groceries.Bread, 1));
            _assortment.Add(new Product(Groceries.Milk, 3));
            _assortment.Add(new Product(Groceries.Eggs, 4));
            _assortment.Add(new Product(Groceries.Apples, 2));
            _assortment.Add(new Product(Groceries.Meat, 5));
            Random random = new Random();
            int maxCustomers = 5;
            int minCash = 0;
            int maxCash = 16;

            for (int i = 0; i < maxCustomers; i++)
            {
                _customers.Add(new Customer(random.Next(minCash, maxCash), _assortment));
            }
        }

        private void MakePayment(int cash)
        {
            _cash += cash;
            Console.WriteLine($"Операция завершена, в кассе {_cash}$\n");
        }
    }

    enum Groceries
    {
        Bread,
        Milk,
        Meat,
        Apples,
        Eggs
    }
}