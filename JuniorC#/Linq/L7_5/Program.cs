using System;

namespace L7_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.ShowAllStewedMeats();
            warehouse.ShowExpiredProducts();
        }
    }

    class Warehouse
    {
        private List<StewedMeat> _stewedMeats;

        public Warehouse()
        {
            _stewedMeats = new List<StewedMeat>();
            Initialize();
        }

        public void ShowAllStewedMeats()
        {
            foreach (StewedMeat product in _stewedMeats)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void ShowExpiredProducts()
        {
            int currentYear = Int32.Parse(DateTime.Now.ToString("yyyy"));
            IEnumerable<StewedMeat> expiredProducts = _stewedMeats.FindAll(product => (currentYear - product.YearOfProduction) > product.ShelfLife);
            Console.WriteLine("\nСписок просроченной продукции:");

            foreach (StewedMeat product in expiredProducts)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private void Initialize()
        {
            _stewedMeats.Add(new StewedMeat(Brands.Beef, 2019, 4));
            _stewedMeats.Add(new StewedMeat(Brands.Chicken, 2017, 6));
            _stewedMeats.Add(new StewedMeat(Brands.Lamb, 2018, 3));
            _stewedMeats.Add(new StewedMeat(Brands.Pork, 2019, 2));
            _stewedMeats.Add(new StewedMeat(Brands.Beef, 2015, 4));
            _stewedMeats.Add(new StewedMeat(Brands.Chicken, 2016, 5));
            _stewedMeats.Add(new StewedMeat(Brands.Lamb, 2017, 7));
            _stewedMeats.Add(new StewedMeat(Brands.Pork, 2020, 2));
            _stewedMeats.Add(new StewedMeat(Brands.Beef, 2020, 4));
            _stewedMeats.Add(new StewedMeat(Brands.Chicken, 2021, 2));
            _stewedMeats.Add(new StewedMeat(Brands.Lamb, 2019, 5));
            _stewedMeats.Add(new StewedMeat(Brands.Pork, 2017, 5));
        }
    }

    class StewedMeat
    {
        public StewedMeat(Brands name, int yearOfProduction, int shelfLife)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            ShelfLife = shelfLife;
        }

        public Brands Name { get; private set; }
        public int YearOfProduction { get; private set; }
        public int ShelfLife { get; private set; }

        public override string ToString()
        {
            return $"{Name}, дата изготовления - {YearOfProduction}, срок годности {ShelfLife}";
        }
    }

    enum Brands
    {
        Beef,
        Pork,
        Lamb,
        Chicken
    }
}