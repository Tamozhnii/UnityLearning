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
      Database database = new Database();

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
            database.AddNewPlayer();
            break;

          case CommandShowAllPlayer:
            database.ShowAllPlayers();
            break;

          case CommandBanPlayer:
            database.BanPlayer();
            break;

          case CommandUnbanPlayer:
            database.UnbanPlayer();
            break;

          case CommandDeletePlayer:
            database.DeletePlayer();
            break;

          case CommandExit:
            isWork = false;
            break;

          default:
            Console.WriteLine("Такой команды не существует");
            break;
        }

        Console.ReadKey();
        Console.Clear();
      }
    }

  }

  class Player
  {
    public Player(string nickName, int level, bool isBan)
    {
      NickName = nickName;
      IsBan = isBan;
      Level = level;
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

  class Database
  {
    private Dictionary<int, Player> _players;
    private int _counter;

    public Database()
    {
      _players = new Dictionary<int, Player>();
      _counter = 0;
    }

    public void AddNewPlayer()
    {
      int level;
      bool isValidLevel = true;
      bool isValidNickName = true;
      Console.Write("Введите ник: ");
      string nickName = Console.ReadLine();
      Console.Write("Введите уровень персонажа: ");
      string playerLevel = Console.ReadLine();
      isValidLevel = int.TryParse(playerLevel, out level);

      foreach (var player in _players)
      {
        if (player.Value.NickName == nickName)
        {
          isValidNickName = false;
        }
      }

      if (isValidNickName == false)
      {
        Console.WriteLine("Пользователь с таким ником уже существует");
      }
      else if (isValidLevel == false || level < 0)
      {
        Console.WriteLine("Вы ввели некорректный уровень");
      }
      else if (isValidNickName && isValidLevel)
      {
        Player player = new Player(nickName, level, false);
        _players.Add(_counter, player);
        _counter++;
        Console.WriteLine("Пользователь успешно добавлен");
      }
    }

    public void BanPlayer()
    {
      Console.Write("Введите id персонажа, которого хотите забанить: ");
      bool isIncludes = TryGetPlayer(out int playerId);

      if (isIncludes)
      {
        _players[playerId].Ban();
      }
    }

    public void UnbanPlayer()
    {
      Console.Write("Введите id персонажа, которого хотите разбанить: ");
      bool isIncludes = TryGetPlayer(out int playerId);

      if (isIncludes)
      {
        _players[playerId].Unban();
      }
    }

    public void DeletePlayer()
    {
      Console.Write("Введите id персонажа, которого хотите удалить: ");
      bool isIncludes = TryGetPlayer(out int playerId);

      if (isIncludes)
      {
        _players.Remove(playerId);
      }
    }

    public void ShowAllPlayers()
    {
      foreach (var player in _players)
      {
        Console.WriteLine($"{player.Key}. {player.Value.ToString()}");
      }
    }

    private bool TryGetPlayer(out int id)
    {
      string playerId = Console.ReadLine();
      int.TryParse(playerId, out id);
      bool isFindPlayer = _players.ContainsKey(id);
      return isFindPlayer;
    }
  }
}
