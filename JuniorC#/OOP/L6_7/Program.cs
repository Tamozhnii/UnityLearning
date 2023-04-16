using System;

namespace L6_7
{
  class Program
  {
    static void Main(string[] args)
    {
      TrainPlan trainPlan = new TrainPlan();
      trainPlan.Start();
    }
  }

  class TrainPlan
  {
    private List<TrainDirection> _directions;

    public TrainPlan()
    {
      _directions = new List<TrainDirection>();
    }

    private void CreateDirection()
    {
      Console.WriteLine("Откуда:");
      string from = Console.ReadLine();
      Console.WriteLine("Куда:");
      string to = Console.ReadLine();
      TrainDirection trainDirection = new TrainDirection(from, to);
      _directions.Add(trainDirection);
    }

    private void DisplayDirections()
    {
      Console.Clear();
      Console.SetCursorPosition(0, 0);
      int offset = 3;

      if (_directions.Count > 0)
      {
        foreach (TrainDirection direction in _directions)
        {
          Console.WriteLine(direction.ToString());
        }

        Console.SetCursorPosition(0, _directions.Count + offset);
      }
      else
      {
        Console.WriteLine("Нет рейсов");
        Console.SetCursorPosition(0, offset);
      }
    }

    public void Start()
    {
      const string CommandCreateDirection = "create";
      const string CommandExit = "exit";

      bool isOpen = true;

      while (isOpen)
      {
        DisplayDirections();
        Console.WriteLine($"{CommandCreateDirection} - создать направление");
        Console.WriteLine($"{CommandExit} - выйти из программы");
        string userComand = Console.ReadLine();

        switch (userComand)
        {
          case CommandCreateDirection:
            CreateDirection();
            break;

          case CommandExit:
            isOpen = false;
            break;

          default:
            Console.WriteLine("Введите корректную команду");
            break;
        }
      }
    }
  }

  class TrainDirection
  {
    private string _from;
    private string _to;
    private Train _train;
    private int _tickets;

    public TrainDirection(string From, string To)
    {
      _from = From;
      _to = To;
      _tickets = SellTickets();
      _train = new Train(_tickets);
    }

    private int SellTickets()
    {
      int minCount = 10;
      int maxCount = 150;
      Random random = new Random();
      int tickets = random.Next(minCount, maxCount);
      Console.WriteLine($"Продано билетов {tickets}");
      return tickets;
    }

    public override string ToString()
    {
      return $"Направление {_from} - {_to}, поезд в составе из {_train.WagonCount} вагонов отправлен";
    }
  }

  class Train
  {
    private List<Wagon> _wagons;

    public Train(int tickets)
    {
      _wagons = new List<Wagon>();
      GenerateTrain(tickets);
    }

    public int WagonCount => _wagons.Count;

    private void GenerateTrain(int tickets)
    {
      const string CommandAddWagon = "add";
      const string CommandSendTrain = "send";

      while (tickets > GetCapacity())
      {
        int leftTickets = tickets - GetCapacity();
        Console.WriteLine($"Осталось еще {leftTickets}, добавьте вагон:");
        _wagons.Add(new Wagon());
      }

      Console.WriteLine("Поезд сформирован и отправлен");
    }

    private int GetCapacity()
    {
      int capacity = 0;

      foreach (Wagon wagon in _wagons)
      {
        capacity += wagon.Capacity;
      }

      return capacity;
    }
  }

  class Wagon
  {
    private int _capacity;
    private string _type;

    public Wagon()
    {
      DefineWagon();
    }

    public int Capacity => _capacity;

    private void DefineWagon()
    {
      const string WagonTypeVip = "vip";
      const string WagonTypePremium = "premium";
      const string WagonTypeEconom = "econom";

      Console.WriteLine($"{WagonTypeVip} - добавить VIP вагон на 10 человек");
      Console.WriteLine($"{WagonTypePremium} - добавить вагон премиум класса на 30 человек");
      Console.WriteLine($"{WagonTypeEconom} - добавить вагон эконом класса на 60 человек (этот вагон будет добавлен по умолчанию)");
      string userInput = Console.ReadLine();

      switch (userInput)
      {
        case WagonTypeVip:
          _type = WagonTypeVip;
          _capacity = 10;
          break;

        case WagonTypePremium:
          _type = WagonTypePremium;
          _capacity = 30;
          break;

        case WagonTypeEconom:
          _type = WagonTypeEconom;
          _capacity = 60;
          break;

        default:
          _type = WagonTypeEconom;
          _capacity = 60;
          break;
      }
    }
  }
}
