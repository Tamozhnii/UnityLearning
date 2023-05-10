using System;

namespace L6_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Fighter
    {
        protected Random _random;
        protected Fighters _name;
        protected int _health;
        protected int _minDamage;
        protected int _maxDamage;
        protected int _armor;
        protected bool _isFreezed;

        public Fighter(Fighters name, int health, int armor, int minDamage, int maxDamage)
        {
            _random = new Random();
            _name = name;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            _health = health;
            _armor = armor;
            _isFreezed = false;
        }

        public Fighters Name => _name;
        public int Health => _health;

        public virtual int TakeDamage(Fighter enemy)
        {
            int clearDamage = 0;

            if (enemy != null)
            {
                int damage = enemy.Hit();

                if (damage >= _armor)
                {
                    clearDamage = damage - _armor;
                }

                _health -= clearDamage;

                switch (enemy.Name)
                {
                    case Fighters.Baraka:
                        (enemy as Baraka).Lifesteal(clearDamage);
                        break;

                    case Fighters.Jax:
                        (enemy as Jax).IncreaseDoubleDamageChance(clearDamage);
                        break;

                    case Fighters.Subzero:
                        (enemy as Subzero).Freeze(ref _isFreezed);
                        break;

                    default:
                        break;
                }
            }

            return clearDamage;
        }

        public virtual int Hit()
        {
            int damage = 0;

            if (_isFreezed == false)
            {
                damage = _random.Next(_minDamage, _maxDamage);
            }

            return damage;
        }

        public override string ToString()
        {
            return $"{_name}. Урон: {_minDamage} - {_maxDamage}, Броня: {_armor}, Жизни: {_health}";
        }
    }

    class Baraka : Fighter
    {
        private int _lifesteal;
        private int _maxHealth;
        private int _maxPercent;

        public Baraka() : base(Fighters.Baraka, 100, 1, 10, 20)
        {
            _lifesteal = 20;
            _maxHealth = 100;
            _maxPercent = 100;
        }

        public void Lifesteal(int clearDamage)
        {
            int lifestealPoint = clearDamage * _lifesteal / _maxPercent;
            _health += lifestealPoint;
            Console.WriteLine($"{_name} отхилился на {lifestealPoint}");

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Способность - восстановление жизней на {_lifesteal} от нанесенного чистого урона";
        }
    }

    class Jax : Fighter
    {
        private int _baseDoubleDamageChance;
        private int _maxDamageChance;
        private int _scaleDoubleDamageChance;
        private int _currentDoubleDamageChance;
        private int _damageScale;

        public Jax() : base(Fighters.Jax, 100, 3, 13, 15)
        {
            _baseDoubleDamageChance = 5;
            _scaleDoubleDamageChance = 2;
            _currentDoubleDamageChance = _baseDoubleDamageChance;
            _damageScale = 2;
            _maxDamageChance = 100;
        }

        public void IncreaseDoubleDamageChance(int clearDamage)
        {
            if (clearDamage > 0)
            {
                _currentDoubleDamageChance += _scaleDoubleDamageChance;
            }
        }

        public override int Hit()
        {
            if (_random.Next(_maxDamageChance) <= _currentDoubleDamageChance)
            {
                _currentDoubleDamageChance = _baseDoubleDamageChance;
                Console.WriteLine("Двойной урон");
                return base.Hit() * _damageScale;
            }
            else
            {
                return base.Hit();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Способность - шанс двойного удара {_baseDoubleDamageChance}% + {_scaleDoubleDamageChance}% за каждый обычный удар (при двойном ударе, шанс сбрасывается до базового)";
        }
    }

    class Kabal : Fighter
    {
        private int _dodgeScale;
        private int _maxPercent;
        private int _maxDodgeChance;
        private int _maxHealth;
        private int _currentDodgeChance;

        public Kabal() : base(Fighters.Kabal, 100, 3, 10, 15)
        {
            _currentDodgeChance = 10;
            _dodgeScale = 5;
            _maxDodgeChance = 100;
            _maxHealth = 100;
            _maxPercent = 100;
        }

        public override int TakeDamage(Fighter enemy)
        {
            int clearDamage = 0;

            if (_random.Next(_maxDodgeChance) > _currentDodgeChance || _isFreezed)
            {
                clearDamage = base.TakeDamage(enemy);
                _currentDodgeChance += (_maxHealth - _health) * _dodgeScale / _maxPercent;
            }
            else
            {
                Console.WriteLine("Уворот!");
            }

            return clearDamage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Способность - шанс уворота {_currentDodgeChance}% + {_dodgeScale} от недостающего здоровья";
        }
    }

    class Scorpion : Fighter
    {
        private int _fireRageChance;
        private int _maxChance;
        private bool _isFireRage;

        public Scorpion() : base(Fighters.Scorpion, 100, 3, 10, 17)
        {
            _fireRageChance = 25;
            _maxChance = 100;
            _isFireRage = false;
        }

        public override int Hit()
        {
            int damage = 0;

            if (_isFireRage && _isFreezed != true)
            {
                damage = _maxDamage;
            }
            else
            {
                damage = base.Hit();
            }

            if (_isFireRage == false && _random.Next(_maxChance) <= _fireRageChance)
            {
                _isFireRage = true;
                Console.WriteLine($"{_name} вошёл в ярость");
            }

            return damage;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Способность - Ярость, {_fireRageChance}% шанс войти в безумие при котором наносит всегда максимальный урон";
        }
    }

    class Subzero : Fighter
    {
        private int _freezeChance;
        private int _maxChance;

        public Subzero() : base(Fighters.Subzero, 100, 4, 12, 15)
        {
            _freezeChance = 20;
            _maxChance = 100;
        }

        public void Freeze(ref bool isFreezed)
        {
            if (isFreezed)
            {
                isFreezed = false;
            }
            else if (_random.Next(_maxChance) <= _freezeChance)
            {
                isFreezed = true;
                Console.WriteLine("Противник заморожен");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Способность - Шанс {_freezeChance}% заморозить при ударе, замороженный противник не может нанести урон и избежать следующего удара, действует 1 ход";
        }
    }

    class Game
    {
        private List<Fighter> _fighters;
        private int _playersCount;

        public Game()
        {
            _fighters = new List<Fighter>();
            _playersCount = 2;
        }

        private bool ChoiceHero()
        {
            const int CommandGetBaraka = (int)Fighters.Baraka;
            const int CommandGetJax = (int)Fighters.Jax;
            const int CommandGetKabal = (int)Fighters.Kabal;
            const int CommandGetScorpion = (int)Fighters.Scorpion;
            const int CommandGetSubzero = (int)Fighters.Subzero;

            Console.WriteLine($"{CommandGetBaraka} - {Fighters.Baraka}");
            Console.WriteLine($"{CommandGetJax} - {Fighters.Jax}");
            Console.WriteLine($"{CommandGetKabal} - {Fighters.Kabal}");
            Console.WriteLine($"{CommandGetScorpion} - {Fighters.Scorpion}");
            Console.WriteLine($"{CommandGetSubzero} - {Fighters.Subzero}");
            int command = 0;
            string userInput = Console.ReadLine();
            bool isValid = int.TryParse(userInput, out command);

            if (isValid)
            {
                switch (command)
                {
                    case CommandGetBaraka:
                        _fighters.Add(new Baraka());
                        return isValid;

                    case CommandGetJax:
                        _fighters.Add(new Jax());
                        return isValid;

                    case CommandGetKabal:
                        _fighters.Add(new Kabal());
                        return isValid;

                    case CommandGetScorpion:
                        _fighters.Add(new Scorpion());
                        return isValid;

                    case CommandGetSubzero:
                        _fighters.Add(new Subzero());
                        return isValid;

                    default:
                        Console.WriteLine("Такого персонажа не существует");
                        return !isValid;
                }
            }
            else
            {
                Console.WriteLine("Неверная команда");
                return isValid;
            }
        }

        private bool CheckLoss(Fighter defender, Fighter attaker)
        {
            int clearDamage = defender.TakeDamage(attaker);
            Console.WriteLine($"{defender.Name} получил {clearDamage} урона. Осталось {defender.Health} жизней");
            bool isLoss = defender.Health <= 0;

            if (isLoss)
            {
                Console.WriteLine($"\n{attaker.Name} победил!");
            }

            return isLoss;
        }

        private void RoundFight()
        {
            bool isLoss = false;
            int firstFighter = 0;
            int secondFighter = 1;

            while (isLoss == false)
            {
                Console.WriteLine();

                for (int i = 0; i < _playersCount && isLoss == false; i++)
                {
                    if (i == firstFighter)
                    {
                        isLoss = CheckLoss(_fighters[secondFighter], _fighters[i]);
                    }
                    else if (i == secondFighter)
                    {
                        isLoss = CheckLoss(_fighters[firstFighter], _fighters[i]);
                    }
                }
            }
        }

        public void Start()
        {
            bool isDone = false;

            for (int i = 0; i < _playersCount; i++)
            {
                Console.WriteLine($"Выберите героя {i + 1}:");

                while (isDone == false)
                {
                    isDone = ChoiceHero();
                }

                isDone = false;
                Console.WriteLine();
            }

            foreach (Fighter fighter in _fighters)
            {
                Console.WriteLine(fighter.ToString());
            }

            RoundFight();
        }
    }

    enum Fighters
    {
        Baraka = 1,
        Jax,
        Kabal,
        Scorpion,
        Subzero,
    }
}