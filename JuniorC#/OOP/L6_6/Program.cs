using System;

namespace L6_6
{
  class Program
  {
    static void Main(string[] args)
    {
      Store store = new Store();
      store.Open();
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

  class Participant
  {
    public int Money { get; set; }
    public List<Product> Products { get; set; }

    public Participant()
    {
      Products = new List<Product>();
      Money = 0;
    }
  }

  class Buyer : Participant
  {
    public Buyer(int money) : base()
    {
      Money = money;
    }

    public void ShowMoney()
    {
      Console.WriteLine($"{Money}$");
    }

    public void ShowBasket()
    {
      foreach (var product in Products)
      {
        Console.WriteLine(product.Name);
      }
    }

    public void BuyProduct(Product product)
    {
      Money -= product.Price;
      Products.Add(product);
    }

    public bool CheckIsCanPay(int price)
    {
      return price <= Money;
    }
  }

  class Seller : Participant
  {
    public void ShowAssortiment()
    {
      foreach (Product product in Products)
      {
        Console.WriteLine($"{product.Name} - {product.Price}$");
      }
    }

    public Product? TryGetProduct(string name)
    {
      var product = Products.Find(product => product.Name.ToLower().Contains(name.ToLower()));
      return product;
    }

    public void SellProduct(Product product)
    {
      Products.Remove(product);
      Money += product.Price;
    }

    public void AddProduct(Product product)
    {
      Products.Add(product);
    }
  }

  class Store
  {
    private bool _isOpen;
    private Buyer _bayer;
    private Seller _seller;

    public Store()
    {
      _isOpen = true;
      _seller = new Seller();
      AcceptanceOfProducts();
    }

    public void Open()
    {
      const string CommandShowProducts = "1";
      const string CommandBuyProduct = "2";
      const string CommandShowMoney = "3";
      const string CommandShowBasket = "4";
      const string CommandExit = "5";

      while (_isOpen)
      {
        if (_bayer == null)
        {
          int money = 0;
          Console.WriteLine("Сколько у вас денег?");
          bool isValid = int.TryParse(Console.ReadLine(), out money);

          if (isValid)
          {
            _bayer = new Buyer(money);
          }
          else
          {
            Console.WriteLine("Введите валидные данные");
          }
        }
        else
        {
          Console.WriteLine("Доступные команды:");
          Console.WriteLine($"{CommandShowProducts} - показать все продукты");
          Console.WriteLine($"{CommandBuyProduct} - купить продукт");
          Console.WriteLine($"{CommandShowMoney} - посмотреть доступные средства");
          Console.WriteLine($"{CommandShowBasket} - показать товары в корзине");
          Console.WriteLine($"{CommandExit} - завершить покупки");
          Console.Write("Введите команду: ");
          string userCommand = Console.ReadLine();

          switch (userCommand)
          {
            case CommandShowProducts:
              _seller.ShowAssortiment();
              break;

            case CommandBuyProduct:
              Transfer();
              break;

            case CommandShowMoney:
              _bayer.ShowMoney();
              break;

            case CommandShowBasket:
              _bayer.ShowBasket();
              break;

            case CommandExit:
              _isOpen = false;
              Console.WriteLine("Приходите ещё");
              break;

            default:
              Console.WriteLine("Введите корректную команду");
              break;
          }

          Console.ReadKey();
          Console.Clear();
        }
      }
    }

    private void AcceptanceOfProducts()
    {
      _seller.AddProduct(new Product("Хлеб", 1));
      _seller.AddProduct(new Product("Молоко", 2));
      _seller.AddProduct(new Product("Мясо", 5));
      _seller.AddProduct(new Product("Икра", 25));
      _seller.AddProduct(new Product("Билет на Луну", 2147483647));
    }

    private void Transfer()
    {
      int minNameLenght = 3;
      Product? product = null;
      Console.WriteLine("Какой товар желаете приобрести?");
      string userInput = Console.ReadLine();

      if (userInput.Trim().Length < minNameLenght)
      {
        Console.WriteLine("Введите корректное название продукта");
      }
      else
      {
        product = _seller.TryGetProduct(userInput);

        if (product == null)
        {
          Console.WriteLine("Такого товара нет");
        }
        else
        {
          bool isEnoughMoney = _bayer.CheckIsCanPay(product.Price);

          if (isEnoughMoney)
          {
            _seller.SellProduct(product);
            _bayer.BuyProduct(product);
            Console.WriteLine("Спасибо за покупку");
          }
          else
          {
            Console.WriteLine("У вас не хватает средств");
          }
        }
      }
    }
  }
}
