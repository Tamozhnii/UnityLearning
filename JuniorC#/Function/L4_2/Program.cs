using System;

namespace L4_2
{
  class Program
  {
    private static void Main(string[] args)
    {
      int healthbarLength = 20;
      int currentHealthPointsInPercent = 66;
      ShowHealthbar(currentHealthPointsInPercent, healthbarLength);
    }

    private static void DrawBar(int startPosition, int lastPosition, char symbol)
    {
      for (int i = startPosition; i < lastPosition; i++)
      {
        Console.Write(symbol);
      }
    }

    private static void ShowHealthbar(int healthPointsInPercent, int healthbarLength)
    {
      float maxHealthPointsInPercent = 100f;
      int startPosition = 0;
      int currentHealthPoints = Convert.ToInt32(healthbarLength / maxHealthPointsInPercent * healthPointsInPercent);
      Console.Write("[");
      DrawBar(startPosition, currentHealthPoints, '†');
      DrawBar(currentHealthPoints, healthbarLength, '_');
      Console.Write("]");
    }
  }
}