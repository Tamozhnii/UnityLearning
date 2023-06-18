// using System.Collections.Generic;
// using System;

// namespace L6_10
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Hello, World!");
//         }
//     }

//     abstract class NPC
//     {
//         private bool _isLive;
//         private bool _isStunned;
//         private int _health;
//         private int _damage;
//         private int _distance;
//         private int _speed;
//         private Sides _side;
//         private int _posX;
//         private int _posY;


//         public NPC(int health, int damage, int distance, int speed, Sides side)
//         {
//             _isLive = true;
//             _isStunned = false;
//             _health = health;
//             _damage = damage;
//             _distance = distance;
//             _speed = speed;
//             _side = side;
//         }

//         public int Damage => _damage;
//         public int Distance => _distance;
//         public int Speed => _speed;
//         public bool IsStunned => _isStunned;
//         public bool IsLive => _isLive;
//         public Sides Side => _side;

//         public void SetPosition(int x, int y)
//         {
//             _posX = x;
//             _posY = y;
//         }

//         public void TakeDamage(int damage)
//         {
//             _health -= damage;

//             if (_health <= 0)
//             {
//                 _isLive = false;
//             }
//         }

//         public void GetStunned()
//         {
//             _isStunned = true;
//         }
//     }

//     abstract class Troop
//     {
//         private List<NPC> _platoon;

//         public Troop(List<NPC> platoon)
//         {
//             _platoon = platoon;
//         }

//         public int RemainingArmy => _platoon.FindAll(p => p.IsLive == true).Count;

//         public override NPC GetWarrior(int id)
//         {
//             return _platoon[id];
//         }
//     }

//     /*
//     Орда: Барабан, на 1 ход ускоряет всех союзников на 2
//     1. Варвар - ближний бой жизней 10, урон 2, скорость 1, 5% шанс оглушить противника на 1 ход
//     2. Шаман - урон 1 на расстоянии 3, жизней 7, скорость 1
//     способность: ставит рядом тотем при обнаружении противника на расстоянии 3, который усиливает союзников в радиусе 5 вокруг и +2 к урону, у тотема 1 жизнь, и он знимает целую клетку (у шамана только 1ин тотем)
//     3. Троль - кидает копье на 3, урон 3, жизней 5, скорость 2, 5% щанс нанести двойной урон

//     Алъянс: Тактика - пехота всегда спереди, держат оборону (не идут в атаку и получают на 1 урон меньше) пока не начнется бой.
//     1. Пехотинец - урон 1, жизней 8, скорость 1, 5% щанс заблокировать входящий урон
//     2. Целитель - дальний бой на 3, урон 1, скороть 1, жизней 5 способность: исцеляет близжайшего раненого союзника на 4 жизней, при условии что у союзника не хватает жизней (колдаун на 1 ход)
//     3. Лучники - дальний бой на 4, урон 2, жизней 7, выбирает противника с наименьшим здоровьем, скорость 1

//     Сражение: все сражаются по очереди, сначало все воины Орды, затем Альянс, очередность воинов в армии рандомная (как повезет)
//     - Размер поля в длину 20, а ширину 10, количество воинов 50 (30 1го типа, 5 - 2го типа и 15 - 3го типа), изначально войска занимают первые 3 столбца по разные стороны
//     - Воины не могут проходить сквозь друг друга
//     - На поле могут быть естественные препятствия
//     - Побеждает та сторона у которой жив хотя бы 1 воин
//     - В ближем бою воины достают до всех прилегающих вокруг клетках, дальний бой - достает по самому короткому маршруту не считая препятствий
//     */

//     class Battlefield
//     {
//         const int FieldLength = 10;
//         const int FieldWidth = 20;

//         private Troop _orda;
//         private Troop _aliance;
//         private NPC[,] _field;

//         public Battlefield()
//         {
//             _orda = new Orda();
//             _aliance = new Aliance();
//             _field = new NPC[FieldLength, FieldWidth];
//             Formate();
//         }

//         public void StartBattle()
//         {
//             for (int i = 0; i < _orda.RemainingArmy; i++)
//             {
//                 NPC warriorOfOrda = _orda.GetWarrior(i);
//                 Move(posX, posY, warriorOfOrda);
//             }
//         }

//         private void Move(int x, int y, NPC warrior)
//         {
//             if (warriorOfOrda.IsLive == true && warriorOfOrda.IsStunned == false)
//             {
//                 warrior.SetPosition(x, y);
//                 _field[x, y] = warrior;
//             }
//         }


//         private void Formate()
//         {
//             int lines = 3;
//             int schrenga = 20;

//             for (int i = 0; i < lines; i++)
//             {
//                 int line = 9 - i;

//                 for (int j = 0; j < schrenga; j++)
//                 {
//                     int id = i * schrenga + j;
//                     NPC warriorOfOrda = _orda.GetWarrior(id);
//                     NPC warriorOfAliance = _aliance.GetWarrior(id);
//                     warriorOfOrda.SetPosition(i, j);
//                     _field[i, j] = warriorOfOrda;
//                     warriorOfAliance.SetPosition(line, j);
//                     _field[line, j] = warriorOfAliance;
//                 }
//             }
//         }
//     }

//     enum Sides
//     {
//         Orda,
//         Aliance
//     }
// }