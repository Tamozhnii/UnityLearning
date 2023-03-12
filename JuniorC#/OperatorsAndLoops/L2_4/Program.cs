int sum = 0;
Random rand = new Random();
int randomValue = rand.Next(0, 100);

for (int i = 0; i <= randomValue; i++)
{
  bool isValidNumber = i % 3 == 0 || i % 5 == 0;

  if (isValidNumber)
  {
    sum += i;
  }
}

Console.WriteLine($"Случайное значение равно {randomValue}");
Console.WriteLine($"Сумма всех положительных чисел кратных 3 или 5 состовляет {sum}");
Console.ReadKey();
