using System;

namespace L7_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int topCount = 3;
            Statistic statistic = new Statistic();
            statistic.ShowPlayers();
            statistic.ShowTopByLevel(topCount);
            statistic.ShowTopByPower(topCount);
        }
    }

    class Statistic
    {
        private List<Player> _players;

        public Statistic()
        {
            _players = new List<Player>();
            Initialize();
        }

        public void ShowPlayers(IEnumerable<Player>? players = null)
        {
            if (players != null)
            {
                foreach (Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }
            }
            else
            {
                foreach (Player player in _players)
                {
                    Console.WriteLine(player.ToString());
                }
            }
        }

        public void ShowTopByLevel(int topCount)
        {
            IEnumerable<Player> topPlayers = _players.OrderByDescending(player => player.Level).Take(topCount);
            Console.WriteLine($"\nТоп {topCount} по уровню:");
            ShowPlayers(topPlayers);
        }

        public void ShowTopByPower(int topCount)
        {
            IEnumerable<Player> topPlayers = _players.OrderByDescending(player => player.Power).Take(topCount);
            Console.WriteLine($"\nТоп {topCount} по силе:");
            ShowPlayers(topPlayers);
        }

        private void Initialize()
        {
            _players.Add(new Player("Wolf", 20, 7));
            _players.Add(new Player("Tom", 99, 20));
            _players.Add(new Player("Locky", 7, 3));
            _players.Add(new Player("Johan", 1, 1));
            _players.Add(new Player("Terminator", 77, 19));
            _players.Add(new Player("Madara", 89, 25));
            _players.Add(new Player("Bleach", 93, 18));
            _players.Add(new Player("Cristy", 44, 10));
            _players.Add(new Player("Loly", 18, 5));
            _players.Add(new Player("Kroky", 2, 1));
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public override string ToString()
        {
            return $"{Name}, уровень - {Level}, сила - {Power}";
        }
    }
}