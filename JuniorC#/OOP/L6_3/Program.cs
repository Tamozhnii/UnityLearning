using System;

namespace L6_3
{
  class Program
  {
    static void Main(string[] args)
    {
      const string CommandAddPlayer = "1";
      const string CommandShowAllPlayer = "2";
      const string CommandBanPlayer = "3";
      const string CommandUnbanPlayer = "4";
      const string CommandDeletePlayer = "5";
      const string CommandExit = "6";

      bool isWork = true;
      DataBase database = new DataBase();

      while (isWork)
      {
        Console.WriteLine("Доступные команды:");
        Console.WriteLine($"{CommandAddPlayer} - добавить нового пользователя");
        Console.WriteLine($"{CommandShowAllPlayer} - показать всех пользователей");
        Console.WriteLine($"{CommandBanPlayer} - забанить пользователя");
        Console.WriteLine($"{CommandUnbanPlayer} - разбанить пользователя");
        Console.WriteLine($"{CommandDeletePlayer} - удалить пользователя");
        Console.WriteLine($"{CommandExit} - выйти");
        Console.WriteLine("Введите команду:");
        string userCommand = Console.ReadLine();

        switch (userCommand)
        {
          case CommandAddPlayer:
            AddNewPlayer(database);
            break;

          case CommandShowAllPlayer:
            database.ShowAllPlayers();
            Console.ReadKey();
            break;

          case CommandBanPlayer:
            BanPlayer(database);
            break;

          case CommandUnbanPlayer:
            UnbanPlayer(database);
            break;

          case CommandDeletePlayer:
            DeletePlayer(database);
            break;

          case CommandExit:
            isWork = false;
            break;

          default:
            Console.WriteLine("Такой команды не существует");
            break;
        }

        Console.Clear();
      }
    }

    private static void AddNewPlayer(DataBase dataBase)
    {
      Console.Write("Введите ник: ");
      string nickName = Console.ReadLine();
      Console.Write("Введите уровень персонажа: ");
      int playerLevel = Convert.ToInt32(Console.ReadLine());
      dataBase.AddNewPlayer(nickName, playerLevel);
      Console.ReadKey();
    }

    private static void BanPlayer(DataBase dataBase)
    {
      Console.Write("Введите id персонажа, которого хотите забанить: ");
      string playerId = Console.ReadLine();
      int id = 0;

      if (int.TryParse(playerId, out id))
      {
        dataBase.BanPlayer(id);
      }
    }

    private static void UnbanPlayer(DataBase dataBase)
    {
      Console.Write("Введите id персонажа, которого хотите разбанить: ");
      string playerId = Console.ReadLine();
      int id = 0;

      if (int.TryParse(playerId, out id))
      {
        dataBase.UnbanPlayer(id);
      }
    }

    private static void DeletePlayer(DataBase dataBase)
    {
      Console.Write("Введите id персонажа, которого хотите удалить: ");
      string playerId = Console.ReadLine();
      int id = 0;

      if (int.TryParse(playerId, out id))
      {
        dataBase.DeletePlayer(id);
      }
    }
  }

  class Player
  {
    public Player(string nickName, int level, bool isBan)
    {
      NickName = nickName;
      IsBan = isBan;

      if (level < 0)
      {
        Level = 0;
      }
      else
      {
        Level = level;
      }
    }

    public string NickName { get; private set; }
    public int Level { get; private set; }
    public bool IsBan { get; private set; }

    public void Ban()
    {
      IsBan = true;
    }

    public void Unban()
    {
      IsBan = false;
    }

    public override string ToString()
    {
      string activityStatus;

      if (IsBan)
      {
        activityStatus = "Пользователь заблокирован";
      }
      else
      {
        activityStatus = "Пользователь активен";
      }

      return $"{NickName} - уровень: {Level}. {activityStatus}";
    }
  }

  class DataBase
  {
    private Dictionary<int, Player> _players;
    private int _counter;

    public DataBase()
    {
      _players = new Dictionary<int, Player>();
      _counter = 0;
    }

    public void AddNewPlayer(string nickName, int level)
    {
      bool isValid = true;

      foreach (var player in _players)
      {
        if (player.Value.NickName == nickName)
        {
          isValid = false;
        }
      }

      if (isValid)
      {
        Player player = new Player(nickName, level, false);
        _players.Add(_counter, player);
        _counter++;
        Console.WriteLine("Пользователь успешно добавлен");
      }
      else
      {
        Console.WriteLine("Пользователь с таким ником уже существует");
      }
    }

    public void BanPlayer(int id)
    {
      if (_players.ContainsKey(id))
      {
        _players[id].Ban();
      }
    }

    public void UnbanPlayer(int id)
    {
      if (_players.ContainsKey(id))
      {
        _players[id].Unban();
      }
    }

    public void DeletePlayer(int id)
    {
      if (_players.ContainsKey(id))
      {
        _players.Remove(id);
      }
    }

    public void ShowAllPlayers()
    {
      foreach (var player in _players)
      {
        Console.WriteLine($"{player.Key}. {player.Value.ToString()}");
      }
    }
  }
}
