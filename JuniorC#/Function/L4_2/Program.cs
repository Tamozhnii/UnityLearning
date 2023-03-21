int maxHealthPoints = 20;
float currentHealthPointsInPercent = 0.75f;
int startPosition = 0;

void DrowBar(int startPosition, int lastPosition, char symbol)
{
  for (int i = startPosition; i < lastPosition; i++)
  {
    Console.Write(symbol);
  }
}

void ShowHealthbar(int healthPointsInPercent)
{
  int currentHealthPoints = Convert.ToInt32(maxHealthPoints * healthPointsInPercent);
  Console.Write("[");
  DrowBar(startPosition, currentHealthPoints, '†');
  DrowBar(currentHealthPoints, maxHealthPoints, '_');
  Console.Write("]");
}

ShowHealthbar(currentHealthPointsInPercent);
