﻿const char CommandShacklesFlame = '1';
const char CommandSwampOil = '2';
const char CommandEnergyShield = '3';
const char CommandEtherScythe = '4';
const char CommandSkipMove = '5';

int shacklesFlameDamage = 50;
int shacklesFlameColdownDuration = 2;
int burningDamage = 15;
int burningTimeDuration = 2;
int etherScytheDamageInPercent = 20;
int etherScytheColdownDuration = 3;
int energyShieldBlocked = 2;
int energyShieldColdownDuration = 2;
float swampOilUpFireDamage = 1.5f;
int swampOilSlowdownDuration = 1;
int swampOilUpBurnDuration = 1;
int swampOilColdownDuration = 4;
int bossMaxHealthPoint = 300;
int bossDamage = 20;
int userHealthPoint = 100;
int bossCurrentHealthPoint = bossMaxHealthPoint;
bool isEnergyShieldActive = false;
bool isBossInOil = false;
int bossBurnDuration = 0;
int bossSlowdownDuration = 0;
int shacklesFlameColdown = 0;
int etherScytheColdown = 0;
int swampOilColdown = 0;
int energyShieldColdown = 0;
int currentStep = 1;
int stepCount = 1;

Console.WriteLine("Приветствую герой!");
Console.WriteLine("Прежде чем бросить вызов боссу, ознакомся со своими скилами:");
Console.WriteLine($"{CommandShacklesFlame}. Shackles Flame (Оковы пламени) - наносит {shacklesFlameDamage} урона,\nа так же поджигает врага, нанося {burningDamage} урона за ход противника, в течении {burningTimeDuration} ходов.\nПерезарядка {shacklesFlameColdownDuration} хода");
Console.WriteLine($"{CommandSwampOil}. Swamp Oil (Болотное масло) - Замедляет противника заставляя пропустить {swampOilSlowdownDuration} ход,\nа так же получить увеличенный в {swampOilUpFireDamage} раза урон от огня, и продлевает горение на {swampOilUpBurnDuration} ход.\nПерезарядка {swampOilColdownDuration} хода");
Console.WriteLine($"{CommandEnergyShield}. Energy Shield (Энергетический щит) - уменьшает следующий получаемый урон в {energyShieldBlocked} раза.\nПерезарядка {energyShieldColdownDuration} хода");
Console.WriteLine($"{CommandEtherScythe}. Ether Scythe (Эфирная коса) - Наносит урон жертве в размере {etherScytheDamageInPercent}% от текущего здоровья противника,\nа если текущее здоровье противника составляет {etherScytheDamageInPercent}% от общего, то добивает мгновенно.\nПерезарядка {etherScytheColdownDuration} хода");
Console.ReadKey();
Console.WriteLine("\nНачало сражения!");

while (bossCurrentHealthPoint > 0 && userHealthPoint > 0)
{
  bool isCorrectedCommand = true;
  Console.WriteLine($"\nХод {stepCount}.\nВарианты действий:");
  Console.WriteLine($"{CommandShacklesFlame}. Shackles Flame");
  Console.WriteLine($"{CommandSwampOil}. Swamp Oil");
  Console.WriteLine($"{CommandEnergyShield}. Energy Shield");
  Console.WriteLine($"{CommandEtherScythe}. Ether Scythe");
  Console.WriteLine($"{CommandSkipMove}. Пропустить ход");
  Console.Write("\nВаше действие: ");
  char userAction = Convert.ToChar(Console.ReadLine());

  switch (userAction)
  {
    case CommandShacklesFlame:
      if (shacklesFlameColdown > 0)
      {
        Console.WriteLine($"Способность еще перезаряжается, осталось {shacklesFlameColdown} ход(-а)");
        isCorrectedCommand = false;
        break;
      }

      if (isBossInOil)
      {
        bossCurrentHealthPoint -= Convert.ToInt32(shacklesFlameDamage * swampOilUpFireDamage);
        bossBurnDuration += burningTimeDuration + swampOilUpBurnDuration;
        isBossInOil = false;
      }
      else
      {
        bossCurrentHealthPoint -= shacklesFlameDamage;
        bossBurnDuration += burningTimeDuration;
      }

      shacklesFlameColdown = shacklesFlameColdownDuration + currentStep;
      break;

    case CommandSwampOil:
      if (swampOilColdown > 0)
      {
        Console.WriteLine($"Способность еще перезаряжается, осталось {swampOilColdown} ход(-а)");
        isCorrectedCommand = false;
        break;
      }

      if (bossBurnDuration > 0)
      {
        bossBurnDuration += swampOilUpBurnDuration;
      }
      else
      {
        isBossInOil = true;
        bossSlowdownDuration += swampOilSlowdownDuration;
      }

      swampOilColdown = swampOilColdownDuration + currentStep;
      break;

    case CommandEnergyShield:
      if (energyShieldColdown > 0)
      {
        Console.WriteLine($"Способность еще перезаряжается, осталось {energyShieldColdown} ход(-а)");
        isCorrectedCommand = false;
        break;
      }

      isEnergyShieldActive = true;
      energyShieldColdown = energyShieldColdownDuration + currentStep;
      break;

    case CommandEtherScythe:
      if (etherScytheColdown > 0)
      {
        Console.WriteLine($"Способность еще перезаряжается, осталось {etherScytheColdown} ход(-а)");
        isCorrectedCommand = false;
        break;
      }

      int leftBossHealthPointInPercent = bossCurrentHealthPoint * 100 / bossMaxHealthPoint;

      if (leftBossHealthPointInPercent <= etherScytheDamageInPercent)
      {
        bossCurrentHealthPoint -= bossCurrentHealthPoint;
      }
      else
      {
        bossCurrentHealthPoint -= (bossCurrentHealthPoint * etherScytheDamageInPercent / 100);
      }

      etherScytheColdown = etherScytheColdownDuration + currentStep;
      break;

    case CommandSkipMove:
      break;

    default:
      Console.WriteLine("Такого действия не существует");
      isCorrectedCommand = false;
      break;
  }

  if (isCorrectedCommand)
  {
    if (shacklesFlameColdown > 0)
    {
      shacklesFlameColdown--;
    }

    if (etherScytheColdown > 0)
    {
      etherScytheColdown--;
    }

    if (swampOilColdown > 0)
    {
      swampOilColdown--;
    }

    if (energyShieldColdown > 0)
    {
      energyShieldColdown--;
    }

    if (bossCurrentHealthPoint > 0)
    {
      if (bossBurnDuration > 0)
      {
        bossCurrentHealthPoint -= burningDamage;
        bossBurnDuration--;
      }

      if (bossSlowdownDuration > 0)
      {
        bossSlowdownDuration--;
      }
      else
      {
        if (isEnergyShieldActive)
        {
          userHealthPoint -= bossDamage / energyShieldBlocked;
          isEnergyShieldActive = false;
        }
        else
        {
          userHealthPoint -= bossDamage;
        }
      }
    }

    Console.WriteLine($"\nУ босса осталось {bossCurrentHealthPoint} жизней, у вас {userHealthPoint} жизней");
    stepCount++;
  }
}

if (userHealthPoint <= 0 && bossCurrentHealthPoint <= 0)
{
  Console.WriteLine("Ничья");
}
else if (userHealthPoint <= 0)
{
  Console.WriteLine("Потрачено");
}
else if (bossCurrentHealthPoint <= 0)
{
  Console.WriteLine("Вы победили!");
}
