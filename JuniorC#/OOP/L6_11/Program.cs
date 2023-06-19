﻿using System;

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
        public int RemainingAge { get; private set; }
        private string _name;
        private ConsoleColor _color;
        private int _maxAge;

        public Fish(string name, int age, ConsoleColor color)
        {
            _name = name;
            _color = color;
            RemainingAge = age;
            _maxAge = age;
        }

        public void GrowUp()
        {
            RemainingAge--;
        }

        public void Show()
        {
            string life = "";

            for (int i = 0; i < _maxAge; i++)
            {
                if (i < RemainingAge)
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
        private ConsoleColor[] _colors;

        public Aquarium(int maxFishCount = 7, int minFishAge = 3, int maxFishAge = 10)
        {
            if (Math.Abs(minFishAge) < Math.Abs(maxFishAge))
            {
                _minFishAge = Math.Abs(minFishAge);
                _maxFishAge = Math.Abs(maxFishAge);
            }
            else
            {
                _minFishAge = Math.Abs(maxFishAge);
                _maxFishAge = Math.Abs(minFishAge);
            }

            _maxFishCount = Math.Abs(maxFishCount);
            _random = new Random();
            _fishes = new List<Fish>();
            _colors = new ConsoleColor[] {
                ConsoleColor.White,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Cyan,
                ConsoleColor.Magenta
            };
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
                        PickUpRandomFish();
                        break;

                    case ExitCommand:
                        isUse = false;
                        break;

                    default:
                        SkipTime();
                        break;
                }

                if (isUse)
                {
                    _fishes.RemoveAll(fish => fish.RemainingAge <= 0);
                    Console.ReadKey();
                    Console.Clear();
                    ShowFishes();
                }
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
                ConsoleColor color = GetFishColor();
                _fishes.Add(new Fish(name, age, color));
                Console.WriteLine("\nРыба добавлена");
            }
        }

        private void PickUpRandomFish()
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

        private void SkipTime()
        {
            foreach (Fish fish in _fishes)
            {
                fish.GrowUp();
            }
        }

        private ConsoleColor GetFishColor()
        {
            int index = _random.Next(_colors.Length);
            return _colors[index];
        }
    }
}