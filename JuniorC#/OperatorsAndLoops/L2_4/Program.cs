const int multipleThree = 3;
const int multipleFive = 5;
const int minValue = 0;
const int maxValue = 100;
Random random = new Random();
int randomValue = random.Next(minValue, maxValue);
int sum = 0;

for (int i = 0; i <= randomValue; i++)
{
  if (i % multipleThree == 0 || i % multipleFive == 0)
  {
    sum += i;
  }
}

Console.WriteLine($"Случайное значение равно {randomValue}");
Console.WriteLine($"Сумма всех положительных чисел кратных {multipleThree} или {multipleFive} состовляет {sum}");
Console.ReadKey();
