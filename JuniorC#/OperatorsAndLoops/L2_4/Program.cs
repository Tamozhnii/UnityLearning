int minValue = 0;
int maxValue = 100;
Random rand = new Random();
int randomValue = rand.Next(minValue, maxValue);
int basis1 = 3;
int basis2 = 5;
int sum = 0;

for (int i = 0; i <= randomValue; i++)
{
  if (i % basis1 == 0 || i % basis2 == 0)
  {
    sum += i;
  }
}

Console.WriteLine($"Случайное значение равно {randomValue}");
Console.WriteLine($"Сумма всех положительных чисел кратных {basis1} или {basis2} состовляет {sum}");
Console.ReadKey();
