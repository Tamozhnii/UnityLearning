using System;

namespace L7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Detective detective = new Detective();
            detective.Ask();
        }
    }

    class Detective
    {
        private DataBase _dataBase;

        public Detective()
        {
            _dataBase = new DataBase();
        }

        public void Ask()
        {
            Console.WriteLine("Укажите известные приметы");
            Console.WriteLine("Рост (Целое число):");
            string findWeight = Console.ReadLine();
            Console.WriteLine("Вес (Натуральное число через запятую, например 65,5):");
            string findGrowth = Console.ReadLine();
            Console.WriteLine("Национальность (например Русский, Американец или можно ввести часть слова):");
            string findNationality = Console.ReadLine();
            Int32.TryParse(findWeight, out int weight);
            Single.TryParse(findGrowth, out float growth);

            if (weight > 0 && growth > 0 && findNationality.Length > 0)
            {
                _dataBase.SearchData(weight, growth, findNationality);
            }
            else if (weight > 0 && growth > 0)
            {
                _dataBase.SearchData(weight, growth);
            }
            else if (growth > 0 && findNationality.Length > 0)
            {
                _dataBase.SearchData(growth, findNationality);
            }
            else if (weight > 0 && findNationality.Length > 0)
            {
                _dataBase.SearchData(weight, findNationality);
            }
            else if (weight > 0)
            {
                _dataBase.SearchData(weight);
            }
            else if (growth > 0)
            {
                _dataBase.SearchData(growth);
            }
            else if (findNationality.Length > 0)
            {
                _dataBase.SearchData(findNationality);
            }
            else
            {
                Console.WriteLine("Без указание примет невозможно найти");
            }

            Console.ReadKey();
        }
    }

    class DataBase
    {
        private List<Criminal> _criminals;

        public DataBase()
        {
            _criminals = new List<Criminal>();
            Initialize();
        }

        public void SearchData(int growth)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Growth == growth && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(float weight)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Weight == weight && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(string nationality)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(int growth, float weight)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Growth == growth && criminal.Weight == weight && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(float weight, string nationality)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Weight == weight && criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(int growth, string nationality)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Growth == growth && criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        public void SearchData(int growth, float weight, string nationality)
        {
            var findCriminals = _criminals.FindAll(criminal => criminal.Growth == growth && criminal.Weight == weight && criminal.Nationality.ToLower() == nationality.ToLower() && criminal.IsWanted);
            ShowInfo(findCriminals);
        }

        private void ShowInfo(List<Criminal> criminals)
        {
            if (criminals.Count > 0)
            {
                foreach (Criminal criminal in criminals)
                {
                    Console.WriteLine(criminal.ToString());
                }
            }
            else
            {
                Console.WriteLine("Данные не найдены");
            }
        }

        private void Initialize()
        {
            _criminals.Add(new Criminal("Джон Доу", 160, 72.5f, "Американец", false));
            _criminals.Add(new Criminal("Виктор Драгунов", 180, 85f, "Русский", true));
            _criminals.Add(new Criminal("Брюс Ли", 180, 85f, "Китаец", false));
            _criminals.Add(new Criminal("Бонапарт наполеон", 180, 85f, "Француз", true));
            _criminals.Add(new Criminal("Аль Капоне", 160, 85f, "Итальянец", false));
            _criminals.Add(new Criminal("Хидео Кодзима", 180, 72.5f, "Японец", true));
            _criminals.Add(new Criminal("Сонг Янг", 160, 85f, "Кореец", false));
            _criminals.Add(new Criminal("Эль Мучачос", 180, 72.5f, "Мексиканец", true));
        }
    }

    class Criminal
    {
        public Criminal(string fullName, int growth, float weight, string nationality, bool isWanted)
        {
            FullName = fullName;
            Growth = growth;
            Weight = weight;
            Nationality = nationality;
            IsWanted = isWanted;
        }

        public string FullName { get; private set; }
        public int Growth { get; private set; }
        public float Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool IsWanted { get; private set; }

        public override string ToString()
        {
            return $"{FullName}, рост - {Growth}, вес - {Weight}, национальность - {Nationality}.";
        }
    }
}