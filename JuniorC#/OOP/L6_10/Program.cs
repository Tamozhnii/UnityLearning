using System;
using System.Threading.Tasks;

namespace L6_10
{
    class Program
    {
        static void Main(string[] args)
        {
            War battlefield = new War();
            battlefield.StartBattle();
        }
    }

    class Warrior
    {
        public Warrior(Sides side)
        {
            Random random = new Random();
            int minDamage = 1;
            int maxDamage = 5;
            Damage = random.Next(minDamage, maxDamage);
            Health = 10;
            Cell = null;
            Side = side;
        }

        public int Damage { get; private set; }
        public int Health { get; private set; }
        public Cell Cell { get; private set; }
        public Sides Side { get; private set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void SetCell(Cell cell)
        {
            if (Cell != null)
            {
                Cell.Clear();
            }

            Cell = cell;
        }
    }

    class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Warrior = null;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Warrior Warrior { get; private set; }

        public void SetWarrior(Warrior warrior)
        {
            if (Warrior == null)
            {
                Warrior = warrior;
            }
            else
            {
                Console.WriteLine("Поле недоступно");
            }
        }

        public void Clear()
        {
            Warrior = null;
        }
    }

    class War
    {
        private int _width;
        private int _height;

        private List<Warrior> _whiteArmy;
        private List<Warrior> _blackArmy;
        private List<Cell> _field;

        public War()
        {
            _width = 6;
            _height = 10;
            _whiteArmy = new List<Warrior>();
            _blackArmy = new List<Warrior>();
            _field = new List<Cell>();
            Initialize();
        }

        public async void StartBattle()
        {
            ShowBattle();

            foreach (Warrior warrior in _whiteArmy)
            {
                MakeStep(warrior);
                await Task.Delay(5);
                ShowBattle();
            }

            foreach (Warrior warrior in _blackArmy)
            {
                MakeStep(warrior);
                await Task.Delay(5);
                ShowBattle();
            }
        }

        private void ShowBattle()
        {
            Console.Clear();

            foreach (Cell cell in _field)
            {
                char symbol = cell.Warrior != null ? Convert.ToChar(cell.Warrior.Side) : ' ';
                Console.SetCursorPosition(cell.Y, cell.X);
                Console.Write(symbol);
            }
        }

        private void MakeStep(Warrior warrior)
        {
            Warrior targetEnemy = FindTarget(warrior);

            if (targetEnemy != null)
            {
                Attak(warrior, targetEnemy);
            }
            else
            {
                MakeMove(warrior);
            }
        }

        private Warrior? FindTarget(Warrior warrior)
        {
            int offset = 1;
            int x = warrior.Cell.X;
            int y = warrior.Cell.Y;

            foreach (Cell cell in _field)
            {
                bool withinX = cell.X <= x + offset && cell.X >= x - offset;
                bool withinY = cell.Y <= y + offset && cell.Y >= y - offset;
                bool isEnemy = cell.Warrior != null && cell.Warrior.Side != warrior.Side;

                if (withinX && withinY && isEnemy)
                {
                    return cell.Warrior;
                }
            }

            return null;
        }

        private void Attak(Warrior warrior, Warrior enemy)
        {
            enemy.TakeDamage(warrior.Damage);

            if (enemy.Health <= 0)
            {
                enemy.Cell.Clear();

                if (enemy.Side == Sides.Black)
                {
                    _blackArmy.Remove(enemy);
                }
                else if (enemy.Side == Sides.White)
                {
                    _whiteArmy.Remove(enemy);
                }
            }
        }

        private void MakeMove(Warrior warrior)
        {
            List<Warrior> enemies = warrior.Side == Sides.Black ? _whiteArmy : _blackArmy;
            int[,] battlefield = DrawBattlefield(warrior);
            WaveSpread(ref battlefield);
            Warrior enemy = FindClosestEnemy(battlefield, enemies);
            int[] nextStep = FindNextStep(battlefield, enemy);
            int x = nextStep[0];
            int y = nextStep[1];
            Cell cell = _field.Find(cell => cell.X == x && cell.Y == y);

            if (cell != null)
            {
                warrior.SetCell(cell);
                cell.SetWarrior(warrior);
            }
        }

