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
            string departurePoint = Console.ReadLine();
            Console.WriteLine("Куда:");
            string arrivalPoint = Console.ReadLine();
            TrainDirection trainDirection = new TrainDirection(departurePoint, arrivalPoint);
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
        private string _departurePoint;
        private string _arrivalPoint;
        private Train _train;
        private int _tickets;

        public TrainDirection(string departurePoint, string arrivalPoint)
        {
            _departurePoint = departurePoint;
            _arrivalPoint = arrivalPoint;
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
            return $"Направление {_departurePoint} - {_arrivalPoint}, поезд в составе из {_train.WagonCount} вагонов отправлен";
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

            int vipCapacity = 10;
            int premiumCapacity = 30;
            int economCapacity = 60;
            Console.WriteLine($"{WagonTypeVip} - добавить VIP вагон на {vipCapacity} человек");
            Console.WriteLine($"{WagonTypePremium} - добавить вагон премиум класса на {premiumCapacity} человек");
            Console.WriteLine($"{WagonTypeEconom} - добавить вагон эконом класса на {economCapacity} человек (этот вагон будет добавлен по умолчанию)");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case WagonTypeVip:
                    _type = WagonTypeVip;
                    _capacity = vipCapacity;
                    break;

                case WagonTypePremium:
                    _type = WagonTypePremium;
                    _capacity = premiumCapacity;
                    break;

                case WagonTypeEconom:
                    _type = WagonTypeEconom;
                    _capacity = economCapacity;
                    break;

                default:
                    _type = WagonTypeEconom;
                    _capacity = economCapacity;
                    break;
            }
        }
    }
}
