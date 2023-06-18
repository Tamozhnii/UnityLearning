using System;

namespace L6_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium(7, 3, 10);
            aquarium.Play();
        }
    }

    class Fish
    {
        private string _name;
        private ConsoleColor _color;
        private int _remainingAge;
        private int _maxAge;

        public Fish(string name, int age, ConsoleColor color)
        {
            _name = name;
            _color = color;
            _remainingAge = age;
            _maxAge = age;
        }

        public int RemainingAge => _remainingAge;

        public void ToLive()
        {
            _remainingAge--;
        }

        public void Show()
        {
            string life = "";

            for (int i = 0; i < _maxAge; i++)
            {
                if (i < _remainingAge)
                {
                    life += '#';
                }
                else
                {
                    life += '_';
                }
            }

            Console.ForegroundColor = _color;
            Console.WriteLine($"{_name} - {life}");
            Console.ResetColor();
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxFishCount;
        private int _minFishAge;
        private int _maxFishAge;
        private Random _random;

        public Aquarium(int maxFishCount = 7, int minFishAge = 3, int maxFishAge = 10)
        {
            _fishes = new List<Fish>();
            _maxFishCount = ValidateValue(maxFishCount);
            _minFishAge = ValidateValue(minFishAge);
            _maxFishAge = ValidateValue(maxFishAge);
            _random = new Random();
        }

        public void Play()
        {
            const string AddFishCommand = "1";
            const string PickUpCommand = "2";
            const string ExitCommand = "3";

            bool isUse = true;

            while (isUse)
            {
                Console.WriteLine($"Продолжить - любой символ");
                Console.WriteLine($"Добавить рыбу - {AddFishCommand}");
                Console.WriteLine($"Достать случайную рыбу - {PickUpCommand}");
                Console.WriteLine($"Выйти - {ExitCommand}\n");
                Console.Write($"\nВведите команду:");
                string command = Console.ReadLine();

                switch (command)
                {
                    case AddFishCommand:
                        AddFish();
                        break;

                    case PickUpCommand:
                        PickUpFish();
                        break;

                    case ExitCommand:
                        isUse = false;
                        break;

                    default:
                        GetThrough();
                        break;
                }

                if (isUse)
                {
                    Console.ReadKey();
                    Console.Clear();
                    ShowFishes();
                }
            }
        }

        private int ValidateValue(int value)
        {
            int minValue = 1;
            int maxValue = 10;

            if ((value >= minValue) && (value <= maxValue))
            {
                return value;
            }
            else
            {
                return maxValue;
            }
        }

        private void AddFish()
        {
            if (_fishes.Count >= _maxFishCount)
            {
                Console.WriteLine("\nАквариум переполнен!");
            }
            else
            {
                Console.Write("Введите имя/название рыбы: ");
                string name = Console.ReadLine();
                int age = _random.Next(_minFishAge, _maxFishAge);
                ConsoleColor color = GetColor();
                _fishes.Add(new Fish(name, age, color));
                Console.WriteLine("\nРыба добавлена");
            }
        }

        private void PickUpFish()
        {
            if (_fishes.Count > 0)
            {
                int index = _random.Next(_fishes.Count);
                _fishes.RemoveAt(index);
                Console.WriteLine("\nСлучайная рыба была выловлена");
            }
            else
            {
                Console.WriteLine("\nВ аквариуме нет рыб");
            }
        }

        private void ShowFishes()
        {
            if (_fishes.Count <= 0)
            {
                Console.WriteLine("Аквариум пуст");
            }
            else
            {
                foreach (Fish fish in _fishes)
                {
                    fish.Show();
                }
            }

            Console.WriteLine("\n");
        }

        private void GetThrough()
        {
            foreach (Fish fish in _fishes)
            {
                fish.ToLive();
            }

            _fishes.RemoveAll(fish => fish.RemainingAge <= 0);
        }

        private ConsoleColor GetColor()
        {
            int colorsCount = 7;
            int num = _random.Next(colorsCount);

            switch (num)
            {
                case 1:
                    return ConsoleColor.Blue;
                case 2:
                    return ConsoleColor.Green;
                case 3:
                    return ConsoleColor.Red;
                case 4:
                    return ConsoleColor.Yellow;
                case 5:
                    return ConsoleColor.Cyan;
                case 6:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}