        private int[] FindNextStep(int[,] battlefield, Warrior targetEnemy)
        {
            int minLimit = 0;
            int endRange = 0;
            int offset = 1;
            int[] currentPosition = { targetEnemy.Cell.X, targetEnemy.Cell.Y };
            int rangePosition = battlefield[currentPosition[0], currentPosition[1]];

            while (rangePosition != endRange)
            {
                if (currentPosition[0] + offset < _width && battlefield[currentPosition[0] + offset, currentPosition[1]] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] + offset;
                    rangePosition--;
                }
                else if (currentPosition[0] + offset < _width && currentPosition[1] + offset < _height && battlefield[currentPosition[0] + offset, currentPosition[1] + offset] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] + offset;
                    currentPosition[1] = currentPosition[1] + offset;
                    rangePosition--;
                }
                else if (currentPosition[1] + offset < _height && battlefield[currentPosition[0], currentPosition[1] + offset] == rangePosition - offset)
                {
                    currentPosition[1] = currentPosition[1] + offset;
                    rangePosition--;
                }
                else if (currentPosition[0] - offset >= minLimit && currentPosition[1] + offset < _height && battlefield[currentPosition[0] - offset, currentPosition[1] + offset] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] - offset;
                    currentPosition[1] = currentPosition[1] + offset;
                    rangePosition--;
                }
                else if (currentPosition[0] - offset >= minLimit && battlefield[currentPosition[0] - offset, currentPosition[1]] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] - offset;
                    rangePosition--;
                }
                else if (currentPosition[0] - offset >= minLimit && currentPosition[1] - offset >= minLimit && battlefield[currentPosition[0] - offset, currentPosition[1] - offset] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] - offset;
                    currentPosition[1] = currentPosition[1] - offset;
                    rangePosition--;
                }
                else if (currentPosition[1] - offset >= minLimit && battlefield[currentPosition[0], currentPosition[1] - offset] == rangePosition - offset)
                {
                    currentPosition[1] = currentPosition[1] - offset;
                    rangePosition--;
                }
                else if (currentPosition[0] + offset < _width && currentPosition[1] - offset >= minLimit && battlefield[currentPosition[0] + offset, currentPosition[1] - offset] == rangePosition - offset)
                {
                    currentPosition[0] = currentPosition[0] + offset;
                    currentPosition[1] = currentPosition[1] - offset;
                    rangePosition--;
                }
            }

            return currentPosition;
        }

        private Warrior FindClosestEnemy(int[,] battlefield, List<Warrior> enemies)
        {
            Warrior closestEnemy = null;
            int minRange = (_height * _width) + 1;

            foreach (Warrior enemy in enemies)
            {
                int x = enemy.Cell.X;
                int y = enemy.Cell.Y;
                int currentRange = battlefield[x, y];

                if (currentRange < minRange)
                {
                    minRange = currentRange;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        private void WaveSpread(ref int[,] battlefield)
        {
            bool isSearch = true;
            int empty = -1;
            int step = 0;
            int offset = 1;
            int minLimit = 0;

            while (isSearch)
            {
                isSearch = false;

                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        if (battlefield[x, y] == step)
                        {
                            isSearch = true;

                            if (x + offset < _width && battlefield[x + offset, y] == empty)
                            {
                                battlefield[x + offset, y] = step + offset;
                            }
                            else if (x + offset < _width && y + offset < _height && battlefield[x + offset, y + offset] == empty)
                            {
                                battlefield[x + offset, y + offset] = step + offset;
                            }
                            else if (y + offset < _height && battlefield[x, y + offset] == empty)
                            {
                                battlefield[x, y + offset] = step + offset;
                            }
                            else if (x - offset >= minLimit && y + offset < _height && battlefield[x - offset, y + offset] == empty)
                            {
                                battlefield[x - offset, y + offset] = step + offset;
                            }
                            else if (x - offset >= minLimit && battlefield[x - offset, y] == empty)
                            {
                                battlefield[x - offset, y] = step + offset;
                            }
                            else if (x - offset >= minLimit && y - offset >= minLimit && battlefield[x - offset, y - offset] == empty)
                            {
                                battlefield[x - offset, y - offset] = step + offset;
                            }
                            else if (y - offset >= minLimit && battlefield[x, y - offset] == empty)
                            {
                                battlefield[x, y - offset] = step + offset;
                            }
                            else if (x + offset < _width && y - offset >= minLimit && battlefield[x + offset, y - offset] == empty)
                            {
                                battlefield[x + offset, y - offset] = step + offset;
                            }
                        }
                    }
                }

                step++;
            }
        }

        private int[,] DrawBattlefield(Warrior warrior)
        {
            int[,] battlefield = new int[_width, _height];
            int startPosition = 0;
            int empty = -1;
            int block = (_width * _height) + 1;

            foreach (Cell cell in _field)
            {
                if (cell.Warrior == null || cell.Warrior.Side != warrior.Side)
                {
                    battlefield[cell.X, cell.Y] = empty;
                }
                else
                {
                    battlefield[cell.X, cell.Y] = block;
                }
            }

            battlefield[warrior.Cell.X, warrior.Cell.Y] = startPosition;
            return battlefield;
        }

        private void SetCellWarrior(Warrior warrior, Cell cell)
        {
            if (warrior.Cell != null && warrior.Cell != cell)
            {
                warrior.Cell.Clear();
            }

            cell.SetWarrior(warrior);
            warrior.SetCell(cell);
        }

        private void Initialize()
        {
            int scalarNumber = 2;
            int armyStrength = _height * scalarNumber;
            int whiteLine = scalarNumber;
            int blackLine = _width - scalarNumber;

            for (int i = 0; i < armyStrength; i++)
            {
                _whiteArmy.Add(new Warrior(Sides.White));
                _blackArmy.Add(new Warrior(Sides.Black));
            }

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Cell cell = new Cell(x, y);

                    if (x < whiteLine)
                    {
                        int index = _height * x + y;
                        Warrior warrior = _whiteArmy[index];
                        SetCellWarrior(warrior, cell);
                    }
                    else if (x >= blackLine)
                    {
                        int index = _height * (x - blackLine) + y;
                        Warrior warrior = _blackArmy[index];
                        SetCellWarrior(warrior, cell);
                    }

                    _field.Add(cell);
                }
            }
        }
    }

    enum Sides
    {
        White = '†',
        Black = '$'
    }
}