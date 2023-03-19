int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
Console.Write("Укажите на сколько сдвинуть массив влево: ");
int offsetToLeft = Convert.ToInt32(Console.ReadLine());
int firstElementIndex = 0;

Console.Write("[ ");

for (int i = 0; i < numbers.Length; i++)
{
  Console.Write($"{numbers[i]} ");
}

Console.Write("]");

for (int f = 0; f < offsetToLeft; f++)
{
  int firstElementValue = numbers[firstElementIndex];

  for (int i = 0; i < numbers.Length - 1; i++)
  {
    numbers[i] = numbers[i + 1];
  }

  numbers[numbers.Length - 1] = firstElementValue;
}

Console.Write(" => [ ");

for (int i = 0; i < numbers.Length; i++)
{
  Console.Write($"{numbers[i]} ");
}

Console.Write("]");
