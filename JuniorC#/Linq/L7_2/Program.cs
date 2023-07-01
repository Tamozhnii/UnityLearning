using System;

namespace L7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Crimes crimeForAmnesty = Crimes.AntiGovernment;
            Prison prison = new Prison();
            Console.WriteLine("До амнистии");
            prison.ShowList();
            Console.WriteLine($"\nПосле амнистии за преступление {crimeForAmnesty}");
            prison.Amnesty(crimeForAmnesty);
            prison.ShowList();
        }
    }

    class Prison
    {
        private List<Criminal> _criminals;

        public Prison()
        {
            _criminals = new List<Criminal>();
            Initialized();
        }

        public void Amnesty(Crimes crime)
        {
            _criminals = _criminals.FindAll(criminal => criminal.Crime != crime);
        }

        public void ShowList()
        {
            foreach (Criminal criminal in _criminals)
            {
                Console.WriteLine(criminal.ToString());
            }
        }

        private void Initialized()
        {
            _criminals.Add(new Criminal("Oliver", Crimes.AntiGovernment));
            _criminals.Add(new Criminal("Jack", Crimes.Fraud));
            _criminals.Add(new Criminal("Harry", Crimes.Murder));
            _criminals.Add(new Criminal("Jacob", Crimes.Theft));
            _criminals.Add(new Criminal("Charley", Crimes.AntiGovernment));
            _criminals.Add(new Criminal("Thomas", Crimes.Fraud));
            _criminals.Add(new Criminal("George", Crimes.Murder));
            _criminals.Add(new Criminal("Oscar", Crimes.Theft));
            _criminals.Add(new Criminal("James", Crimes.AntiGovernment));
            _criminals.Add(new Criminal("William", Crimes.AntiGovernment));
        }
    }

    class Criminal
    {
        private string _name;

        public Criminal(string name, Crimes crime)
        {
            _name = name;
            Crime = crime;
        }

        public Crimes Crime { get; private set; }

        public override string ToString()
        {
            return $"{_name} - {Crime}";
        }
    }

    enum Crimes
    {
        AntiGovernment,
        Murder,
        Theft,
        Fraud
    }
}