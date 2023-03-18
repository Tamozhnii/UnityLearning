Random random = new Random();
int maxValue = 10;
int[] numbers = new int[30];

Console.Write("[ ");

for (int i = 0; i < numbers.Length; i++)
{
  numbers[i] = random.Next(maxValue);
  Console.Write($"{numbers[i]} ");
}

Console.Write("]\n");
Console.Write("Локальные максимальные числа: ");

for (int j = 0; j < numbers.Length; j++)
{
  if (j == 0)
  {
    if (numbers[j] > numbers[j + 1]) Console.Write($"{numbers[j]} ");
  }
  else if (j == numbers.Length - 1)
  {
    if (numbers[j] > numbers[j - 1]) Console.Write($"{numbers[j]} ");
  }
  else
  {
    if (numbers[j] > numbers[j + 1] && numbers[j] > numbers[j - 1]) Console.Write($"{numbers[j]} ");
  }
}
