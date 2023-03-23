using System;

namespace L4_2
{
  class Program
  {
    private static void Main(string[] args)
    {
      int healthBarLength = 20;
      int currentHealthPointsInPercent = 66;
      ShowHealthBar(currentHealthPointsInPercent, healthBarLength);
    }

    private static void DrawBar(int startPosition, int lastPosition, char symbol)
    {
      for (int i = startPosition; i < lastPosition; i++)
      {
        Console.Write(symbol);
      }
    }

    private static void ShowHealthBar(int healthPointsInPercent, int healthbarLength)
    {
      int minHealthPoints = 0;
      float maxHealthPointsInPercent = 100f;
      int currentHealthPointsInPercent = 0;

      if (healthPointsInPercent > maxHealthPointsInPercent)
      {
        currentHealthPointsInPercent = Convert.ToInt32(maxHealthPointsInPercent);
      }
      else if (healthPointsInPercent < minHealthPoints)
      {
        currentHealthPointsInPercent = minHealthPoints;
      }
      else
      {
        currentHealthPointsInPercent = healthPointsInPercent;
      }

      int currentHealthPoints = Convert.ToInt32(healthbarLength / maxHealthPointsInPercent * currentHealthPointsInPercent);
      Console.Write("[");
      DrawBar(minHealthPoints, currentHealthPoints, '†');
      DrawBar(currentHealthPoints, healthbarLength, '_');
      Console.Write("]");
    }
  }
}