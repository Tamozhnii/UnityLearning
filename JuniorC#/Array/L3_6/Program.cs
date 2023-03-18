Random random = new Random();
int maxValue = 10;
int[] array = new int[10];

Console.Write("[ ");

for (int i = 0; i < array.Length; i++)
{
  array[i] = random.Next(maxValue);
  Console.Write($"{array[i]} ");
}

Console.Write("]\n");

for (int j = 1; j < array.Length; j++)
{
  for (int g = 0; g < array.Length - j; g++)
  {
    if (array[g] > array[g + 1])
    {
      int temp = array[g];
      array[g] = array[g + 1];
      array[g + 1] = temp;
    }
  }
}

Console.Write("[ ");

for (int i = 0; i < array.Length; i++)
{
  Console.Write($"{array[i]} ");
}

Console.Write("]");
