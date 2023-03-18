Random random = new Random();
int[] array = new int[30];
int minValue = 1;
int maxValue = 4;
int value = 0;
int maxCounter = 0;
int currentValue = 0;
int currentCounter = 1;

Console.Write("[ ");

for (int i = 0; i < array.Length; i++)
{
  array[i] = random.Next(minValue, maxValue);
  Console.Write($"{array[i]} ");
}

Console.Write("]");

foreach (int number in array)
{
  if (value == 0)
  {
    value = number;
  }

  if (number == currentValue)
  {
    currentCounter++;
  }
  else if (maxCounter < currentCounter)
  {
    value = currentValue;
    maxCounter = currentCounter;
    currentCounter = 1;
  }
  else
  {
    currentCounter = 1;
  }

  currentValue = number;
}

Console.WriteLine($"\nСамое большое число повторений цифры {value}, {maxCounter} раз(-а) подряд");
