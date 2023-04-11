using System;

namespace L6_6
{
  class Program
  {
    static void Main(string[] args)
    {
      Store store = new Store();
      store.ToShop();
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

    public override string ToString()
    {
      return $"{_name} - {_price}$";
    }
  }

  class Player
  {
    private int _money;
    private List<Product> _basket;

    public Player(int money)
    {
      _basket = new List<Product>();
      _money = money;
    }

    public int Money => _money;

    public void ShowMoney()
    {
      Console.WriteLine($"{_money}$");
    }

    public void ShowBasket()
    {
      foreach (var product in _basket)
      {
        Console.WriteLine(product.Name);
      }
    }

    public void BuyProduct(Product product)
    {
      _money -= product.Price;
      _basket.Add(product);
    }
  }

  class Seller
  {
    private List<Product> _assortment;
    private int _cashRegister;

    public Seller()
    {
      _assortment = new List<Product>();
      _cashRegister = 0;
    }

    public void ShowAssortiment()
    {
      foreach (Product product in _assortment)
      {
        Console.WriteLine(product.ToString());
      }
    }

    public Product? FindProduct(string name)
    {
      var product = _assortment.Find(product => product.Name.ToLower().Contains(name.ToLower()));
      return product;
    }

    public void SellProduct(Product product)
    {
      _assortment.Remove(product);
      _cashRegister += product.Price;
    }

    public void AddProduct(Product product)
    {
      _assortment.Add(product);
    }
  }

  class Store
  {
    private bool _isInStore;
    private Player _player;
    private Seller _seller;

    public Store()
    {
      _isInStore = true;
      _seller = new Seller();
      AcceptanceOfProducts();
    }

    public void ToShop()
    {
      const string CommandShowProducts = "1";
      const string CommandBuyProduct = "2";
      const string CommandShowMoney = "3";
      const string CommandShowBasket = "4";
      const string CommandExit = "5";

      while (_isInStore)
      {
        if (_player == null)
        {
          int money = 0;
          Console.WriteLine("Сколько у вас денег?");
          bool isValid = int.TryParse(Console.ReadLine(), out money);

          if (isValid)
          {
            _player = new Player(money);
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
              ToBuy();
              break;

            case CommandShowMoney:
              _player.ShowMoney();
              break;

            case CommandShowBasket:
              _player.ShowBasket();
              break;

            case CommandExit:
              _isInStore = false;
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

    private void ToBuy()
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
        product = _seller.FindProduct(userInput);

        if (product == null)
        {
          Console.WriteLine("Такого товара нет");
        }
        else
        {
          if (_player.Money < product.Price)
          {
            Console.WriteLine("У вас не хватает средств");
          }
          else
          {
            _seller.SellProduct(product);
            _player.BuyProduct(product);
            Console.WriteLine("Спасибо за покупку");
          }
        }
      }
    }
  }
}
