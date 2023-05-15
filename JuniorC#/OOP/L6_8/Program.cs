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

    abstract class Fighter
    {
        protected Random Accidental;
        protected Fighters FighterName;
        protected int HealthPoint;
        protected int MinDamage;
        protected int MaxDamage;
        protected int Armor;

        public Fighter(Fighters name, int health, int armor, int minDamage, int maxDamage)
        {
            Accidental = new Random();
            FighterName = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            HealthPoint = health;
            Armor = armor;
            IsFreezed = false;
        }

        public Fighters Name => FighterName;
        public int Health => HealthPoint;
        public bool IsFreezed { get; set; }

        public virtual int TakeDamage(int damage)
        {
            int clearDamage = 0;

            if (damage >= Armor)
            {
                clearDamage = damage - Armor;
            }

            HealthPoint -= clearDamage;

            return clearDamage;
        }

        public virtual int Hit()
        {
            int damage = 0;

            if (IsFreezed == false)
            {
                damage = Accidental.Next(MinDamage, MaxDamage);
            }

            return damage;
        }

        public override string ToString()
        {
            return $"{FighterName}. Урон: {MinDamage} - {MaxDamage}, Броня: {Armor}, Жизни: {HealthPoint}";
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

        public string Lifesteal(int clearDamage)
        {
            int lifestealPoint = clearDamage * _lifesteal / _maxPercent;
            HealthPoint += lifestealPoint;

            if (HealthPoint > _maxHealth)
            {
                HealthPoint = _maxHealth;
            }

            return $"{FighterName} отхилился на {lifestealPoint}";
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
            if (Accidental.Next(_maxDamageChance) <= _currentDoubleDamageChance)
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

        public override int TakeDamage(int damage)
        {
            int clearDamage = 0;

            if (Accidental.Next(_maxDodgeChance) > _currentDodgeChance || IsFreezed)
            {
                clearDamage = base.TakeDamage(damage);
                _currentDodgeChance += (_maxHealth - HealthPoint) * _dodgeScale / _maxPercent;
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

            if (_isFireRage && IsFreezed != true)
            {
                damage = MaxDamage;
            }
            else
            {
                damage = base.Hit();
            }

            if (_isFireRage == false && Accidental.Next(_maxChance) <= _fireRageChance)
            {
                _isFireRage = true;
                Console.WriteLine($"{FighterName} вошёл в ярость");
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

        public bool Freeze(bool isFreezed)
        {
            if (!isFreezed && Accidental.Next(_maxChance) <= _freezeChance)
            {
                return true;
                Console.WriteLine("Противник заморожен");
            }
            else
            {
                return false;
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
        private string _secondCorner;
        private string _firstCorner;
        private int _firstFighter;
        private int _secondFighter;

        public Game()
        {
            _fighters = new List<Fighter>();
            _playersCount = 2;
            _secondCorner = "Blue";
            _firstCorner = "Red";
            _firstFighter = 0;
            _secondFighter = 1;
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

        private bool CheckLoss(string defenderCorner, Fighter defender, string attakerCorner, Fighter attaker)
        {
            int damage = attaker.Hit();
            int clearDamage = defender.TakeDamage(damage);
            Console.WriteLine($"{defenderCorner} {defender.Name} получил {clearDamage} урона. Осталось {defender.Health} жизней");
            bool isLoss = defender.Health <= 0;

            switch (attaker.Name)
            {
                case Fighters.Baraka:
                    Console.WriteLine($"{attakerCorner} {(attaker as Baraka).Lifesteal(clearDamage)}");
                    break;

                case Fighters.Jax:
                    (attaker as Jax).IncreaseDoubleDamageChance(clearDamage);
                    break;

                case Fighters.Subzero:
                    defender.IsFreezed = (attaker as Subzero).Freeze(defender.IsFreezed);
                    break;

                default:
                    break;
            }

            if (isLoss)
            {
                Console.WriteLine($"\n{attakerCorner} {attaker.Name} победил!");
            }

            return isLoss;
        }

        private void RoundFight()
        {
            bool isLoss = false;

            while (isLoss == false)
            {
                Console.WriteLine();

                for (int i = 0; i < _playersCount && isLoss == false; i++)
                {
                    if (i == _firstFighter)
                    {
                        isLoss = CheckLoss(_secondCorner, _fighters[_secondFighter], _firstCorner, _fighters[i]);
                    }
                    else if (i == _secondFighter)
                    {
                        isLoss = CheckLoss(_firstCorner, _fighters[_firstFighter], _secondCorner, _fighters[i]);
                    }
                }
            }
        }

        public void Start()
        {
            bool isDone = false;
            int firstFighter = 0;

            for (int i = 0; i < _playersCount; i++)
            {
                Console.WriteLine($"Выберите героя {(i == _firstFighter ? _firstCorner : _secondCorner)}:");

                while (isDone == false)
                {
                    isDone = ChoiceHero();
                }

                isDone = false;
                Console.WriteLine();
            }

            for (int i = 0; i < _playersCount; i++)
            {
                Console.WriteLine($"{(i == _firstFighter ? _firstCorner : _secondCorner)} {_fighters[i].ToString()}");
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