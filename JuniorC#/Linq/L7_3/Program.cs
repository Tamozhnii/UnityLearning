using System;

namespace L7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital()
        {
            _patients = new List<Patient>();
            Initialize();
        }

        public void Work()
        {
            const int ShowPatientsCommand = 1;
            const int SortByNameCommand = 2;
            const int SortByAgeCommand = 3;
            const int FindByDiseaseCommand = 4;
            const int ExitCommand = 5;

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{ShowPatientsCommand} - Показать список пациентов");
                Console.WriteLine($"{SortByNameCommand} - Отсортировать по имени");
                Console.WriteLine($"{SortByAgeCommand} - Остортировать по возрасту");
                Console.WriteLine($"{FindByDiseaseCommand} - Найти по заболеванию");
                Console.WriteLine($"{ExitCommand} - Выйти");
                Console.WriteLine("\nВведите команду:");
                string userCommand = Console.ReadLine();
                Int32.TryParse(userCommand, out int command);

                switch (command)
                {
                    case ShowPatientsCommand:
                        ShowPatients(_patients);
                        break;

                    case SortByNameCommand:
                        SortPatientsByName();
                        break;

                    case SortByAgeCommand:
                        SortPatientsByAge();
                        break;

                    case FindByDiseaseCommand:
                        FindByDisease();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
        }

        private void Initialize()
        {
            _patients.Add(new Patient("Пётр", 30, "Мигрень"));
            _patients.Add(new Patient("Марина", 21, "Перелом"));
            _patients.Add(new Patient("Семён", 18, "Ангина"));
            _patients.Add(new Patient("Василий", 27, "Простуда"));
            _patients.Add(new Patient("Дмитрий", 35, "Перелом"));
            _patients.Add(new Patient("Лариса", 40, "Мигрень"));
            _patients.Add(new Patient("Павел", 20, "Простуда"));
            _patients.Add(new Patient("Алла", 30, "Ангина"));
            _patients.Add(new Patient("Кристина", 27, "Простуда"));
            _patients.Add(new Patient("Владимир", 18, "Перелом"));
        }

        private void ShowPatients(IEnumerable<Patient> patients)
        {
            foreach (Patient p in patients)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }

        private void SortPatientsByName()
        {
            Console.Clear();
            var sortedPatients = from p in _patients
                                 orderby p.Name
                                 select p;
            ShowPatients(sortedPatients);
        }

        private void SortPatientsByAge()
        {
            Console.Clear();
            var sortedPatients = _patients.OrderBy(p => p.Age);
            ShowPatients(sortedPatients);
        }

        private void FindByDisease()
        {
            Console.Clear();
            Console.WriteLine("Заболевание:");
            string findingDiease = Console.ReadLine();

            if (findingDiease.Length > 0)
            {
                List<Patient> findPatients = _patients.FindAll(p => p.Disease.Contains(findingDiease));
                ShowPatients(findPatients);
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public override string ToString()
        {
            return $"{Name}, {Age} лет. {Disease}";
        }
    }
}