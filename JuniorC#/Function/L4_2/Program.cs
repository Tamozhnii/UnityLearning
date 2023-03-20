int maxHealthPoints = 20;
int currentHealthPointsInPercent = 75;

void ShowHealthbar(int healthPointsInPercent)
{
  int currentHealthPoints = Convert.ToInt32(maxHealthPoints * healthPointsInPercent / 100f);
  Console.Write("[");

  for (int i = 0; i < currentHealthPoints; i++)
  {
    Console.Write("†");
  }

  for (int i = currentHealthPoints; i < maxHealthPoints; i++)
  {
    Console.Write("_");
  }

  Console.Write("]");
}

ShowHealthbar(currentHealthPointsInPercent);
