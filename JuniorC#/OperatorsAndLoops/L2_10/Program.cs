int currentNumber = 2;
Random random = new Random();
int randomNumber = random.Next(100);
int extent = 0;
double result = 0;

for (int i = 0; result <= randomNumber; i++)
{
  result = Math.Pow(currentNumber, i);
  extent = i;
}

Console.WriteLine($"number = {randomNumber}, extent = {extent}, result = {result}");
