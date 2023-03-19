Random random = new Random();
int minValue = -60;
int maxValue = -50;
int firstLength = 10;
int secondLength = 10;
int[,] numbers = new int[firstLength, secondLength];
int currentMaxValue = 0;
int overwritingValue = 0;

for (int i = 0; i < numbers.GetLength(0); i++)
{
  for (int j = 0; j < numbers.GetLength(1); j++)
  {
    numbers[i, j] = random.Next(minValue, maxValue);
  }
}

for (int i = 0; i < numbers.GetLength(0); i++)
{
  for (int j = 0; j < numbers.GetLength(1); j++)
  {
    if (currentMaxValue == 0 || currentMaxValue < numbers[i, j])
    {
      currentMaxValue = numbers[i, j];
    }
  }
}

Console.WriteLine($"Максимальное значение = {currentMaxValue}");
Console.WriteLine("Исходная матрица:");

for (int i = 0; i < numbers.GetLength(0); i++)
{
  Console.Write("[ ");

  for (int j = 0; j < numbers.GetLength(1); j++)
  {
    Console.Write($"{numbers[i, j]} ");
  }

  Console.Write("]\n");
}

Console.WriteLine("\nПолученная матрица:");

for (int i = 0; i < numbers.GetLength(0); i++)
{
  Console.Write("[ ");

  for (int j = 0; j < numbers.GetLength(1); j++)
  {
    if (numbers[i, j] == currentMaxValue)
    {
      numbers[i, j] = overwritingValue;
    }

    Console.Write($"{numbers[i, j]} ");
  }

  Console.Write("]\n");
}
