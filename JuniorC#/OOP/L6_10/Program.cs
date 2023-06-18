using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L6_10
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    class Warrior
    {
        private Sides _side;
        private int _health;
        private int _minDamage;
        private int _maxDamage;
        private int _blockChance;
        private int _maxChance;
        private Random _random;

        public Warrior(Sides side)
        {
            _side = side;
            _health = 10;
            _minDamage = 1;
            _maxDamage = 10;
            _blockChance = 20;
            _maxChance = 100;
            _random = new Random();
        }

        public int Health => _health;
        public int Side => _side;

        public int DoDamage()
        {
            return _random.Next(_minDamage, _maxDamage + _minDamage);
        }

        public void TakeDamage(int damage)
        {
            int chance = _random.Next(_maxChance);

            if (chance > _blockChance)
            {
                _health -= damage;
            }
        }
    }

    class Battlefield
    {
        private int _fieldX;
        private int _fieldY;
        private Warrior[,] _field;
        private Dictionary<Warrior, int[]> _warriors;

        public Battlefield()
        {
            _fieldX = 6;
            _fieldY = 10;
            _field = new Warrior[_fieldX, _fieldY];
            _warriors = new Dictionary<Warrior, int[]>();
            Initialized();
        }

        private void Initialized()
        {
            int countArmy = 2;
            int countWarriarsInArmy = 20;

            for (int i = 0; i < countArmy; i++)
            {
                Sides side = GetSide(i);

                for (int j = 0; j < countWarriarsInArmy; j++)
                {
                    Warrior warrior = new Warrior(side);
                    int x = (_fieldX - 1) * i + j / _fieldY;
                    int y = j % _fieldY;
                    _field[x, y] = warrior;
                    _warriors.Add(warrior, new int[] { x, y });
                }
            }
        }

        private Sides GetSide(int side)
        {
            const int white = 0;
            const int black = 1;

            switch (side)
            {
                case white:
                    return Sides.White;
                case black:
                    return Sides.Black;
                default:
                    return Sides.White;
            }
        }

        private int[] Move(Warrior warrior, int[] position)
        {
            int direction = warrior.Side == Sides.White ? 1 : -1;

        }

        private int[] FindEnemy(int[] position, int direction, Sides side)
        {
            int currentX = position[0];
            int currentY = position[1];
            Warrior enemy = null;

            while (enemy == null || enemy.Side == side)
            {
                int newX =
                enemy = _field[x, y];
            }
            for (int i = 1; i < _fieldX * _fieldY; i++)
            {

            }
        }
    }

    enum Sides
    {
        White,
        Black
    }
}