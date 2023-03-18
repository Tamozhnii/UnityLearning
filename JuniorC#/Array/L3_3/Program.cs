Random random = new Random();
int maxValue = 10;
int arrayLength = 30;
int[] numbers = new int[arrayLength];

Console.Write("[ ");

for (int i = 0; i < numbers.Length; i++)
{
  numbers[i] = random.Next(maxValue);
  Console.Write($"{numbers[i]} ");
}

Console.Write("]\n");
Console.Write("Локальные максимальные числа: ");

if (numbers[0] > numbers[1])
{
  Console.Write($"{numbers[0]} ");
}

for (int j = 1; j < numbers.Length - 1; j++)
{
  if (numbers[j] > numbers[j + 1] && numbers[j] > numbers[j - 1])
  {
    Console.Write($"{numbers[j]} ");
  }
}

if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
{
  Console.Write($"{numbers[numbers.Length - 1]} ");
}
