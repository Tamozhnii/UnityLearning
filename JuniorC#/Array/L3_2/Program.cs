Random random = new Random();
int maxValue = 10;
int[,] matrix = new int[10, 10];
int currentMaxValue = 0;
int zero = 0;

for (int i = 0; i < matrix.GetLength(0); i++)
{
  for (int j = 0; j < matrix.GetLength(1); j++)
  {
    matrix[i, j] = random.Next(maxValue);
  }
}

for (int i = 0; i < matrix.GetLength(0); i++)
{
  for (int j = 0; j < matrix.GetLength(1); j++)
  {
    if (currentMaxValue < matrix[i, j]) currentMaxValue = matrix[i, j];
  }
}

Console.WriteLine($"Максимальное значение = {currentMaxValue}");
Console.WriteLine("Исходная матрица:");

for (int i = 0; i < matrix.GetLength(0); i++)
{
  Console.Write("[ ");

  for (int j = 0; j < matrix.GetLength(1); j++)
  {
    matrix[i, j] = random.Next(maxValue);
    Console.Write($"{matrix[i, j]} ");
  }

  Console.Write("]\n");
}

Console.WriteLine("\nПолученная матрица:");

for (int i = 0; i < matrix.GetLength(0); i++)
{
  Console.Write("[ ");

  for (int j = 0; j < matrix.GetLength(1); j++)
  {
    if (matrix[i, j] == currentMaxValue) matrix[i, j] = zero;

    Console.Write($"{matrix[i, j]} ");
  }

  Console.Write("]\n");
}
