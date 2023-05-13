using System;

namespace L6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Start();
        }
    }

    class Product
    {
        private string _name;
        private int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public string Name => _name;
        public int Price => _price;
    }

    class Customer
    {
        private List<Product> _products;
        private int _wallet;

        public Customer(int money)
        {
            _products = new List<Product>();
            _wallet = money;
        }

        public List<Product> FoodBasket => _products;

        private Product? ThrowAwayRandomProduct()
        {
            Random random = new Random();
            Product? product = _products[random.Next(_products.Count)];
            return product;
        }

        public int Pay(int totalCost)
        {
            int empty = 0;
            int cash = empty;

            if (_wallet == empty)
            {
                Console.WriteLine("У клиента нет средств для оплаты товаров");
            }
            else if (totalCost <= _wallet)
            {
                _wallet -= totalCost;
                Console.WriteLine($"Клиент оплатил товаров на сумму {totalCost}$");
                cash = totalCost;
            }
            else
            {
                Product? product = ThrowAwayRandomProduct();

                if (product != null)
                {
                    _products.Remove(product);
                    Console.WriteLine($"Клиент вытащил из корзины {product.Name}");
                    cash = Pay(totalCost - product.Price);
                }
                else
                {
                    Console.WriteLine("В корзине уже нет продуктов");
                }
            }

            return cash;
        }

        public void PutProduct(Product product)
        {
            _products.Add(product);
            Console.WriteLine($"{product.Name} добавлен в корзину");
        }
    }

    class Shop
    {
        private int _cash;
        private List<Product> _groceries;
        private List<Customer> _customers;

        public Shop()
        {
            _cash = 0;
            _groceries = new List<Product>();
            _customers = new List<Customer>();
            Initialize();
        }

        private void Initialize()
        {
            _groceries.Add(new Product("Хлеб", 1));
            _groceries.Add(new Product("Молоко", 3));
            _groceries.Add(new Product("Яйцо", 4));
            _groceries.Add(new Product("Бананы", 2));
            _groceries.Add(new Product("Мясо", 5));
            Random random = new Random();
            int maxCustomers = 5;
            int minCash = 0;
            int maxCash = 16;

            for (int i = 0; i < maxCustomers; i++)
            {
                _customers.Add(new Customer(random.Next(minCash, maxCash)));
            }
        }

        private int CalculateTotalCost(List<Product> products)
        {
            int totalCost = 0;

            foreach (Product item in products)
            {
                totalCost += item.Price;
            }

            return totalCost;
        }

        private void ToCash(int cash)
        {
            _cash += cash;
            Console.WriteLine($"Операция завершена, в кассе {_cash}$\n");
        }

        private void SellProducts(Customer customer)
        {
            const string CommandPay = "pay";
            bool isChoice = true;
            Console.WriteLine("перечень продуктов:");

            for (int i = 0; i < _groceries.Count; i++)
            {
                Product product = _groceries[i];
                Console.WriteLine($"{i}. {product.Name} - {product.Price}$");
            }

            while (isChoice)
            {
                int id = -1;
                Console.Write($"Выберите товар или введите {CommandPay} для оплаты:");
                string inputCustomer = Console.ReadLine();
                bool validCommand = int.TryParse(inputCustomer, out id);

                if (validCommand && id < _groceries.Count)
                {
                    customer.PutProduct(_groceries[id]);
                }
                else if (inputCustomer == CommandPay)
                {
                    isChoice = false;
                }
                else
                {
                    Console.WriteLine("Такого товара нет, выберите снова");
                }
            }

            int totalCost = CalculateTotalCost(customer.FoodBasket);
            int cash = customer.Pay(totalCost);
            ToCash(cash);
        }

        public void Start()
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                Console.WriteLine($"Клиент - {i + 1}");
                SellProducts(_customers[i]);
            }

            Console.WriteLine("Все клиенты обслужены!");
        }
    }
}