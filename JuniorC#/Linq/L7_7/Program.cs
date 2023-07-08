using System;
using System.Linq;

namespace L7_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.ShowSquadsList();
            dataBase.SquadDistributionByFirstCharInSurname('Б');
            dataBase.ShowSquadsList();
        }

        class Solder
        {
            public Solder(string surname, string name)
            {
                Surname = surname;
                Name = name;
            }

            public string Surname { get; private set; }
            public string Name { get; private set; }

            public override string ToString()
            {
                return $"{Surname} {Name}";
            }
        }

        class DataBase
        {
            private List<Solder> _squadFirst;
            private List<Solder> _squadSecond;

            public DataBase()
            {
                _squadFirst = new List<Solder>();
                _squadSecond = new List<Solder>();
                Initialize();
            }

            public void SquadDistributionByFirstCharInSurname(char condition)
            {
                IEnumerable<Solder> chosenSolder = _squadFirst.Where(solder => solder.Surname.ToUpper().StartsWith(condition));
                _squadFirst = _squadFirst.Except(chosenSolder).ToList();
                _squadSecond = _squadSecond.Union(chosenSolder).ToList();
                Console.WriteLine("\nРаспределение закончено\n");
            }

            public void ShowSquadsList()
            {
                Console.WriteLine("Первый отряд:");

                foreach (Solder solder in _squadFirst)
                {
                    Console.WriteLine(solder.ToString());
                }

                Console.WriteLine("\nВторой отряд:");

                foreach (Solder solder in _squadSecond)
                {
                    Console.WriteLine(solder.ToString());
                }
            }

            private void Initialize()
            {
                _squadFirst.Add(new Solder("Агрба", "Павел"));
                _squadFirst.Add(new Solder("Борисов", "Евгений"));
                _squadFirst.Add(new Solder("Васильев", "Петр"));
                _squadFirst.Add(new Solder("Бородин", "Владимир"));
                _squadFirst.Add(new Solder("Третьяк", "Константин"));
                _squadSecond.Add(new Solder("Пупко", "Игнат"));
                _squadSecond.Add(new Solder("Тронько", "Дима"));
            }
        }
    }
}