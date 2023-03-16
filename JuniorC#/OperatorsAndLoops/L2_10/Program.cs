int currentNumber = 2;
int maxValue = 100;
Random random = new Random();
int randomNumber = random.Next(maxValue);
int extent = 0;
double result = 0;

for (int i = 0; result <= randomNumber; i++)
{
  result = Math.Pow(currentNumber, i);
  extent = i;
}

Console.WriteLine($"number = {randomNumber}, extent = {extent}, result = {result}");
