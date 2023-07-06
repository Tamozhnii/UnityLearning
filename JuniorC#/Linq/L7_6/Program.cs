using System;

namespace L7_6
{
    class Program
    {
        static void Main(string[] args)
        {
            MilitaryDataBase militaryDataBase = new MilitaryDataBase();
            militaryDataBase.ShowData();
        }
    }

    class MilitaryDataBase
    {
        private List<Solder> _solders;

        public MilitaryDataBase()
        {
            _solders = new List<Solder>();
            Initialize();
        }

        public void ShowData()
        {
            IEnumerable<Person> solders = from solder in _solders select (new Person(solder.Name, solder.Rank));

            foreach (var solder in solders)
            {
                Console.WriteLine($"{solder.Name} - {solder.Rank}");
            }
        }

        private void Initialize()
        {
            _solders.Add(new Solder("Tom", Weapons.AutoGun, Ranks.Sergeant, 24));
            _solders.Add(new Solder("Sam", Weapons.GrenadeGun, Ranks.Ordinary, 12));
            _solders.Add(new Solder("John", Weapons.Knife, Ranks.Lieutenant, 15));
            _solders.Add(new Solder("Tonny", Weapons.Pistol, Ranks.General, 90));
            _solders.Add(new Solder("Shon", Weapons.Tank, Ranks.Colonel, 78));
            _solders.Add(new Solder("Mark", Weapons.Pistol, Ranks.Captain, 45));
        }
    }

    class Person
    {
        public Person(string name, Ranks rank)
        {
            Name = name;
            Rank = rank;
        }

        public string Name { get; private set; }
        public Ranks Rank { get; private set; }
    }

    class Solder
    {
        public Solder(string name, Weapons arms, Ranks rank, int periodOfService)
        {
            Name = name;
            Arms = arms;
            Rank = rank;
            PeriodOfService = periodOfService;
        }

        public string Name { get; private set; }
        public Weapons Arms { get; private set; }
        public Ranks Rank { get; private set; }
        public int PeriodOfService { get; private set; }
    }

    enum Ranks
    {
        Ordinary,
        Sergeant,
        Lieutenant,
        Captain,
        Colonel,
        General,
    }

    enum Weapons
    {
        Pistol,
        AutoGun,
        GrenadeGun,
        Tank,
        Knife,
    }
}