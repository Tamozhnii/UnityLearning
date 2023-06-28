using System;

namespace L6_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Autoservice autoservice = new Autoservice(5, 500);
            autoservice.Work();
        }

        class Autoservice
        {
            private int _startBalance;
            private int _balance;
            private int _fine;
            private int _serviceQuantityStandard;
            private Warehouse _warehouse;
            private Dictionary<WorkTypes, int> _typesOfWork;

            public Autoservice(int serviceQuantityStandard, int fine)
            {
                _serviceQuantityStandard = serviceQuantityStandard;
                _fine = fine;
                _startBalance = serviceQuantityStandard * fine;
                _balance = _startBalance;
                _warehouse = new Warehouse();
                _typesOfWork = new Dictionary<WorkTypes, int>()
                {
                    { WorkTypes.Diagnostics, 500 },
                    { WorkTypes.BrakeReplacement, 200 },
                    { WorkTypes.OilChange, 400 },
                    { WorkTypes.StarterReplacement, 3000 },
                    { WorkTypes.PaintingPart, 5000 },
                    { WorkTypes.BumperReplacement, 2000 },
                    { WorkTypes.ReplacingStrutsAndShockAbsorbers, 5000 },
                };
            }

            public void Work()
            {
                const string DenyServiceCommand = "n";

                for (int i = 0; i < _serviceQuantityStandard; i++)
                {
                    Car client = new Car();
                    WorkTypes diagnosis = Diagnostic(client.Breakdown);
                    int serviceCost = DeterminingWorkCost(diagnosis);
                    Console.WriteLine($"У машины следующая поломка - {client.Breakdown}, требуется - {diagnosis}, стоимость ремонта - {serviceCost}");
                    Console.WriteLine($"Починить машину ({DenyServiceCommand} если отказать):");
                    string userCommand = Console.ReadLine();
                    Nomenclatures needsDetail = IdentifyDetail(diagnosis);

                    switch (userCommand)
                    {
                        case DenyServiceCommand:
                            PayFine();
                            break;

                        default:
                            MakeRepairs(needsDetail, serviceCost);
                            break;
                    }

                    Console.WriteLine($"Баланс составляет {_balance}");
                    int profit = _balance - _startBalance;

                    if (_balance < _startBalance)
                    {
                        Console.WriteLine($"Убыток составляет {profit}");
                    }
                    else if (_balance == _startBalance)
                    {
                        Console.WriteLine("Вы ничего не заработали");
                    }
                    else
                    {
                        Console.WriteLine($"Прибыль составляет {profit}");
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                Console.WriteLine($"Рабочий день завершен, вы обслужили {_serviceQuantityStandard} машин");
            }

            private void PayFine()
            {
                _balance -= _fine;
                Console.WriteLine($"За отказ вы заплатили штраф клиенту в размере {_fine}, оставшийся баланс {_balance}");
            }

            private void MakeRepairs(Nomenclatures needsDetail, int serviceCost)
            {
                Console.WriteLine("Выберите деталь:");
                Type type = typeof(Nomenclatures);
                Array details = type.GetEnumValues();
                int offset = 1;
                int detailIndex = 0;
                bool isValidIndex = false;

                for (int i = 0; i < details.Length; i++)
                {
                    Console.WriteLine($"{i + offset} - {(Nomenclatures)details.GetValue(i)}");
                }

                while (isValidIndex == false)
                {
                    string detailNumber = Console.ReadLine();
                    isValidIndex = Int32.TryParse(detailNumber, out detailIndex);
                    isValidIndex = detailIndex > 0 && detailIndex <= details.Length;

                    if (isValidIndex == false)
                    {
                        Console.WriteLine("Нет такой детали, пропробуйте снова:");
                    }
                }

                Detail selectedDetail = _warehouse.GetDetail((Nomenclatures)details.GetValue(detailIndex - offset));

                if (selectedDetail == null)
                {
                    _balance -= _fine;
                    Console.WriteLine($"Деталь отсутствует на складе вам пришлось отказать клиенту, вы заплатили штраф в размере {_fine}");
                }
                else if (selectedDetail.Name == needsDetail)
                {
                    _balance += serviceCost;
                    Console.WriteLine($"Вы успешно отремонтировали машину и заработали {serviceCost}");
                }
                else
                {
                    _balance -= serviceCost;
                    Console.WriteLine($"Неверно выбранная деталь для ремонта, вы возместили ущерб в размере {serviceCost}");
                }
            }

            private WorkTypes Diagnostic(PotentialProblems problem)
            {
                switch (problem)
                {
                    case PotentialProblems.BadEngineWork:
                        return WorkTypes.OilChange;

                    case PotentialProblems.BrakesSqueak:
                        return WorkTypes.BrakeReplacement;

                    case PotentialProblems.CrashedBumper:
                        return WorkTypes.BumperReplacement;

                    case PotentialProblems.NotStart:
                        return WorkTypes.StarterReplacement;

                    case PotentialProblems.ScratchedBody:
                        return WorkTypes.PaintingPart;

                    case PotentialProblems.SuspensionKnocks:
                        return WorkTypes.ReplacingStrutsAndShockAbsorbers;

                    default:
                        return WorkTypes.Diagnostics;
                }
            }

            private int DeterminingWorkCost(WorkTypes work)
            {
                int detailCost = 0;
                int workCost = _typesOfWork[work];

                switch (work)
                {
                    case WorkTypes.OilChange:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.Oil);
                        break;

                    case WorkTypes.BrakeReplacement:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.BrakePads);
                        break;

                    case WorkTypes.BumperReplacement:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.Bumper);
                        break;

                    case WorkTypes.PaintingPart:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.Paint);
                        break;

                    case WorkTypes.ReplacingStrutsAndShockAbsorbers:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.StrutsAndShockAbsorbers);
                        break;

                    case WorkTypes.StarterReplacement:
                        detailCost = _warehouse.GetDetailPrice(Nomenclatures.Starter);
                        break;
                }

                return detailCost + workCost;
            }

            private Nomenclatures IdentifyDetail(WorkTypes diagnosis)
            {
                switch (diagnosis)
                {
                    case WorkTypes.OilChange:
                        return Nomenclatures.Oil;

                    case WorkTypes.BrakeReplacement:
                        return Nomenclatures.BrakePads;

                    case WorkTypes.BumperReplacement:
                        return Nomenclatures.Bumper;

                    case WorkTypes.PaintingPart:
                        return Nomenclatures.Paint;

                    case WorkTypes.ReplacingStrutsAndShockAbsorbers:
                        return Nomenclatures.StrutsAndShockAbsorbers;

                    case WorkTypes.StarterReplacement:
                        return Nomenclatures.Starter;

                    default:
                        return Nomenclatures.Oil;
                }
            }
        }

        class Warehouse
        {
            private List<Detail> _details;
            private Dictionary<Nomenclatures, int> _nomenclature;

            public Warehouse()
            {
                _details = new List<Detail>();
                _nomenclature = new Dictionary<Nomenclatures, int>()
                {
                    { Nomenclatures.Paint, 2000 },
                    { Nomenclatures.Bumper, 8000 },
                    { Nomenclatures.Oil, 3000 },
                    { Nomenclatures.Starter, 10000 },
                    { Nomenclatures.BrakePads, 400 },
                    { Nomenclatures.StrutsAndShockAbsorbers, 4000 },
                };

                ReceiptSupplies();
            }

            public int GetDetailPrice(Nomenclatures detailName)
            {
                return _nomenclature[detailName];
            }

            public Detail GetDetail(Nomenclatures detailName)
            {
                Detail detail = _details.Find(d => d.Name == detailName);

                if (detail != null)
                {
                    _details.Remove(detail);
                }

                return detail;
            }

            private void ReceiptSupplies()
            {
                Random random = new Random();
                int minDetailsCount = 1;
                int maxDetailsCount = 3;

                foreach (var item in _nomenclature)
                {
                    int count = random.Next(minDetailsCount, maxDetailsCount);

                    for (int i = 0; i < count; i++)
                    {
                        Detail detail = new Detail(item.Key, item.Value);
                        _details.Add(detail);
                    }
                }
            }
        }

        class Detail
        {
            public Detail(Nomenclatures name, int price)
            {
                Name = name;
                Price = price;
            }

            public Nomenclatures Name { get; private set; }
            public int Price { get; private set; }
        }

        class Car
        {
            public Car()
            {
                Random random = new Random();
                Type type = typeof(PotentialProblems);
                Array problems = type.GetEnumValues();
                int index = random.Next(problems.Length);
                PotentialProblems problem = (PotentialProblems)problems.GetValue(index);
                Breakdown = problem;
            }

            public PotentialProblems Breakdown { get; private set; }
        }

        enum PotentialProblems
        {
            BrakesSqueak,
            BadEngineWork,
            NotStart,
            ScratchedBody,
            CrashedBumper,
            SuspensionKnocks,
        };

        enum Nomenclatures
        {
            Paint,
            Bumper,
            Oil,
            Starter,
            BrakePads,
            StrutsAndShockAbsorbers,
        };

        enum WorkTypes
        {
            Diagnostics,
            BrakeReplacement,
            OilChange,
            StarterReplacement,
            PaintingPart,
            BumperReplacement,
            ReplacingStrutsAndShockAbsorbers,
        }
    }
}