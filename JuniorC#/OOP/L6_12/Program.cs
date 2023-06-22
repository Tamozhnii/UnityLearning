using System;

namespace L6_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Inspect();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;

        public Zoo()
        {
            _aviaries = new List<Aviary>();
            Fill();
        }

        public void Inspect()
        {
            const string CommandExit = "exit";

            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Меню:");

                for (int i = 0; i < _aviaries.Count; i++)
                {
                    Console.WriteLine($"{i} - Подойти к вольеру {i + 1}");
                }

                Console.WriteLine($"{CommandExit} - Уйти");
                string userCommand = Console.ReadLine();

                switch (userCommand.ToLower())
                {
                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        ShowAviary(userCommand);
                        break;
                }
            }
        }

        private void Fill()
        {
            _aviaries.Add(new Aviary("Тигр", 10, "Ррррр (Грудной рык)"));
            _aviaries.Add(new Aviary("Обезьяна", 10, "У-у-у (Прерывисто издает звуки)"));
            _aviaries.Add(new Aviary("Змеи", 10, "Ссссссс (шипит)"));
            _aviaries.Add(new Aviary("Слон", 10, "(Трубит носом)"));
        }

        private void ShowAviary(string command)
        {
            bool isValidCommand = Int32.TryParse(command, out int id);

            if (isValidCommand && Math.Abs(id) < _aviaries.Count)
            {
                Aviary aviary = _aviaries[id];
                aviary.ShowInfo();
            }
            else
            {
                Console.WriteLine("Такого вольера не существует");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public Aviary(string animalName, int animalsCount, string animalVoice)
        {
            _animals = new List<Animal>();

            for (int i = 0; i < animalsCount; i++)
            {
                _animals.Add(new Animal(animalName, animalVoice));
            }
        }

        public void ShowInfo()
        {
            Animal firstAnimal = _animals[0];
            int countMales = _animals.Count(animal => animal.Sex == Gender.Male);
            int countFemales = _animals.Count - countMales;
            Console.WriteLine($"Вольер для животных. Название животного - {firstAnimal.Name}.");
            Console.WriteLine($"Количество животных - {_animals.Count}, из них {countMales} самец(-ов) и {countFemales} самка(-ок).");
            Console.WriteLine($"Животное издает звук - {firstAnimal.Voice}.");
        }
    }

    class Animal
    {
        public Animal(string name, string voice)
        {
            int maleChance = 49;
            int minChance = 1;
            int maxChance = 101;
            Random random = new Random();
            int chance = random.Next(minChance, maxChance);
            Name = name;
            Voice = voice;

            if (chance <= maleChance)
            {
                Sex = Gender.Male;
            }
            else
            {
                Sex = Gender.Female;
            }
        }

        public string Name { get; private set; }
        public Gender Sex { get; private set; }
        public string Voice { get; private set; }
    }

    enum Gender
    {
        Male,
        Female
    }
}