int minValue = 1;
int maxValue = 27;
int numericalValue = 3;
Random random = new Random();
int currentNumber = random.Next(minValue, maxValue + 1);
int otherNumber = 0;
int resultCounter = 0;

while (otherNumber.ToString().Length <= numericalValue)
{
  otherNumber += currentNumber;

  if (otherNumber.ToString().Length == numericalValue)
  {
    resultCounter++;
  }
}

Console.WriteLine($"Количество трехзначных натуральных чисел кратных {currentNumber} состовляет: {resultCounter}");

//Проверка
// int testCounter = 0;

// for (int i = 100; i < 1000; i++)
// {
//   if (i % currentNumber == 0) testCounter++;
// }

// Console.WriteLine($"Тест: {testCounter}");
